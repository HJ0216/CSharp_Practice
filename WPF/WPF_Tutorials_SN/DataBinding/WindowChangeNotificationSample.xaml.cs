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

namespace DataBinding
{
    /// <summary>
    /// WindowChangeNotificationSample.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class WindowChangeNotificationSample : Window
    {
        private ObservableCollection<User> users = new ObservableCollection<User>();
        public WindowChangeNotificationSample()
        {
            InitializeComponent();

            users.Add(new User() { Name = "John Doe" });
            users.Add(new User() { Name = "Jane Doe" });

            labelUsers.ItemsSource = users;
        }

        private void buttonAddUser_Click(object sender, RoutedEventArgs e)
        {
            users.Add(new User() { Name = "New User" });
        }

        private void buttonChangeUser_Click(object sender, RoutedEventArgs e)
        {
            if(labelUsers.SelectedItem != null)
            {
                (labelUsers.SelectedItem as User).Name = "Random Name";
            }
        }

        private void buttonDeleteUser_Click(object sender, RoutedEventArgs e)
        {
            if(labelUsers.SelectedItem != null)
            {
                users.Remove(labelUsers.SelectedItem as User);
            }
        }
    }

    public class User : INotifyPropertyChanged
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set 
            {
                if (_name != value)
                {
                    _name = value;
                    NotifyPropertyChanged(nameof(Name));
                }

            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

    }
}
