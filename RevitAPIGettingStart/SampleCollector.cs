using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace RevitAPIGettingStart
{
    public class SampleCollector
    {
        public List<Wall> GetWalls_Class(Document document)
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

        public List<Wall> GetWalls_ActiveView(Document document)
        {
            ICollection<Element> walls = new FilteredElementCollector(document, document.ActiveView.Id)
                .OfClass(typeof(Wall)).ToElements();

            List<Wall> wallList = new List<Wall>();
            foreach (Wall wall in walls)
            {
                wallList.Add(wall);
            }

            return wallList;
        }

        public List<Wall> GetWalls_Categoty(Document document)
        {
            IList<Element> walls = new FilteredElementCollector(document)
                .WhereElementIsNotElementType()
                .OfCategory(BuiltInCategory.OST_Walls)
                .ToElements();

            List<Wall> wallList = new List<Wall>();
            foreach (Wall wall in walls)
            {
                wallList.Add(wall);
            }

            return wallList;

        }

        public Wall GetWallByNameLINQ(Document document, string name)
        {
            Wall wall = (from v in new FilteredElementCollector(document).OfClass(typeof(Wall)).Cast<Wall>()
                         where v.Name == name
                         select v).First();
            // v: 개별 Wall Element
            // 'from' 키워드 뒤에 오는 컬렉션은 LINQ 쿼리가 자동으로 순회

            return wall;
        }

        public Element GetWallByNameLambda(Document document, string name)
        {
            return new FilteredElementCollector(document)
                .OfClass(typeof(Wall))
                .FirstOrDefault<Element>(e => e.Name.Equals(name));
        }
    }
}
