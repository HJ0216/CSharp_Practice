using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace Lab1PlaceGroup
{
    /// <summary>
    /// The aim of this initial plug-in is to place a selected group at a location selected by the user.
    /// Chapter1
    /// </summary>
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class Class1 : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        // ExternalCommandData commandData
        // provides you with API access to the Revit application
        // All Revit data (including that of the model) is accessed via this commandData parameter.

        // string message
        // When this message gets set – and the Execute() method returns a failure or cancellation result – an error dialog is displayed by Revit
        // with this message text included. 

        // ElementSet elements
        // allows you to choose elements to be highlighted on screen should the external command fail or be cancelled.
        {
            // Get application and document objexts
            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;

            // Define a reference Object to accept the pick result
            Reference pickedref = null;
            // Reference is a class which can contain elements from a Revit model associated with valid geometry.

            // Pick a Group
            Selection sel = uiapp.ActiveUIDocument.Selection;
            // the current user selection
            pickedref = sel.PickObject(ObjectType.Element, "Please Select a Group");
            // The parameters of this method allow you to specify the type of element you want the user to select
            // (you can specify if you are expecting users to select a face, an element, an edge, etc.) along with the message
            // the user will see in the lower left corner of the Revit user interface while the plug-in waits for the selection to occur.
            Element elem = doc.GetElement(pickedref);
            Group group = elem as Group;

            // Pick point
            XYZ point = sel.PickPoint("Please pick a point to place group");
            // asked the user to pick a target point for the selected group to be copied to

            // Place the group
            Transaction trans = new Transaction(doc);
            // You started by declaring a Transaction variable named trans to which you assigned a new instance of the Transaction class,
            // created using the new keyword. 
            // The constructor (a special method used to create a new instance of a class) of the Transaction class expects
            // the active document’s database object to be passed in as a parameter,
            // so that the Transaction knows with which document it will be associated. 
            trans.Start("Lab");
            // "Lab": Transaction Name, it can be any string value you choose.
            doc.Create.PlaceGroup(point, group.GroupType);
            // to place a selected group at a location selected by the user.
            trans.Commit();

            return Result.Succeeded;

        }
    }
}
