using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RevitAPIGettingStart
{
    public class SampleDeleteElements
    {
        public void DeleteElement(Document document)
        {
            Element element = FindElementByName(document, typeof(Wall), "외벽 - 스틸 스터드 벽돌벽");
            using(Transaction transaction = new Transaction(document, "Delete Element"))
            // Document 객체를 매개변수로 전달하는 것은 해당 문서에 대한 트랜잭션을 시작하는 것을 의미
            // Revit 프로젝트 파일(즉, .rvt 파일)
            // Document는 데이터 모델에 직접 작업하며, UIDocument는 사용자 인터페이스와 관련된 작업을 처리
            {
                transaction.Start();

                document.Delete(element.Id);

                transaction.Commit();
            }
        }

        public void DeleteElements(Document document)
        {
            List<Wall> walls = GetWalls(document);
            List<ElementId> elementIdList = new List<ElementId>();

            foreach(Wall wall in walls)
            {
                Element element = wall as Element;

                elementIdList.Add(element.Id);
            }

            using (Transaction transaction = new Transaction(document, "Delete Elements"))
            {
                transaction.Start();

                document.Delete(elementIdList);

                transaction.Commit();
            }
        }

        private Element FindElementByName(Document document, Type targetType, string targetName)
        {
            return new FilteredElementCollector(document)
                .OfClass(targetType)
                .FirstOrDefault<Element>(e => e.Name.Equals(targetName));
        }

        private List<Wall> GetWalls(Document document)
        {
            FilteredElementCollector collector = new FilteredElementCollector(document);
            ICollection<Element> walls = collector.OfClass(typeof(Wall)).ToElements();
            List<Wall> wallList = new List<Wall>();

            foreach(Wall wall in walls)
            {
                wallList.Add(wall);
            }

            return wallList;
        }
    }
}
