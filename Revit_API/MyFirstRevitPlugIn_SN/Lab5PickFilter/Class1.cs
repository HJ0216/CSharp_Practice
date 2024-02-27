using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Group = Autodesk.Revit.DB.Group;

namespace Lab5PickFilter
{
    /// <summary>
    /// The aim of this initial plug-in is to place a selected group at a location selected by the user.
    /// Chapter5
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

                // Pick point
                XYZ point = sel.PickPoint("Please pick a point to place group");

                // Place the group
                Transaction trans = new Transaction(doc);
                trans.Start("Lab");
                doc.Create.PlaceGroup(point, group.GroupType);
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
