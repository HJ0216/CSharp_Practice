using DesktopContactsApp.Classes;
using SQLite;
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

namespace DesktopContactsApp
{
    /// <summary>
    /// NewContactWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class NewContactWindow : Window
    {
        public NewContactWindow()
        {
            InitializeComponent();

            Owner = Application.Current.MainWindow;
            // 현재 창(일반적으로 대화 상자 또는 보조 창 등)의 소유자를 애플리케이션의 주 창(Main Window)으로 설정
            // 현재 창이 주 창 위에 항상 표시되도록 하고, 주 창과 함께 열리고 닫히도록 설정
            WindowStartupLocation = WindowStartupLocation.CenterOwner;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Contact contact = new Contact()
            {
                Name = nameTextBox.Text,
                Email = emailTextBox.Text,
                Phone = phoneTextBox.Text,
            };

            using(SQLiteConnection connection = new SQLiteConnection(App.databasePath)) 
            // App에 공통으로 사용될 변수를 정의해두고 Click Event마다 정의되지 않도록 수정
            {
                connection.CreateTable<Contact>();
                connection.Insert(contact);
            }

            // using 문을 사용하는 경우, 해당 블록이 종료되는 순간 관련 리소스를 자동으로 해제
            // SQLiteConnection 객체는 IDisposable 인터페이스를 구현하므로,
            // using 블록을 사용하여 생성하면 using 블록이 종료될 때 Dispose 메서드가 자동으로 호출
            // Dispose 메서드는 내부적으로 Close 메서드를 호출하여 데이터베이스 연결을 닫음

            /*
                        SQLiteConnection connection = new SQLiteConnection(databasePath);
                        connection.CreateTable<Contact>();
                        // 이미 테이블이 존재할 경우, 무시됨
                        connection.Insert(contact);
            */

            this.Close();
        }
    }
}
