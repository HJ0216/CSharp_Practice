using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAddInPractice1
{
    [Transaction(TransactionMode.Manual)]
    public class Class1 : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiApplication = commandData.Application;
            UIDocument uiDocument = uiApplication.ActiveUIDocument;

            Application application = uiApplication.Application;
            Document document = uiDocument.Document;

            /* FilteredElementCollector: search and filter the set of elements in a document
            FilteredElementCollector collector = new FilteredElementCollector(document)
                .OfCategory(BuiltInCategory.OST_Walls);
            */

            /* ElementMulticategoryFilter: a filter to match elements by built-in category
            List<BuiltInCategory> categories = new List<BuiltInCategory>()
            {
                BuiltInCategory.OST_Walls,
                BuiltInCategory.OST_Floors,
            };

            ElementMulticategoryFilter elementMulticategoryFilter = new ElementMulticategoryFilter(categories);

            FilteredElementCollector collector = new FilteredElementCollector(document)
                .WherePasses(elementMulticategoryFilter);
            */

            ElementClassFilter familyInstanceFilter = new ElementClassFilter(typeof(FamilyInstance));

            // Create category filter for doors
            ElementCategoryFilter doorCategoryFilter = new ElementCategoryFilter(BuiltInCategory.OST_Doors);

            // Create a Logic and filter for all Door Family Instance
            // Can use LogicalOrFilter
            LogicalAndFilter doorInstancesFilter = new LogicalAndFilter(familyInstanceFilter, doorCategoryFilter);

            // Apply the filter to the element in the active documnet
            FilteredElementCollector collector = new FilteredElementCollector(document)
                .WherePasses(doorInstancesFilter);

            SimpleForm simpleForm = new SimpleForm(collector);
            simpleForm.ShowDialog();

            return Result.Succeeded;
        }
    }
}
