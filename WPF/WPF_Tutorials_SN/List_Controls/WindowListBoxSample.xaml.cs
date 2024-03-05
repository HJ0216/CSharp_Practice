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
    /// Interaction logic for WindowListBoxSample.xaml
    /// </summary>
    public partial class WindowListBoxSample : Window
    {
        public WindowListBoxSample()
        {
            InitializeComponent();

            List<TodoItem> items = new List<TodoItem>();
            items.Add(new TodoItem() { Title = "Complete this WPF tutorial", Completion = 45 });
            items.Add(new TodoItem() { Title = "Learn C#", Completion = 80 });
            items.Add(new TodoItem() { Title = "Wash the car", Completion = 0 });

            toDoList.ItemsSource = items;
        }
    }
    public class TodoItem
    {
        public string Title { get; set; }
        public int Completion { get; set; }
    }
}
