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

namespace ListView_Data_Filtering_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            initData();
        }

        private void initData()
        {
            User[] users = new User[]
            {
                new User("Alice Johnson", "USA", "Pending"),
                new User("Bob Smith", "Canada", "Complete"),
                new User("Charlie Brown", "UK", "Pending"),
                new User("David Kim", "South Korea", "Complete"),
                new User("Emma Davis", "Australia", "Pending"),
                new User("Frank Miller", "Germany", "Complete"),
                new User("Grace Lee", "Japan", "Pending"),
                new User("Hannah Wilson", "France", "Complete"),
                new User("Ian Clark", "Brazil", "Pending"),
                new User("Julia Martinez", "Mexico", "Complete"),
                new User("Kevin Moore", "Italy", "Pending"),
                new User("Laura Taylor", "Spain", "Complete"),
                new User("Mark Anderson", "Netherlands", "Pending"),
                new User("Nancy Thomas", "Sweden", "Complete"),
                new User("Oscar White", "Norway", "Pending"),
                new User("Paula Harris", "Denmark", "Complete"),
                new User("Quincy Lewis", "Finland", "Pending"),
                new User("Rachel Walker", "Switzerland", "Complete"),
                new User("Sam Hall", "Austria", "Pending"),
                new User("Tina Young", "Belgium", "Complete"),
                new User("Uma King", "Portugal", "Pending"),
                new User("Victor Wright", "Poland", "Complete"),
                new User("Wendy Scott", "Czech Republic", "Pending"),
                new User("Xavier Green", "Greece", "Complete"),
                new User("Yara Adams", "Turkey", "Pending"),
                new User("Zane Baker", "Egypt", "Complete"),
                new User("Amy Carter", "India", "Pending"),
                new User("Brian Reed", "China", "Complete"),
                new User("Cindy Perez", "Singapore", "Pending"),
                new User("Don Evans", "Malaysia", "Complete")
            };

            myList.ItemsSource = users;

            //filterBy.ItemsSource = new string[] { "Name", "Country", "Status" };
            filterBy.ItemsSource = typeof(User).GetProperties().Select((u) => u.Name);

            myList.Items.Filter = NameFilter;

        }

        public Predicate<object> GetFilter()
        {
            // Predicate: 조건을 검사하는 델리게이트 타입
            // 특정 타입의 객체를 받아서 그 객체가 조건을 만족하는지 여부를 bool 타입으로 반환하는 메서드에 사용
            switch (filterBy.SelectedItem as string)
            {
                case "Name":
                    return NameFilter;
                case "Country":
                    return CountryFilter;
                case "Status":
                    return StatusFilter;
            }

            return NameFilter;
        }

        private bool NameFilter(object obj)
        {
            var filterObj = obj as User;
            return filterObj.Name.Contains(filterTextbox.Text, StringComparison.OrdinalIgnoreCase);
        }
        private bool CountryFilter(object obj)
        {
            var filterObj = obj as User;
            return filterObj.Country.Contains(filterTextbox.Text, StringComparison.OrdinalIgnoreCase);
        }
        private bool StatusFilter(object obj)
        {
            var filterObj = obj as User;
            return filterObj.Status.Contains(filterTextbox.Text, StringComparison.OrdinalIgnoreCase);
        }

        private void filterTextbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (filterTextbox.Text == null)
            {
                myList.Items.Filter = null;
            }
            else
            {
                myList.Items.Filter = GetFilter();
            }
        }

        private void filterBy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            myList.Items.Filter = GetFilter();

        }
    }
}