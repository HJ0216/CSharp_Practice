using SocialMediaInfoDashboard.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SocialMediaInfoDashboard.ViewModels
{
    public class ViewModelMain
    {
        #region Properties
        #endregion



        #region Commands
        public ICommand DragWindowCommand { get; private set; }
        public ICommand MinimizeWindowCommand { get; private set; }
        public ICommand CloseWindowCommand { get; private set; }

        #endregion



        #region Constructors
        public ViewModelMain()
        {
            DragWindowCommand = new RelayCommand(DragWindowEvent);
            MinimizeWindowCommand = new RelayCommand(MinimizeWindowEvent);
            CloseWindowCommand = new RelayCommand(CloseWindowEvent);
        }

        #endregion



        #region Methods
        private void DragWindowEvent(object obj)
        {
            var window = obj as Window;
            if (window != null)
            {
                window.DragMove();
            }
        }

        private void MinimizeWindowEvent(object obj)
        {
            var window = obj as Window;
            if (window != null)
            {
                window.WindowState = WindowState.Minimized;
            }
        }

        private void CloseWindowEvent(object obj)
        {
            Application.Current.Shutdown();
        }

        #endregion
    }
}
