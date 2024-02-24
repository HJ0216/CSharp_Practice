using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAPIGettingStart
{
    public class SampleCreateSharedParameter
    {
        public void CreateSampleSharedParameter(Document document, Application application)
        {
            Category category = document.Settings.Categories.get_Item(BuiltInCategory.OST_Walls);
            CategorySet categorySet = application.Create.NewCategorySet();
            categorySet.Insert(category);

            string originalFileName = application.SharedParametersFilename;
            string tempFileName = @"X:\Revit\Revit Support\SOM-Structural Parameters.txt";

            try
            {
                application.SharedParametersFilename = tempFileName;

                DefinitionFile sharedParameterFile = application.OpenSharedParameterFile();

                foreach(DefinitionGroup definitionGroup in sharedParameterFile.Groups)
                {
                    if(definitionGroup.Name == "DYNAMO")
                    {
                        ExternalDefinition externalDefinition = definitionGroup.Definitions.get_Item("GROUP 1") as ExternalDefinition;

                        using(Transaction transaction = new Transaction(document))
                        // using 문을 사용하면, 해당 블록이 끝날 때 Dispose 메서드가 자동으로 호출
                        // 이는 객체의 리소스를 안전하게 해제하고, 메모리 누수를 방지하는데 도움
                        {
                            transaction.Start("Add Shared Parameter");

                            InstanceBinding newInstanceBinding = application.Create.NewInstanceBinding(categorySet);
                            // InstanceBinding: 공유 매개변수가 특정 Revit 요소 인스턴스에 바인딩될 수 있게 함
                            // categorySet: 바인딩하려는 카테고리들의 집합

                            document.ParameterBindings.Insert(externalDefinition, newInstanceBinding, BuiltInParameterGroup.PG_TEXT);
                            // externalDefinition: 삽입할 공유 매개변수의 정의
                            // newInstanceBinding: 이 매개변수가 어떤 카테고리에 바인딩될지
                            // BuiltInParameterGroup.PG_TEXT: 이 매개변수가 속할 매개변수 그룹
                            // 'DYNAMO' 그룹에서 'GROUP 1'이라는 공유 매개변수를 생성하고, 이를 벽 카테고리에 바인딩하며, 매개변수 그룹은 'PG_TEXT'로 설정
                            // 벽 요소에서 'GROUP 1' 매개변수를 사용할 수 있음

                            transaction.Commit();
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                application.SharedParametersFilename = originalFileName;
            }
        }
    }
}
