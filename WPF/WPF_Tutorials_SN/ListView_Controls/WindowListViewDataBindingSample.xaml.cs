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

namespace ListView_Controls
{
    /// <summary>
    /// Interaction logic for WindowListViewDataBindingSample.xaml
    /// </summary>
    public partial class WindowListViewDataBindingSample : Window
    {
        public WindowListViewDataBindingSample()
        {
            InitializeComponent();

            List<User> users = new List<User>();
            users.Add(new User() { Name = "John Doe", Age = 42, Mail = "john@doe-family.com" });
            users.Add(new User() { Name = "Jane Doe", Age = 39, Mail = "jane@doe-family.com" });
            users.Add(new User() { Name = "Sammy Doe", Age = 13, Mail = "sammy.doe@gmail.com" });


            listViewDataBinding.ItemsSource = users;
        }
    }

    public class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Mail { get; set; }
    }
}
