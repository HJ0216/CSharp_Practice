using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace List_Controls
{
    /// <summary>
    /// Interaction logic for WindowListBoxBindingSample.xaml
    /// </summary>
    public partial class WindowListBoxBindingSample : Window
    {
        public WindowListBoxBindingSample()
        {
            InitializeComponent();

            List<TodoItem2> items = new List<TodoItem2>();
            items.Add(new TodoItem2() { Title = "Complete this WPF tutorial", Completion = 45 });
            items.Add(new TodoItem2() { Title = "Learn C#", Completion = 80 });
            items.Add(new TodoItem2() { Title = "Wash the car", Completion = 0 });

            toDoList.ItemsSource = items;
        }
    }

    public class TodoItem2
    {
        public string Title { get; set; }
        public int Completion { get; set; }
    }
}
