using DesktopContactsApp.Classes;
using SQLite;
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

namespace DesktopContactsApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Contact> contacts;

        public MainWindow()
        {
            InitializeComponent();

            contacts = new List<Contact>();

            ReadDatabase();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NewContactWindow newContactWindow = new NewContactWindow();
            //newContactWindow.Show(); // 두 개의 창을 이동할 수 있음
            newContactWindow.ShowDialog(); // 하나의 창만 이용할 수 있음

            ReadDatabase();

        }

        void ReadDatabase()
        {
            using(SQLiteConnection conn = new SQLiteConnection(App.databasePath))
            {
                conn.CreateTable<Contact>();
                // Table을 읽을 때, 테이블이 없어 발생할 수 있는 오류 방지
                contacts = conn.Table<Contact>().ToList().OrderBy(c => c.Name).ToList();
                /*
                 var query = (from c2 in contacts
                             orderby c2.Name
                             select c2).ToList();
                 */
            }

            if(contacts != null)
            {
                /*                foreach(var c in contacts)
                                {
                                    contactsListView.Items.Add(new ListViewItem()){
                                        Content = c;
                                    }
                                }*/

                contactsListView.ItemsSource = contacts;
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox searchTextBox = sender as TextBox;
            // as 키워드를 사용한 안전한 형변환
            // 만약 sender가 TextBox 형태로 변환할 수 없는 경우, as 연산자는 null을 반환
            // (TextBox) 사용 시, 형변환이 안되면 InvalidCastException 발생

            var filteredList = contacts.Where(c => c.Name.ToLower().Contains(searchTextBox.Text.ToLower())).ToList();
            // 각 연락처 c에 대해 c.Name이 searchTextBox.Text를 포함(Contains)하는지 검사
            // 이 조건을 만족하는 c만 선택

            /*
             var query = (from c2 in contacts
                         where c2.Name.ToLower().Contains(searchTextBox.Text.ToLower())
                         orderby c2.Email
                         select c2).ToList();
             */

            contactsListView.ItemsSource = filteredList;

        }

        private void contactsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Contact selectedContact = (Contact)contactsListView.SelectedItem;

            if(selectedContact != null)
            {
                ContactDetailWindow contactDetailWindow = new ContactDetailWindow(selectedContact);
                contactDetailWindow.ShowDialog();
            }

            ReadDatabase();
        }
    }
}