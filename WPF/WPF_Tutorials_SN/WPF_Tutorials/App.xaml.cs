using System.Configuration;
using System.Data;
using System.Windows;
using System.Windows.Threading;

namespace WPF_Application
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show("An unhandled exception just occurred: " + e.Exception.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Error);
            e.Handled = true;
            // 예외를 이미 처리했으며 이와 관련해 더이상 아무것도 하지 않아도 된다는 것을 WPF에 전달
        }
    }

}
