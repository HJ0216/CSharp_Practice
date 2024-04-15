using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.DB.Structure;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Events;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPTRevitAPI.Helpers
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uIApplication = commandData.Application;
            UIDocument uIDocument = uIApplication.ActiveUIDocument;
            Application application = uIApplication.Application;
            Document document = uIDocument.Document;

            Room room = SelectRoom(uIDocument);
            CurveArray curveArray = GetRoomBoundaries(room);

            CreateFloor(document, curveArray);

            return Result.Succeeded;
        }

        private Room SelectRoom(UIDocument uIDocument)
        {
            Room room = null;
            try
            {
                // Create a Selection filter to select room
                RoomSelectionFilter roomSelectionFilter = new RoomSelectionFilter();

                // Let the user select a room
                Reference roomReference = uIDocument.Selection.PickObject(ObjectType.Element, roomSelectionFilter, "Select a room");

                if(roomReference != null)
                {
                    // Get the room element
                    Element roomElement = uIDocument.Document.GetElement(roomReference);

                    if( roomElement != null && roomElement is Room)
                    {
                        room = roomElement as Room;
                    }
                }
            }
            catch (Exception ex)
            {
                // User Canceled the selection operation
            }

            return room;
        }

        private CurveArray GetRoomBoundaries(Room room)
        {
            //List<CurveArray> boundaries = new List<CurveArray>();

            SpatialElementBoundaryOptions options = new SpatialElementBoundaryOptions();
            options.SpatialElementBoundaryLocation = SpatialElementBoundaryLocation.Center;

            CurveArray curveArray = null;

            foreach (IList<BoundarySegment> segment in room.GetBoundarySegments(options))
            {
                curveArray = new CurveArray();
                foreach (BoundarySegment curve in segment)
                {
                    curveArray.Append(curve.GetCurve());
                }

                //boundaries.Add(curveArray);
            }

            return curveArray;

            //return boundaries;
        }

        private void CreateFloor(Document document, CurveArray curveArray)
        {
            // Get Fllor type
            FilteredElementCollector collector = new FilteredElementCollector(document);
            collector.OfClass(typeof(FloorType));
            FloorType floorType = collector.FirstElement() as FloorType;

            // Create Floor
            using(Transaction transaction = new Transaction(document, "Create Floor"))
            {
                transaction.Start();
                /*
                public Floor NewFloor(
	                                    CurveArray profile,
	                                    FloorType floorType,
	                                    Level level,
	                                    bool structural
                                    )
                */
                document.Create.NewFloor(curveArray, floorType, document.ActiveView.GenLevel, false);
                transaction.Commit();    
            }
        }
    }

    public class RoomSelectionFilter : ISelectionFilter
    {
        public bool AllowElement(Element elem)
        {
            return elem is Room;
        }

        public bool AllowReference(Reference reference, XYZ position)
        {
            return false;
        }
    }
}
