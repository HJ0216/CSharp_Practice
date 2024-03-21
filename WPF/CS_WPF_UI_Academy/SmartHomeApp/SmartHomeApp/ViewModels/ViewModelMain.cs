using SmartHomeApp.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SmartHomeApp.ViewModels
{
    public class ViewModelMain : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        #endregion



        #region Properties
        public ICommand MouseEnterCommand { get; private set; }
        public ICommand MouseLeftButtonDownCommand { get; private set; }

        #endregion

        #region Constructors
        public ViewModelMain()
        {
            MouseEnterCommand = new RelayCommand(MouseEnterEvent);
            MouseLeftButtonDownCommand = new RelayCommand(MouseLeftButtonDownEvent);
        }
        #endregion

        #region Methods
        private void MouseEnterEvent(object obj)
        {
        }

        private void MouseLeftButtonDownEvent(object obj)
        {
        }
        #endregion
    }
}
