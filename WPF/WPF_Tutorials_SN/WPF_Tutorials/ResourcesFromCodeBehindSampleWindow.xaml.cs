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
    /// Interaction logic for ResourcesFromCodeBehindSampleWindow.xaml
    /// </summary>
    public partial class ResourcesFromCodeBehindSampleWindow : Window
    {
        public ResourcesFromCodeBehindSampleWindow()
        {
            InitializeComponent();
        }

        private void buttonClickMe_Click(object sender, RoutedEventArgs e)
        {
            //listBoxResult.Items.Add(panelMain.FindResource("strPanel").ToString());
            //listBoxResult.Items.Add(this.FindResource("strWindow").ToString());
            //listBoxResult.Items.Add(Application.Current.FindResource("strApplication").ToString());

            listBoxResult.Items.Add(panelMain.FindResource("strPanel").ToString());
            listBoxResult.Items.Add(panelMain.FindResource("strWindow").ToString());
            listBoxResult.Items.Add(panelMain.FindResource("strApplication").ToString());
            // 리소스를 찾지 못하면 계층 구조를 따라 검색
            // panel 레벨에서 찾지 못할 경우 window, application 레벨까지 탐색이 올라감
        }
    }
}
