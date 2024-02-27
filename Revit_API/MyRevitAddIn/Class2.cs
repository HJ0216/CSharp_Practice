using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace MyRevitAddIn
{
    public class Class2 : IExternalApplication
    {
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Failed;
        }

        public Result OnStartup(UIControlledApplication application)
        {
            string assemblyName = Assembly.GetExecutingAssembly().Location;
            string path = Path.GetDirectoryName(assemblyName);

            // Create a tab
            string tabName = "Star Wars Tab";
            application.CreateRibbonTab(tabName);

            // Create Panel
            RibbonPanel demoPanel = application.CreateRibbonPanel(tabName, "Star Wars Panel");

            // Create PushButton Data
            PushButtonData btnData1 = new PushButtonData("buttonn1", "Button1", assemblyName, "MyRevitAddIn.Class1");
            PushButtonData btnData2 = new PushButtonData("buttonn2", "Button2", assemblyName, "MyRevitAddIn.Class1");
            PushButtonData btnData3 = new PushButtonData("buttonn3", "Button3", assemblyName, "MyRevitAddIn.Class1");
            PushButtonData btnData4 = new PushButtonData("buttonn4", "Button4", assemblyName, "MyRevitAddIn.Class1");
            PushButtonData btnData5 = new PushButtonData("buttonn5", "Button5", assemblyName, "MyRevitAddIn.Class1");
            PushButtonData btnData6 = new PushButtonData("buttonn6", "Button6", assemblyName, "MyRevitAddIn.Class1");

            btnData1.LargeImage = new BitmapImage(new Uri(path + @"\image-1.png"));
            btnData2.LargeImage = new BitmapImage(new Uri(path + @"\image-2.png"));
            btnData5.LargeImage = new BitmapImage(new Uri(path + @"\image-5.png"));
            btnData6.LargeImage = new BitmapImage(new Uri(path + @"\image-6.png"));

            btnData3.Image = new BitmapImage(new Uri(path + @"\image-3.png"));
            btnData4.Image = new BitmapImage(new Uri(path + @"\image-4.png"));

            btnData1.ToolTip = "This is ToolTip!";
            btnData1.ToolTipImage = new BitmapImage(new Uri(path + @"\image-1.png"));

            demoPanel.AddItem(btnData1);
            demoPanel.AddItem(btnData2);

            demoPanel.AddSeparator();

            demoPanel.AddStackedItems(btnData3, btnData4);

            SplitButtonData splitButtonData = new SplitButtonData("splitButton1", "splitBtn1");
            SplitButton splitButton = demoPanel.AddItem(splitButtonData) as SplitButton;

            splitButton.AddPushButton(btnData5);
            splitButton.AddPushButton(btnData6);

            return Result.Succeeded;
        }
    }
}
