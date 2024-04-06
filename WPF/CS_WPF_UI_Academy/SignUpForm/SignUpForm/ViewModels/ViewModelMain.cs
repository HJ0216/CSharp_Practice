using SmartHomeApp.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SignUpForm.ViewModels
{
    public class ViewModelMain
    {
        #region Properties
        private string _email = string.Empty;

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        private string _password = string.Empty;

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        #endregion



        #region Commands
        public ICommand LoginCommand => null ?? new RelayCommand(LoginEvent);
        public ICommand WindowDragCommand => null ?? new RelayCommand(WindowDragEvent);
        public ICommand ApplicationShutDownCommand => null ?? new RelayCommand(ApplicationShutDownEvent);

        #endregion



        #region Constructors
        #endregion



        #region Methods
        private void LoginEvent(object obj)
        {
            MessageBox.Show("Success!");
        }

        private void WindowDragEvent(object obj)
        {
            var window = obj as Window;
            if (window != null)
            {
                window.DragMove();
            }
        }

        private void ApplicationShutDownEvent(object obj)
        {
            Application.Current.Shutdown();
        }

        #endregion
    }
}
