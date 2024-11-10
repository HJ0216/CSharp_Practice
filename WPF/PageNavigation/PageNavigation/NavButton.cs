using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace PageNavigation
{
    public class NavButton : ButtonBase
    {
        static NavButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NavButton), new FrameworkPropertyMetadata(typeof(NavButton)));
        }

        public static readonly DependencyProperty ImageSourceProperty =
            DependencyProperty.Register("ImageSource", typeof(ImageSource), typeof(NavButton), new PropertyMetadata(null));
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(NavButton), new PropertyMetadata(null));
        public static readonly DependencyProperty NavUriProperty =
            DependencyProperty.Register("NavUri", typeof(Uri), typeof(NavButton), new PropertyMetadata(null));



        public ImageSource ImageSource
        {
            get { return (ImageSource)GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public Uri NavUri
        {
            get { return (Uri)GetValue(NavUriProperty); }
            set { SetValue(NavUriProperty, value); }
        }






    }
}
