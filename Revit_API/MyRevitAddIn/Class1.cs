using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRevitAddIn
{
    [Transaction(TransactionMode.Manual)]
    public class Class1 : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            // Get Documnet and UIDocument
            UIDocument uIDocument = commandData.Application.ActiveUIDocument;
            Document document = uIDocument.Document;

            try
            {
                // Pick Object
                Reference pickedObject = uIDocument.Selection.PickObject(Autodesk.Revit.UI.Selection.ObjectType.Element);

                if(pickedObject != null)
                {
                    // Get hosting element geometry
                    ElementId elementId = pickedObject.ElementId;
                    Element element = document.GetElement(elementId);

                    LocationCurve locationCurve = element.Location as LocationCurve; // 곡선의 위치

                    Curve curve = locationCurve.Curve; // 곡선
                    XYZ point = curve.Evaluate(0.5, true);
                    // Evaluate: 곡선 상의 특정 위치를 XYZ 좌표로 반환
                    // 첫 번째 매개변수: 곡선의 시작점과 끝점 사이의 위치를 나타내는 비율
                    // 두 번째 매개변수: 노멀라이즈
                    // true - 첫 번째 매개변수의 값은 곡선의 전체 길이에 대한 비율로 해석
                    // false - 첫 번째 매개변수의 값인 지점의 XYZ 좌표를 계산

                    // Collecting Family Symbols
                    FilteredElementCollector collector = new FilteredElementCollector(document); // 특정 조건에 맞는 엘리먼트를 수집하는데 사용
                    IList<Element> elementList = collector.OfCategory(BuiltInCategory.OST_Doors).WhereElementIsElementType().ToElements();
                    // OfCategory: 카테고리에 속하는 엘리먼트만 수집하도록 필터를 설정
                    // WhereElementIsElementType: 수집된 엘리먼트 중에서 ElementType인 것만 선택하도록 필터를 추가 설정
                    // ElementType은 특정 엘리먼트의 형태나 속성을 정의하는 엘리먼트(문의 ElementType은 문의 디자인, 크기, 재질 등을 정의)
                    // ElementType은 일종의 템플릿 역할을 하며, 이 템플릿을 바탕으로 실제 Element가 생성
                    // * 문 카테고리에서 .WhereElementIsElementType()를 사용하면, 실제 문 Element를 수집하는 것이 아니라,
                    // 문의 디자인, 크기, 재질 등을 정의하는 ElementType를 수집
                    // ToElements: 최종적으로 설정된 필터에 맞는 엘리먼트를 모두 수집하여 IList 형태로 반환

                    foreach (var elem in elementList)
                    {
                        FamilySymbol familySymbol = elem as FamilySymbol;
                        if(elem.Id.ToString().Equals("71163"))
                        {
                            // Start Transaction
                            using(Transaction transaction = new Transaction(document, "Place Family Instance"))
                            {
                                transaction.Start();

                                // Create Instance
                                if (!familySymbol.IsActive)
                                {
                                    familySymbol.Activate();
                                }

                                document.Create.NewFamilyInstance(point, familySymbol, element, Autodesk.Revit.DB.Structure.StructuralType.NonStructural);
                                // FamilySymbol은 FamilyInstance를 생성하는 템플릿 역할을 하며, FamilyInstance는 실제 건축 모델에 배치되는 구체적인 요소

                                transaction.Commit();
                            }

                        }
                    }
                }

                return Result.Succeeded;
            }
            catch (Exception e)
            {

                message = e.Message;
                return Result.Failed;
            }
        }
    }
}
