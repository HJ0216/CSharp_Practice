using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace TreeView_Controls
{
    /// <summary>
    /// Interaction logic for WindowTreeViewSelectionExpansionSample.xaml
    /// </summary>
    public partial class WindowTreeViewSelectionExpansionSample : Window
    {
        public WindowTreeViewSelectionExpansionSample()
        {
            InitializeComponent();

            List<Person> persons = new List<Person>();
            Person person1 = new Person() { Name = "John Doe", Age = 42 };

            Person person2 = new Person() { Name = "Jane Doe", Age = 39 };

            Person child1 = new Person() { Name = "Sammy Doe", Age = 13 };
            person1.Children.Add(child1);
            person2.Children.Add(child1);

            person2.Children.Add(new Person() { Name = "Jenny Moe", Age = 17 });

            Person person3 = new Person() { Name = "Becky Toe", Age = 25 };

            persons.Add(person1);
            persons.Add(person2);
            persons.Add(person3);

            person2.IsSelected = true;
            person2.IsExpanded = true;

            treeViewPersons.ItemsSource = persons;
        }

        private void buttonSelectNext_Click(object sender, RoutedEventArgs e)
        {
            if(treeViewPersons.SelectedItem != null)
            {
                List<Person> persons = (treeViewPersons.ItemsSource as List<Person>);

                int curIndex = persons.IndexOf(treeViewPersons.SelectedItem as Person);

                if(curIndex >= 0)
                {
                    curIndex++;
                }
                if(curIndex >= persons.Count)
                {
                    curIndex = 0;
                }

                if(curIndex >= 0)
                {
                    persons[curIndex].IsSelected = true;
                }
            }
        }

        private void buttonToggleExpansion_Click(object sender, RoutedEventArgs e)
        {
            if(treeViewPersons.SelectedItem != null)
            {
                (treeViewPersons.SelectedItem as Person).IsExpanded = !(treeViewPersons.SelectedItem as Person).IsExpanded;
            }
        }
    }

    public class Person : TreeViewItemBase
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public ObservableCollection<Person> Children { get; set; }

        public Person()
        {
            this.Children = new ObservableCollection<Person>();
        }
    }

    public class TreeViewItemBase : INotifyPropertyChanged
    {
        private bool _isSelected;

        public bool IsSelected
        {
            get { return _isSelected; }
            set 
            {
                _isSelected = value;
                NotifyPropertyChanged("IsSelected");
            }
        }

        private bool _isExpanded;

        public bool IsExpanded
        {
            get { return _isExpanded; }
            set 
            { 
                _isExpanded = value;
                NotifyPropertyChanged("IsExpanded");
            }
        }



        public event PropertyChangedEventHandler? PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
