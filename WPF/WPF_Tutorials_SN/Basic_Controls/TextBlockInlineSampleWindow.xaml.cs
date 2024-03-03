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

namespace Basic_Controls
{
    /// <summary>
    /// Interaction logic for TextBlockInlineSampleWindow.xaml
    /// </summary>
    public partial class TextBlockInlineSampleWindow : Window
    {
        public TextBlockInlineSampleWindow()
        {
            InitializeComponent();
        }

        private void Hyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            //System.Diagnostics.Process.Start(e.Uri.AbsoluteUri);
            // 주로 실행 파일을 실행하는데 사용
            // .NET Framework에서는 Start 메서드가 URL을 인식하고 기본 웹 브라우저를 사용하여 URL을 열었지만, 
            // .NET Core와 .NET 5 이상에서는 이 기능이 동작하지 않음
            var processStartInfo = new ProcessStartInfo
            {
                FileName = "cmd",
                WindowStyle = ProcessWindowStyle.Hidden,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                Arguments = $"/c start {e.Uri.AbsoluteUri}"
            };
            Process.Start(processStartInfo);
        }
    }
}
