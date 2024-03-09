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
    /// Interaction logic for WindowListViewGridViewSample.xaml
    /// </summary>
    public partial class WindowListViewGridViewSample : Window
    {
        public WindowListViewGridViewSample()
        {
            InitializeComponent();

            List<UserA> userAs = new List<UserA>();

            userAs.Add(new UserA() { Name = "John Doe", Age = 42, Mail = "john@doe-family.com", Sex = SexType.Male });
            userAs.Add(new UserA() { Name = "Jane Doe", Age = 39, Mail = "jane@doe-family.com", Sex = SexType.Female });
            userAs.Add(new UserA() { Name = "Sammy Doe", Age = 39, Mail = "sammy.doe@gmail.com", Sex = SexType.Male });

            listViewUserAs.ItemsSource = userAs;

            CollectionView collectionView = (CollectionView)CollectionViewSource.GetDefaultView(listViewUserAs.ItemsSource);
            PropertyGroupDescription groupDescription = new PropertyGroupDescription("Sex");
            collectionView.GroupDescriptions.Add(groupDescription);
        }
    }

    public enum SexType { Male, Female };

    public class UserA
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public string Mail { get; set; }
        public SexType Sex { get; set; }
    }
}
