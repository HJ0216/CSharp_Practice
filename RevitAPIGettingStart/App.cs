using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAPIGettingStart
{
    [Transaction(TransactionMode.Manual)]
    public class App : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uIApplication = commandData.Application;
            UIDocument uIDocument = uIApplication.ActiveUIDocument;
            Application application = uIApplication.Application;

            //SingleSelection(uIDocument);
            //MultiSelection(uIDocument);
            //setParameter(uIDocument);
            //MovePointAndLineElements(uIDocument);
            //changeColor(uIDocument);

            //SampleParametersType sampleParametersType = new SampleParametersType();
            //sampleParametersType.SetTypeParameter(uIDocument.Document);

            //SampleDeleteElements sampleDeleteElements = new SampleDeleteElements();
            //sampleDeleteElements.DeleteElement(uIDocument.Document);
            //sampleDeleteElements.DeleteElements(uIDocument.Document);

            /*            SampleCollector sampleCollector = new SampleCollector();
                        List<Wall> walls_Class = sampleCollector.GetWalls_Class(uIDocument.Document);
                        List<Wall> walls_ActiveView = sampleCollector.GetWalls_ActiveView(uIDocument.Document);
                        List<Wall> walls_Category = sampleCollector.GetWalls_Categoty(uIDocument.Document);
                        Wall wall= sampleCollector.GetWallByNameLINQ(uIDocument.Document, "외벽 - 스틸 스터드 벽돌벽");
                        Element element = sampleCollector.GetWallByNameLambda(uIDocument.Document, "외벽 - 스틸 스터드 벽돌벽");

                        TaskDialog.Show("Values"
                            , "\n Walls using Class " + createStringBuilder(walls_Class).ToString()
                            + "\n Walls using Class In Active View " + createStringBuilder(walls_ActiveView).ToString()
                            + "\n Walls using Category " + createStringBuilder(walls_Category).ToString()
                            + "\n Wall using LINQ " + wall.Name + " " + wall.Id
                            + "\n Wall using Lambda " + element.Name + " " + element.Id
                            );*/

            //SampleWallChangeSize sampleWallChangeSize = new SampleWallChangeSize();
            //sampleWallChangeSize.ChangeWallType(uIDocument.Document);

            //SampleCreateSharedParameter sampleCreateSharedParameter = new SampleCreateSharedParameter();
            //sampleCreateSharedParameter.CreateSampleSharedParameter(uIDocument.Document, application);

            SampleIntersection sampleIntersection = new SampleIntersection();
            sampleIntersection.FindIntersectionEvent(uIDocument.Document);

            return Result.Succeeded;

        }

        public void changeColor(UIDocument uIDocument)
        {
            Document document = uIDocument.Document;

            List<Level> levels = getLevels(uIDocument);
            List<Floor> floors = getFloors(uIDocument);
            List<Wall> walls = getWalls(uIDocument);

            foreach(Level level in levels)
            {
                if(level.Name == "Level 2")
                {
                    TaskDialog.Show("Id: ", level.Id.ToString());
                }
            }

            Floor floor = floors.Find(x => x.Name == "S18");
            Wall wall = walls.Find(x => x.Name == "SW12");

            Element solidFill = new FilteredElementCollector(document)
                .OfClass(typeof(FillPatternElement))
                .Where(q => q.Name.Equals("Solid fill")).First();

            OverrideGraphicSettings overrideGraphicSettings = new OverrideGraphicSettings();
            // OverrideGraphicSettings: Revit 요소의 시각적 표현을 정의하기 위해 사용
            overrideGraphicSettings.SetProjectionLineColor(new Color(255, 0, 0));
            // ProjectionLine
            // 3D 모델의 표면에 그려지는 선을 의미합니다. 이 선은 모델의 외부 윤곽을 형성
            // 벽이나 바닥, 기타 건축 요소의 가장자리를 표시하는 선이 Projection Line에 해당
            overrideGraphicSettings.SetProjectionLinePatternId(solidFill.Id);
            // 투영선(3D 모델의 표면에 그려지는 선) 패턴 ID를 앞에서 찾은 "Solid Fill" 요소의 ID로 설정
            // 해당 요소의 선 패턴이 "Solid Fill" 패턴으로 설정

            using (Transaction transaction = new Transaction(document, "Change Color"))
            {
                try
                {
                    transaction.Start();

                    document.ActiveView.SetElementOverrides(floor.Id, overrideGraphicSettings);
                    document.ActiveView.SetElementOverrides(wall.Id, overrideGraphicSettings);

                    transaction.Commit();
                }
                catch (Exception ex)
                {

                }
            }
        }

        public List<Level> getLevels(UIDocument uIDocument)
        // Level: 건물의 층을 나타내는 참조 평면
        // 예를 들어, 건물의 1층, 2층, 지하 1층 등 각각의 층을 '레벨'이라고 부름
        {
            Document document = uIDocument.Document;

            FilteredElementCollector collector = new FilteredElementCollector(document);
            ICollection<Element> levels = collector.OfClass(typeof(Level)).ToElements();

            List<Level> levelList = new List<Level>();
            foreach(Level level in levels)
            {
                levelList.Add(level);
            }
            return levelList;
        }

        public List<Floor> getFloors(UIDocument uIDocument)
        {
            Document document = uIDocument.Document;

            FilteredElementCollector collector = new FilteredElementCollector(document);
            ICollection<Element> floors = collector.OfClass(typeof(Floor)).ToElements();

            List<Floor> floorList = new List<Floor>();
            foreach(Floor floor in floors)
            {
                floorList.Add(floor);
            }

            return floorList;
        }

        public List<Wall> getWalls(UIDocument uIDocument)
        {
            Document document = uIDocument.Document;

            FilteredElementCollector collector = new FilteredElementCollector(document);
            ICollection<Element> walls = collector.OfClass(typeof(Wall)).ToElements();

            List<Wall> wallList = new List<Wall>();
            foreach (Wall wall in walls)
            {
                wallList.Add(wall);
            }

            return wallList;
        }

        public void MovePointAndLineElements(UIDocument uIDocument)
        {
            Document document = uIDocument.Document;

            Element element = SelectElement(uIDocument);

            Wall wall = element as Wall;
            LocationCurve wallLine = wall.Location as LocationCurve;
            // LocationPoint는 점 위치를 표현
            // LocationCurve는 곡선 위치를 표현

            XYZ startXYZ = new XYZ(10, 20, 0); 
            // XYZ: Revit API에서 3차원 좌표
            XYZ endXYZ = new XYZ(20, 20, 0);

            Line newWallLine = Line.CreateBound(startXYZ, endXYZ); // startXYZ와 endXYZ 사이에 선분을 생성

            using (Transaction transaction = new Transaction(document, "Move")) // Main Transaction
            {
                transaction.Start("Move"); // Sub Transaction

                wallLine.Curve = newWallLine;

                transaction.Commit();

            }

        }

        /// <summary>
        /// 특정 Element(예: 벽, 문, 창 등)를 선택하고, 
        /// 그 Element의 특정 Parameter(예: 벽의 높이, 문의 너비 등)를 변경하는 것을 주 목적
        /// </summary>
        public void setParameter(UIDocument uIDocument)
        {
            Document document = uIDocument.Document;

            Element element = SelectElement(uIDocument);
            Parameter parameter = element.get_Parameter(BuiltInParameter.WALL_BASE_OFFSET);

            using (Transaction transaction = new Transaction(document, "param"))
            {
                transaction.Start("Param Transaction Start");
                try
                {
                    parameter.Set(-5);
                    // 1피트 = 304.8mm 이므로, -5피트는 대략 -1524mm
                    // 베이스 간격: 0 -> -1524
                }
                catch (Exception ex) { }

                transaction.Commit();

                TaskDialog.Show("New Value: ", GetParameterValue(parameter));
            }
        }

        /// <summary>
        /// 사용자가 Revit UI에서 Element를 선택
        /// </summary>
        /// <param name="uIDocument"></param>
        /// <param name="document"></param>
        /// <returns>선택된 Element</returns>
        public Element SelectElement(UIDocument uIDocument)
        {
            Reference reference = uIDocument.Selection.PickObject(ObjectType.Element);
            Element element = uIDocument.Document.GetElement(reference);
            
            return element;
        }

        /// <summary>
        /// Parameter의 저장 유형(StorageType)에 따라 적절한 메서드를 사용하여 값을 가져옴
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public string GetParameterValue(Parameter parameter)
        {
            switch (parameter.StorageType)
            {
                case StorageType.Double:
                    // get value with unit, AsDouble() can get value without unit
                    return parameter.AsValueString();
                case StorageType.ElementId:
                    return parameter.AsElementId().IntegerValue.ToString();
                case StorageType.Integer:
                    // get value with unit, AsInteger() can get value without unit
                    return parameter.AsValueString();
                case StorageType.None:
                    return parameter.AsValueString();
                case StorageType.String:
                    return parameter.AsString();
                default:
                    return "";
            }
        }

        /// <summary>
        /// Multi Selection
        /// </summary>
        /// <param name="uIDocument"></param>
        public void MultiSelection(UIDocument uIDocument)
        {
            Document document = uIDocument.Document;

            IList<Reference> pickedObjects = uIDocument.Selection.PickObjects(ObjectType.Element, "Select elements");
            List<ElementId> elementIds = (from Reference reference in pickedObjects
                                          select reference.ElementId)
            .ToList();

            using (Transaction transaction = new Transaction(document))
            {
                StringBuilder sb = new StringBuilder();
                transaction.Start("Transaction Name");

                if (pickedObjects != null && pickedObjects.Count > 0)
                {
                    foreach (ElementId elementId in elementIds)
                    {
                        Element element = document.GetElement(elementId);
                        sb.Append("\n" + element.Name);
                    }
                    TaskDialog.Show("title: ", sb.ToString());
                }

                transaction.Commit();
            }
        }

        /// <summary>
        /// Single Selection
        /// </summary>
        /// <param name="uIDocument"></param>
        public void SingleSelection(UIDocument uIDocument)
        {
            Document document = uIDocument.Document;

            Reference reference = uIDocument.Selection.PickObject(ObjectType.Element);
            Element element = uIDocument.Document.GetElement(reference);

            using (Transaction transaction = new Transaction(document))
            {
                transaction.Start("Transaction Name");

                TaskDialog.Show("Title: ", element.Name);

                transaction.Commit();
            }

        }

        /// <summary>
        /// Get Ids and Names to Walls
        /// </summary>
        /// <param name="walls"></param>
        /// <returns></returns>
        public StringBuilder createStringBuilder(List<Wall> walls)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach(Wall wall in walls)
            {
                stringBuilder.Append(wall.Name + " " + wall.Id + "\n");
            }

            return stringBuilder;
        }
    }
}
