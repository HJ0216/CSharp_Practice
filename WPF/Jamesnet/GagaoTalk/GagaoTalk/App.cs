using GagaoTalk.Forms.UI.Views;
using Jamesnet.Wpf.Controls;
using System.Windows;

namespace GagaoTalk
{
    class App : JamesApplication
    {
        protected override Window CreateShell()
        {
            return new WindowGagao();
        }
    }
}
