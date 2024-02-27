using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6FindRoom
{
    /// <summary>
    /// The aim of this initial plug-in is to place a selected group at a location selected by the user.
    /// Chapter6
    /// </summary>
    [Transaction(TransactionMode.Manual)]
    public class Class1 : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            // Get application and document objexts
            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;

            try
            {
                // Define a reference Object to accept the pick result
                Reference pickedref = null;

                // Pick a Group
                Selection sel = uiapp.ActiveUIDocument.Selection;
                GroupPickFilter selFilter = new GroupPickFilter();

                pickedref = sel.PickObject(ObjectType.Element, selFilter, "Please Select a Group");
                // a selection filter is needed to constrain the range of types that can be selected
                Element elem = doc.GetElement(pickedref);
                Group group = elem as Group;
                // Get the group's center point
                XYZ origin = GetElementCenter(group);
                // Get the room that the picked group is located in
                Room room = GetRoomOfGroup(doc, origin);

                // Get the room's center point
                XYZ sourceCenter = GetRoomCenter(room);
                string coords =
                    "X = " + sourceCenter.X.ToString() + "\r\n"
                    + "Y = " + sourceCenter.Y.ToString() + "\r\n"
                    + "Z = " + sourceCenter.Z.ToString();

                TaskDialog.Show("Source room Center", coords);

                // Pick point
                //XYZ point = sel.PickPoint("Please pick a point to place group");

                // Place the group
                Transaction trans = new Transaction(doc);
                trans.Start("Lab");

                //doc.Create.PlaceGroup(point, group.GroupType);
                // Calculate the new group's position
                XYZ groupLocation = sourceCenter + new XYZ(20, 0, 0);
                doc.Create.PlaceGroup(groupLocation, group.GroupType);

                trans.Commit();

                return Result.Succeeded;

            }
            // If the user right-clicks or presses Esc, handle the exception
            catch (Autodesk.Revit.Exceptions.OperationCanceledException)
            {
                return Result.Cancelled;
            }
            catch (Exception e)
            {
                message = e.Message;
                // This tells Revit the command has failed and causes it to display the exception information in its standard error dialog.
                return Result.Failed;
            }
        }

        public XYZ GetElementCenter(Element elem)
        {
            BoundingBoxXYZ bounding = elem.get_BoundingBox(null);
            // If a property of a class takes one or more parameters,
            // the get_ prefix is needed before the property name to read the property value.
            // This prefix isn't needed if the property doesn't take any parameters
            XYZ center = (bounding.Max + bounding.Min) * 0.5;
            return center;
        }

        Room GetRoomOfGroup(Document doc, XYZ point)
        {
            FilteredElementCollector collector = new FilteredElementCollector(doc);
            collector.OfCategory(BuiltInCategory.OST_Rooms);

            Room room = null;
            foreach (Element elem in collector)
            {
                room = elem as Room;
                if (room != null)
                {
                    // Decide if this point is in the picked room
                    if (room.IsPointInRoom(point)) { break; }
                }
            }

            return room;
        }

        public XYZ GetRoomCenter(Room room)
        {
            // Get the room center point.
            XYZ boundCenter = GetElementCenter(room);
            LocationPoint locPt = (LocationPoint)room.Location;
            XYZ roomCenter = new XYZ(boundCenter.X, boundCenter.Y, locPt.Point.Z);
            return roomCenter;
        }
    }

    // Filter to constrain picking to model groups.
    // Only model groups are highlighted and can be selected when cursor is hovering.
    public class GroupPickFilter : ISelectionFilter
    {
        public bool AllowElement(Element elem)
        // During the selection process, when the cursor is hovering over an element,
        // this element will be passed into the AllowElement() method.
        // The AllowElement() method allows you to examine the element and determine whether it should be highlighted or not.
        // If you return true from this method, the element can be highlighted and selected.
        // If you return false, the element can be neither highlighted nor selected.
        {
            return (elem.Category.Id.IntegerValue.Equals((int)BuiltInCategory.OST_IOSModelGroups));
            // This is the line of code that checks if the given element’s category type is of “model group”:
        }

        public bool AllowReference(Reference reference, XYZ position)
        // if you return true from this method, then the reference can be highlighted and selected.
        // The AllowReference() method also needs to be implemented for the ISelectionFilter to be complete,
        // but as you don’t care about references in your plug-in, you simply return false from it:
        {
            return false;
        }
    }
}
