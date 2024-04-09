using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SwitchThemes.ViewModels
{
    public class ViewModelMain : INotifyPropertyChanged
    {
        #region For INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        #endregion



        #region Properties
        private string _themeMode = "Dark";

        public string ThemeMode
        {
            get { return _themeMode; }
            set 
            {
                _themeMode = value; 
                OnPropertyChanged(nameof(ThemeMode));
            }
        }


        private bool _isLightMode = false;

        public bool IsLightMode
        {
            get { return _isLightMode; }
            set 
            {
                _isLightMode = value;
                ChangeTheme();

            }
        }

        #endregion

        #region Methods
        private void ChangeTheme()
        {
            if (IsLightMode)
            {
                AppTheme.ChangeTheme(new Uri("/Styles/DictionaryThemeWhite.xaml", UriKind.Relative));
                ThemeMode = "Light";
                return;
            }

            if (!IsLightMode)
            {
                AppTheme.ChangeTheme(new Uri("/Styles/DictionaryThemeBlack.xaml", UriKind.Relative));
                ThemeMode = "Dark";
                return;
            }
        }

        #endregion
    }
}
