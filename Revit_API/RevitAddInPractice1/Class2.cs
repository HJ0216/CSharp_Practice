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
    [Regeneration(RegenerationOption.Manual)]
    public class Class2 : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uIApplication = commandData.Application;
            Application application = uIApplication.Application;
            UIDocument uIDocument = uIApplication.ActiveUIDocument;
            Document document = uIDocument.Document;

            /*
            ICollection<ElementId> familyIds = uIDocument.Selection.GetElementIds();
            List<Element> familes = new List<Element>();
            foreach (var familyId in familyIds)
            {
                familes.Add(
                    document.GetElement(familyId));
            }

            // Recommanded
            Element familyId = uIDocument.Selection
                .GetElementIds().Select(e => document.GetElement(e))
                .First();

            string value = familyId.get_Parameter(BuiltInParameter.ALL_MODEL_INSTANCE_COMMENTS).AsString();
            TaskDialog.Show("Message", value);
            */

            /*
            Element familyId = uIDocument.Selection
                .GetElementIds().Select(e => document.GetElement(e))
                .First();

            using(var transaction = new Transaction(document, "Set Values"))
            {
                transaction.Start();

                familyId.get_Parameter(BuiltInParameter.ALL_MODEL_INSTANCE_COMMENTS).Set("New Value");
                // 특정 family id의 comment에 New Value 설정

                transaction.Commit();
            }
            */

            ElementId builtInCategoryId = new ElementId(BuiltInCategory.OST_Walls);
            // builtInCategoryId의 IntegerValue 속성은 BuiltInCategory.OST_Walls의 정수 표현
            var builtInCategory = Enum.GetValues(typeof(BuiltInCategory))
                // Enum.GetValues 메서드는 Array 타입을 반환
                // Array는 object 타입의 요소들을 포함하고 있어, 반환된 값들을 직접적으로 BuiltInCategory 타입으로 다루기는 어려움
                .OfType<BuiltInCategory>() // 지정된 타입의 요소만 필터링하여 반환
                .FirstOrDefault(x => (int)x == builtInCategoryId.IntegerValue);
                // x는 BuiltInCategory 열거형의 각각의 값을 대표

            return Result.Succeeded;
        }
    }
}
