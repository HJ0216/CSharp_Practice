using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructorOverriding.ViewModels
{
    public class ViewModelSub2
    {
        public string Data1 { get; set; } = "Hello";
        public string Data2 { get; set; } = "WPF";
        public void tempFunction()
        {
            MainWindow window = new();
            window.DataContext = new ViewModelMain(Data1, Data2);
        }

    }
}
