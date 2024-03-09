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
    /// Interaction logic for WindowFilteringSample.xaml
    /// </summary>
    public partial class WindowFilteringSample : Window
    {
        public WindowFilteringSample()
        {
            InitializeComponent();

            List<User> items = new List<User>();
            items.Add(new User() { Name = "John Doe", Age = 42 });
            items.Add(new User() { Name = "Jane Doe", Age = 39 });
            items.Add(new User() { Name = "Sammy Doe", Age = 13 });
            items.Add(new User() { Name = "Donna Doe", Age = 13 });
            listViewUsers.ItemsSource = items;

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(listViewUsers.ItemsSource);
            view.Filter = UserFilter;
            // CollectionView의 Filter 속성에 UserFilter 메소드를 할당
            // 컬렉션의 각 항목에 대해 호출되어, 해당 항목이 표시되어야 하는지를 결정
        }

        private bool UserFilter(object obj)
        {
            if (String.IsNullOrEmpty(textFilter.Text))
            {
                return true;
                // 필터링 텍스트가 비어있다면, 모든 항목을 표시
            }
            else
            {
                return ((obj as UserC).Name.IndexOf(textFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0);
            }
        }

        private void textFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(listViewUsers.ItemsSource).Refresh();
        }
    }

    public class UserC
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public string Mail { get; set; }

        public SexType Sex { get; set; }
    }

}
