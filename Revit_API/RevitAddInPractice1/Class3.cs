using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using RevitAddInPractice1.Extensions.SelectionExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAddInPractice1
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class Class3 : IExternalCommand
    {
        /* replace to lambda expression
        public bool IsWall(Element element)
        {
            return element is Wall;
        }
        */

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiApplication = commandData.Application;
            UIDocument uiDocument = uiApplication.ActiveUIDocument;

            Application application = uiApplication.Application;
            Document document = uiDocument.Document;

            /*            
                        var selectedElements = uiDocument.PickElements(
                            elements => elements.Category.Id == new ElementId(BuiltInCategory.OST_Doors)
                            , PickElementOptionFactory.CreateLinkDocumentOption());

                        TaskDialog.Show("Count".Replace selectedElements.Count.ToString());
            */

            /* replace to lambda expression
            IList<Reference> references = uiDocument.Selection.PickObjects(
                ObjectType.Element, new ElementSelectionFilter(IsWall));
            */


            /*
                            IList<Reference> references = uiDocument.Selection.PickObjects(
                            ObjectType.Element, new ElementSelectionFilter(
                                e => e is Floor
                                , r => r.ElementReferenceType == ElementReferenceType.REFERENCE_TYPE_SURFACE));
            */
/*            IList<Reference> references = uiDocument.Selection.PickObjects(
                ObjectType.PointOnElement, new LinkableSelctionFilter(
                    document
                    , e => e is Wall));*/

            return Result.Succeeded;
        }
    }
}
