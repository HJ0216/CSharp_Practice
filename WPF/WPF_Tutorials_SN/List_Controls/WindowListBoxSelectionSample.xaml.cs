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
    /// Interaction logic for WindowListBoxSelectionSample.xaml
    /// </summary>
    public partial class WindowListBoxSelectionSample : Window
    {
        public WindowListBoxSelectionSample()
        {
            InitializeComponent();

            List<TodoItem3> items = new List<TodoItem3>();
            items.Add(new TodoItem3() { Title = "Complete this WPF tutorial", Completion = 45 });
            items.Add(new TodoItem3() { Title = "Learn C#", Completion = 80 });
            items.Add(new TodoItem3() { Title = "Wash the car", Completion = 0 });

            toDoList.ItemsSource = items;
        }

        private void toDoList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(toDoList.SelectedItem != null)
            {
                this.Title = (toDoList.SelectedItem as TodoItem3).Title;
            }
        }

        private void buttonShowSelectedItem_Click(object sender, RoutedEventArgs e)
        {
            foreach(object o in toDoList.SelectedItems)
            {
                MessageBox.Show((o as TodoItem3).Title);
            }
        }

        private void buttonSelectLast_Click(object sender, RoutedEventArgs e)
        {
            toDoList.SelectedIndex = toDoList.Items.Count - 1;
        }

        private void buttonSelectNext_Click(object sender, RoutedEventArgs e)
        {
            int nextIndex = 0;
            if((toDoList.SelectedIndex >= 0) && (toDoList.SelectedIndex < toDoList.Items.Count - 1))
            {
                nextIndex = toDoList.SelectedIndex + 1;
            }
            toDoList.SelectedIndex = nextIndex;

        }

        private void buttonSelectCSharp_Click(object sender, RoutedEventArgs e)
        {
            foreach(object o in toDoList.Items)
            {
                if ((o is TodoItem3) && (o as TodoItem3).Title.Contains("C#"))
                {
                    toDoList.SelectedItem = o;
                    break;
                }
            }
        }

        private void buttonSelectAll_Click(object sender, RoutedEventArgs e)
        {
            foreach (object o in toDoList.Items)
            {
                toDoList.SelectedItems.Add(o);
            }
        }
    }

    public class TodoItem3
    {
        public string Title { get; set; }
        public int Completion { get; set; }
    }
}
