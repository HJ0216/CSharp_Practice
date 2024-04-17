using System.Windows;

namespace GagaoTalk.Forms.UI.Views
{
    public class WindowGagao : Window
    {
        static WindowGagao()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(WindowGagao), new FrameworkPropertyMetadata(typeof(WindowGagao)));
        }
    }
}
