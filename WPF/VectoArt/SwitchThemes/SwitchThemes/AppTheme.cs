using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SwitchThemes
{
    public class AppTheme
    {
        public static void ChangeTheme(Uri thereUri)
        {
            ResourceDictionary theme = new ResourceDictionary()
            {
                Source = thereUri,
            };

            App.Current.Resources.Clear();
            App.Current.Resources.MergedDictionaries.Add(theme);
        }
    }
}
