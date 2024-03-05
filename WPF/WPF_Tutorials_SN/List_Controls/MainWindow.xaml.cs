using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace List_Controls
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            List<ToDoItem> toDoItems = new List<ToDoItem>();
            toDoItems.Add(new ToDoItem() { Title = "Complete this WPF tutorial", Completion = 45 });
            toDoItems.Add(new ToDoItem() { Title = "Learn C#", Completion = 80 });
            toDoItems.Add(new ToDoItem() { Title = "Wash the car", Completion = 0 });

            toDoList.ItemsSource = toDoItems;
        }
    }

    public class ToDoItem
    {
        public string Title { get; set; }
        public int Completion { get; set; }
    }
}