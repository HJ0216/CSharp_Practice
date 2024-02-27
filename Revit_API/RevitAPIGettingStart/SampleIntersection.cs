using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAPIGettingStart
{
    public class SampleIntersection
    {
        public void FindIntersectionEvent(Document document)
        {

            // Filter Walls
            FilteredElementCollector collector = new FilteredElementCollector(document)
                .OfClass(typeof(Wall));
            // OfClass(typeof(Wall)): 일반적으로 벽에 대해서만 작업할 때 적합
            // Wall 클래스의 인스턴스인 모든 엘리먼트를 수집
            // OfCategory(BuiltInCategory.OST_Walls): 벽과 관련된 모든 엘리먼트를 다루기에 적합
            // Wall 클래스의 인스턴스인 모든 엘리먼트를 수집
            // 및 Wall Sweeps(벽의 특정 부분에 물질을 추가하거나, 벽의 특정 부분을 강조하는 데 사용되는 요소: 몰딩 등), Wall Reveals(벽의 특정 부분에서 물질을 제거하는 데 사용되는 요소: 벽에 홈이나 틈 등) 등 벽과 관련된 다른 엘리먼트들도 포함할 수 있음

            foreach (Wall wall in collector)
            {
                isWallIntersected(document, wall.Id);
            }

        }
        public void isWallIntersected(Document document, ElementId elementId)
        {
            Element element = document.GetElement(elementId);

            BoundingBoxXYZ boundingBox = element.get_BoundingBox(document.ActiveView);
            Outline outline = new Outline(boundingBox.Min, boundingBox.Max);

            BoundingBoxIntersectsFilter filter = new BoundingBoxIntersectsFilter(outline);
            FilteredElementCollector collector = new FilteredElementCollector(document)
                .WhereElementIsNotElementType()
                .OfClass(typeof(Wall))
                .WherePasses(filter);

            IList<Element> intersectedElements = collector.WherePasses(filter).ToElements();

            foreach (Element elem in intersectedElements)
            {
                if (elementId.IntegerValue > elem.Id.IntegerValue)
                {
                    TaskDialog.Show("Main Id ", elementId.ToString() + " Sub Id " + elem.Id);
                }
            }
        }
    }
}
