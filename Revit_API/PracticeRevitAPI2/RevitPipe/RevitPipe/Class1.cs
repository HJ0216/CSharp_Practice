using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitPipe
{
    [Transaction(TransactionMode.Manual)]
    public class Class1 : IExternalCommand
    {
        UIApplication uiApplication;
        // Revit의 전체적인 환경에 대한 접근을 제공하며, 사용자 인터페이스(UI)와 관련된 기능을 포함
        // 사용자가 현재 열고 있는 프로젝트 파일에 대한 정보를 얻거나, Revit의 명령어를 실행하는 작업 등 UI와 직접적인 상호작용이 필요한 경우에 사용
        UIDocument uiDocument;
        // 현재 사용자가 작업하고 있는 문서(일반적으로는 열려 있는 Revit 프로젝트 파일)에 대한 접근을 제공
        // 예를 들어 사용자가 선택한 요소들을 얻거나, 뷰를 변경하는 것과 같은 작업을 할 수 있음
        Application application; 
        // Revit 애플리케이션 자체에 대한 접근을 제공하지만, UI와는 독립적인 기능을 담당
        // UI에 대한 직접적인 조작 없이 Revit의 핵심 기능에 접근할 수 있게 해줌
        Document document;
        // 현재 열린 Revit 문서(프로젝트 또는 패밀리)의 데이터 모델에 대한 접근을 제공
        // 모델 데이터를 조작하는 데 사용, 예를 들어, 문서 내의 요소들을 생성, 수정, 삭제하는 작업 등이 이에 해당

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            uiApplication = commandData.Application;
            uiDocument = uiApplication.ActiveUIDocument;
            application = uiApplication.Application;
            document = uiDocument.Document;

            // 선택한 Line 가져오기
            List<Element> listOfElement = GetPipeLine(uiDocument, document);

            // Pipe 생성 및 Pipe Fitting
            CreatePipe(uiDocument, document, listOfElement);

            return Result.Succeeded;
        }

        private void CreatePipe(UIDocument uiDocument, Document document, List<Element> elements)
        {
            // 1. Create Pipe
            PipeType pipeType = new FilteredElementCollector(document)
                .OfClass(typeof(Pipe))
                .FirstElement()
                as PipeType;
            // OfCategory
            // 예를 들어, "이 요소는 벽이야, 바닥이야, 천장이야?"와 같이 요소의 일반적인 역할이나 기능을 기준으로 필터링하고 싶을 때 사용
            // OfClass
            //  예를 들어, "이건 Wall 클래스로 만들어진 요소야, 아니면 FamilyInstance 클래스로 만들어진 요소야?"와 같이 요소가 실제로 어떤 코드 클래스로 구현되어 있는지를 기준으로 필터링하고 싶을 때 사용

            // Element
            // 실제로 모델에 배치되어 있는 구체적인 인스턴스를 나타냅니다. 예를 들어, 특정 벽이나 특정 문 등
            // ElementType
            // Element의 "타입" 또는 "정의"
            // ElementType은 모든 인스턴스(또는 Element)들이 공통으로 가지는 속성과 설정을 정의
            // 예를 들어, 특정 타입의 벽이나 문의 두께, 재질, 색상 등이 ElementType에 의해 정의

            Level level = new FilteredElementCollector(document)
                .OfClass(typeof(Level))
                .FirstElement()
                as Level;

            FilteredElementCollector pipeSystemTypeCollector = new FilteredElementCollector(document)
                .OfClass(typeof(PipingSystemType));
            ElementId pipeSystemElementId = pipeSystemTypeCollector.FirstElementId();

            bool flag = true;

            Pipe newPipe = null;
            XYZ startPoint = null;
            XYZ endPoint = null;

            // Create geometryElements
            List<GeometryElement> geometryElements = new List<GeometryElement>();
            // GeometryElement: 특정 element의 기하학적 구조
            // Element의 형태, 크기, 위치 등 기하학적 정보를 포함하며, Element가 실제로 어떻게 보이는지를 결정
            // 모델의 특정 부분에 대한 시각적 분석, 충돌 검사, 또는 새로운 구성 요소의 모델링 등에 활용

            foreach (Element element in elements)
            {
                GeometryElement geometryElement = element.get_Geometry(new Options());
                geometryElements.Add(geometryElement);
            }

            using(Transaction transaction = new Transaction(document))
            {
                try
                {
                    transaction.Start("Create Pipe");

                    List<Line> lines = new List<Line>();
                    List<Pipe> pipes = new List<Pipe>();
                    List<Element> pipeElements = new List<Element>();
                    
                    foreach (GeometryElement geometryElement in geometryElements)
                    {
                        foreach (GeometryObject geometryObject in geometryElement)
                        {
                            Line line = geometryObject as Line;

                            lines.Add(line);

                            startPoint = line.GetEndPoint(0);
                            endPoint = line.GetEndPoint(1);

                            if(pipeType != null)
                            {
                                newPipe = Pipe.Create(document, pipeSystemElementId, pipeType.Id, level.Id, startPoint, endPoint);
                                pipes.Add(newPipe);

                                Element element = document.GetElement(newPipe.Id as ElementId);
                                pipeElements.Add(element);

                                // Fitting할 Elbow 굵기에 맞게 pipe 굵기 설정하기
                                ElementId elementId = newPipe.Id as ElementId;
                                Parameter parameter = element.LookupParameter("Diameter");
                                parameter.Set(10 * 0.007333);

                                // Pipe의 연결할 Elbow Type 지정하기
                                // Revit API로 pipe fitting할 경우, 연결할 ElbowType 기본값이 none이므로 Routing Preferences에서 설정해줘야 함
                                ElementType elbowType = new FilteredElementCollector(document)
                                    .OfCategory(BuiltInCategory.OST_PipeFitting)
                                    .OfClass(typeof(ElementType))
                                    .Cast<ElementType>()
                                    .Where(x => x.FamilyName.Contains("M_Elbow"))
                                    .FirstOrDefault();

                                RoutingPreferenceManager manager = newPipe.PipeType.RoutingPreferenceManager;
                                manager.AddRule(RoutingPreferenceRuleGroupType.Elbows, new RoutingPreferenceRule(elbowType.Id, "Set Elbow fitting Type"));
                                int routingPerenceGroupCount = manager.GetNumberOfRules(RoutingPreferenceRuleGroupType.Elbows);
                                if(routingPerenceGroupCount > 1)
                                {
                                    for(int i=0; i<routingPerenceGroupCount - 1; i++)
                                    {
                                        manager.RemoveRule(RoutingPreferenceRuleGroupType.Elbows, 0);
                                    }
                                }
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                }
            }
        }

        private List<Element> GetPipeLine(UIDocument uiDocument, Document document)
        {
            ISelectionFilter selectionFilter = new PlanarFacesSelectionFilter(document);
            IList<Reference> references = uiDocument.Selection.PickObjects(ObjectType.Element, selectionFilter, "Select multiple planar faces");
            List<Element> elements = new List<Element>();

            foreach (Reference reference in references)
            {
                Element element = uiDocument.Document.GetElement(reference);
                elements.Add(element);
            }

            return elements;
        }
    }

    // 선택한 개체를 필터링할 수 있는 인터페이스 구현
    // An interface that provides the ability to filter objects during a selection operation
    public class PlanarFacesSelectionFilter : ISelectionFilter
    {
        Document document = null;

        public PlanarFacesSelectionFilter(Document doc)
        {
            document = doc;
        }

        public bool AllowElement(Element elem)
        {
            return true;
        }

        public bool AllowReference(Reference reference, XYZ position)
        {
            if(document.GetElement(reference).GetGeometryObjectFromReference(reference) is PlanarFace)
            {
                return true;
            }

            return false;
        }
    }
}
