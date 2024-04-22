using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Hello_WPF.CSCode
{
    /// <summary>
    /// Interaction logic for WindowFunctionButtons.xaml
    /// </summary>
    public partial class WindowFunctionButtons : Window
    {
        public WindowFunctionButtons()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
            //Environment.Exit(0);
            // 어플리케이션의 정상적인 종료 과정을 무시하고 프로세스를 즉시 종료
            // 이 방법은 긴급하게 어플리케이션을 종료해야 할 때 유용할 수 있으나, 일반적으로는 Application.Current.Shutdown();을 사용하는 것이 더 바람직
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(System.AppDomain.CurrentDomain.BaseDirectory);
            // 실행 중인 응용 프로그램의 루트 디렉토리 위치를 얻을 수 있으며, 일반적으로 응용 프로그램이 실행되는 디렉토리
            // 파일 시스템에 접근할 때 하드코딩된 경로 대신 동적으로 경로를 생성할 수 있어, 응용 프로그램의 이식성과 유지보수성이 향상
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(Environment.GetFolderPath(Environment.SpecialFolder.Windows));
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            string notepadPath = Environment.GetFolderPath(Environment.SpecialFolder.Windows) + "/notepad.exe";
            Process.Start(notepadPath);
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            //string temp = "C:\\Users\\user\\Desktop";
            string temp2 = @"C:\Users\user\Desktop";
            Process.Start("explorer.exe", temp2);
            // Process.Start 메소드가 실행 파일이나 어플리케이션을 실행하기 위해 설계
            // 더를 열기 위해서는 폴더를 열 수 있는 프로그램을 명시적으로 지정
        }
    }
}
