using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Structure;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Events;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeRevitAPI.Helpers
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public static Form1 form = null;

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uIApplication = commandData.Application;
            UIDocument uIDocument = uIApplication.ActiveUIDocument;
            Application application = uIApplication.Application;
            Document document = uIDocument.Document;

            #region Modal / Modless

            try
            {
                if(form == null || form.IsDisposed)
                {
                    Form1 form = new Form1();
                    form.Show();
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

            #endregion



            #region (Step6) Create Beam
            /*
            public FamilyInstance NewFamilyInstance( 가구 모음
	            Curve curve,
	            FamilySymbol symbol, 타입
	            Level level,
	            StructuralType structuralType
            )

            FamilyInstance = System Family + Instance Family
            

            XYZ p1 = new XYZ(0, 0, 0);
            XYZ p2 = new XYZ(10, 0, 0);
            Line line = Line.CreateBound(p1, p2); // 단위: Feet

            FilteredElementCollector collector = new FilteredElementCollector(document)
                .OfCategory(BuiltInCategory.OST_StructuralFraming)
                .OfClass(typeof(FamilySymbol));
            // OfClass(typeof(FamilySymbol)): UI가 아닌 FamilySymbol, Type만 필터링

            FamilySymbol familySymbol = null;
            foreach (FamilySymbol famSymbol in collector) 
            {
                if(famSymbol.Name == "G1")
                {
                    familySymbol = famSymbol;
                }
            }

            Level level = document.ActiveView.GenLevel;
            // 활성화된 View에서 Level을 가져옴
            // 단, 3D View에서는 Level이 없으므로 오류날 확률이 높음

            StructuralType structuralType = StructuralType.Beam;

            Transaction transaction = new Transaction(document, "Create");
            transaction.Start();

            familySymbol.Activate(); // familySymbol을 인식하지 못하는 경우를 대비
            FamilyInstance familyInstance = document.Create.NewFamilyInstance(line, familySymbol, level, structuralType);

            transaction.Commit();
             */

            #endregion



            #region (Step5) Multiple Selection
            /*
            IList<Reference> references = uIDocument.Selection.PickObjects(ObjectType.Element);
            // Revit에서 다중 속성을 자동으로 만들어줌

            List<Wall> walls = new List<Wall>();

            foreach (Reference reference in references)
            {
                Element element = document.GetElement(reference.ElementId);
                Wall wall = element as Wall;

                walls.Add(wall);
            }

            List<string> wallNames = new List<string>();
            for(int i = 0; i < references.Count; i++)
            {
                string name = walls[i].Name;
                wallNames.Add(name);
            }

            foreach (string wallName in wallNames)
            {
                TaskDialog.Show("벽체의 이름은 ", wallName + "입니다.");
            }
            */

            #endregion



            #region (Step4) Selection
            /* 
            Reference reference = uIDocument.Selection.PickObject(ObjectType.Element);
            Element element = document.GetElement(reference.ElementId);

            Wall wall = element as Wall;

            TaskDialog.Show("Notice", wall.Name);
            */

            #endregion



            #region (Step3) Default Setting
            /*
                        // Access Current Selection
                        Selection selection = uIDocument.Selection;

                        // Retrieve elements from database
                        FilteredElementCollector collector = new FilteredElementCollector(document)
                            .WhereElementIsNotElementType()
                            .OfCategory(BuiltInCategory.INVALID)
                            .OfClass(typeof(Wall));

                        // Filtered element collector is iterable
                        foreach (Element element in collector)
                        {
                            Debug.Print(element.Name);
                        }

                        // Modify Document within a Transaction
                        using (Transaction transaction = new Transaction(document))
                        {
                            transaction.Start("Transaction Name");
                            transaction.Commit();
                        }
            */

            #endregion

            return Result.Succeeded;

        }
    }
}
