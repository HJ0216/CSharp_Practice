using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAPIGettingStart
{
    public class SampleWallChangeSize
    {
        public void ChangeWallType(Document document)
        {
            List<Wall> wallList = GetWalls(document);
            WallType wallType = null;

            foreach(Wall wall in wallList)
            {
                try
                {
                    wallType = new FilteredElementCollector(document)
                        .OfClass(typeof(WallType)).First<Element>(x => x.Name == "SW48") as WallType;
                }
                catch (Exception ex)
                {

                }

                if(wallType != null)
                {
                    Transaction transaction = new Transaction(document, "Edit Type");

                    transaction.Start();

                    try
                    {
                        wall.WallType = wallType;
                    }
                    catch (Exception ex)
                    {

                    }

                    transaction.Commit();

                }

                if(wallType == null)
                {
                    WallType newWallType = CreateNewWallType(document, wall);
                    Transaction transaction = new Transaction(document, "Set New Type");

                    transaction.Start();

                    try
                    {
                        wall.WallType = newWallType;
                    }
                    catch (Exception ex)
                    {

                    }

                    transaction.Commit();
                }
            }
        }

        public List<Wall> GetWalls(Document document)
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

        public WallType CreateNewWallType(Document document, Wall wall)
        {
            WallType wallType = wall.WallType;
            WallType newWallType = null;

            Transaction transaction = new Transaction(document, "Duplicate Wall");

            transaction.Start();

            try
            {
                newWallType = wallType.Duplicate("SW48") as WallType;
                CompoundStructure compoundStructure = newWallType.GetCompoundStructure();
                int layerIndex = compoundStructure.GetFirstCoreLayerIndex();

                IList<CompoundStructureLayer> compoundStructureLayerList = compoundStructure.GetLayers();

                foreach(CompoundStructureLayer compoundStructureLayer in compoundStructureLayerList)
                // CompoundStructureLayer: 복합 벽(Compound Wall)의 구조
                // 외벽에는 보통 내부와 외부를 구분하는 여러 계층이 있음
                {
                    if (compoundStructureLayer.Function.ToString() == "Structure")
                    {
                        compoundStructure.SetLayerWidth(layerIndex, 48 / 12);
                    }
                    layerIndex++;
                }
                newWallType.SetCompoundStructure(compoundStructure);

            }
            catch (Exception ex)
            {

            }

            transaction.Commit();

            return newWallType;
        }
    }
}
