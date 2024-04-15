using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeRevitAPI
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        private ExternalEvent externalEvent;
        private CustomEventHandler handler;

        public Form1()
        {
            InitializeComponent();

            handler = new CustomEventHandler();
            externalEvent = ExternalEvent.Create(handler);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            externalEvent.Raise();
        }
    }

    public class CustomEventHandler : IExternalEventHandler
    {
        public void Execute(UIApplication app)
        {
            Document document = app.ActiveUIDocument.Document;

            using(Transaction transaction = new Transaction(document, "ModLess"))
            {
                transaction.Start();

                transaction.Commit();
            }
        }

        public string GetName()
        {
            return "End";
        }
    }
}
