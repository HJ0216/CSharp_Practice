using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAPIGettingStart
{
    public class SampleParametersType
    {
        public void SetTypeParameter(Document document)
        {
            Element element = FindElementByName(document, typeof(WallType), "SW48");
            WallType wallType = document.GetElement(element.Id) as WallType;

            try
            {
                using(Transaction transaction = new Transaction(document))
                // 만약 Start 메서드를 호출할 때 트랜잭션 이름을 지정하지 않으면, Revit API는 "Unnamed"라는 기본 이름을 사용
                // 하지만 일부 Revit 버전에서는 트랜잭션 이름을 반드시 지정해야 하는 경우가 있음
                // 이런 경우에는 Start 메서드에 트랜잭션 이름을 전달해야 함
                // Transaction transaction = new Transaction(document, "Transaction")
                // 이 방식을 사용하면 Start 메서드를 호출할 때 별도로 이름을 지정하지 않아도 됨
                // Transaction 생성자에서 지정을 안해주면 Start()에서 Transaction 이름을 지정해야 함
                {
                    transaction.Start();

                    Parameter parameter = wallType.get_Parameter(BuiltInParameter.ALL_MODEL_COST);
                    // BuiltInParameter: Revit API에서 제공하는 열거형 타입
                    // ALL_MODEL_COST: 각 요소의 비용 정보
                    parameter.Set(500);

                    transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                TaskDialog.Show("error: ", ex.Message);
            }
        }

        private Element FindElementByName(Document document, Type targetType, string targetName)
        {
            return new FilteredElementCollector(document)
                .OfClass(targetType)
                .FirstOrDefault<Element>(e => e.Name.Equals(targetName));
        }
    }
}
