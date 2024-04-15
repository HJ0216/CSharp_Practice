using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Creation;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloorBIM.Helpers
{
    public class RequestHanlder : IExternalEventHandler
    {
        public static UIDocument uIDocument = null;
        public static UIApplication uIApplication = null;
        public static Autodesk.Revit.DB.Document document = null;

        private Request request = new Request();
        public Request Request
        {
            get { return request; }
        }

        public string GetName()
        {
            return "Testing";
        }

        public void Execute(UIApplication app)
        {
            try
            {
                switch (Request.Take())
                {
                    case RequestId.count:
                        {
                            _count(app);
                            break;
                        }
                    case RequestId.CreateBeam:
                        {
                            _createBeam(app);
                            break;
                        }
                    case RequestId.CreateDeck:
                        {
                            _createDeck(app);
                            break;
                        }
                    case RequestId.ChangeName:
                        {
                            _changeName(app);
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                App.thisApp.WakeFormUp();
            }

            return;
        }

        private void _gang(UIApplication app)
        {

        }
        private void _count(UIApplication app)
        {

        }
        private void _createBeam(UIApplication app)
        {

        }
        public static Line ConvertRevitLine(ACadSharp.Entities.Line line)
        {

        }

        private void _createDock(UIApplication app)
        {

        }

        private void _changeName(UIApplication app)
        {

        }

        private void _editTopo(UIApplication app)
        {
            uIDocument = app.ActiveUIDocument;
            document = uIDocument.Document;
            Autodesk.Revit.ApplicationServices.Application application = app.Application;
            Autodesk.Revit.Creation.Application creaionApp = application.Create;

            IList<Reference> references = uIDocument.Selection.PickObjects(ObjectType.Element);
            List<XYZ> points = new List<XYZ>();

            foreach (Reference reference in references)
            {
                Floor floor = document.GetElement(reference.ElementId) as Floor;
                IList<Reference> bottomFaces = HostObjectUtils.GetBottomFaces(floor);
                foreach (Reference bottomFace in bottomFaces)
                {
                    Face face = document.GetElement(bottomFace.ElementId).GetGeometryObjectFromReference(bottomFace) as Face;
                    IList<CurveLoop> curveLoops = face.GetEdgesAsCurveLoops();

                    foreach (CurveLoop curveLoop in curveLoops)
                    {
                        foreach (Curve curve in curveLoop)
                        {
                            IList<XYZ> xYZs = curve.Tessellate();
                            // Tessellate: 직선일 경우, 2개의 XYZ(포인트)를 추출
                            // 곡선일 경우, Revit이 정한 일정한 간격으로 쪼개어 2개의 포인트를 추출
                            points.AddRange(xYZs);
                        }
                    }
                }
            }

            var sort = points.GroupBy(x => new {
                X = Math.Round(x.X, 5, MidpointRounding.AwayFromZero)
                , Y = Math.Round(x.Y, 5, MidpointRounding.AwayFromZero)
            })
                .Select(g => g.First()).ToList();
            // 소수점 5번째 자리까지 같다면 중복된 객체로 보고 하나의 그룹으로 만듦

            EditTopo(sort.ToArray());
        }

        private void EditTopo(XYZ[] xYZs)
        {
            TopographySurface target = document.GetElement(uIDocument.Selection.PickObject(ObjectType.Element).ElementId) as TopographySurface;
            FailureHandler failureHandler = new FailureHandler();

            List<XYZ> xYZList = new List<XYZ>();
            foreach (XYZ xYZ in xYZs)
            {
                if (target.ContainsPoint(xYZ))
                {
                    xYZList.Add(xYZ);
                }
            }

            using (TopographyEditScope editScope = new TopographyEditScope(document, "topoEdit"))
            {// editScope: 지형 편집 시, 편집 상태 시작

                editScope.Start(target.Id);
                using (Transaction transaction = new Transaction(document, "editScope"))
                {
                    transaction.Start();
                    target.AddPoints(xYZList);
                    transaction.Commit();
                }

                editScope.Commit(failureHandler);
            }
        }

        public class compareData
        {
            public XYZ m_mid { get; set; }
            public string m_infor { get; set; }
        }

        public class FailureHandler
        {
        }
    }
}
