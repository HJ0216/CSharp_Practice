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

namespace WPF_Application
{
    /// <summary>
    /// Interaction logic for ApplicationCultureSwitchSampleWindow.xaml
    /// </summary>
    public partial class ApplicationCultureSwitchSampleWindow : Window
    {
        public ApplicationCultureSwitchSampleWindow()
        {
            InitializeComponent();
        }

        private void CultureInfoSwitchButton_Click(object sender, RoutedEventArgs e)
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo((sender as Button).Tag.ToString());
            // 멀티 Thread 환경에서는 CurrentCulture보다는 DefaultThreadCurrentCulture 사용
            // CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("de-DE");
            LabelNumber.Content = (123456789.42d).ToString("N2");
            // N2: 천 단위마다 쉼표가 추가되고 소수점 이하 두 자리까지 표시
            LabelDate.Content = DateTime.Now.ToString();
        }
    }
}
