using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ConstructorOverriding.ViewModels
{
    public class ViewModelSub1
    {
        public string Data1 { get; set; } = "Hello";
        public void tempFunction()
        {
            MainWindow window = new ();
            window.DataContext = new ViewModelMain(Data1);
        }
    }
}
