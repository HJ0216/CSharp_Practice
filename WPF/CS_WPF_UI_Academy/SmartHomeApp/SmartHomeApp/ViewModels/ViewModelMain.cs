using SmartHomeApp.Helpers;
using SmartHomeApp.Views.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
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
        private UserControl _cardsControl;

        public UserControl CardsControl
        {
            get { return _cardsControl; }
            set 
            {
                _cardsControl = value;
                OnPropertyChanged("RaisePropertiesChanged");
            }
        }

        #endregion

        #region Commands
        public ICommand MouseEnterCommand { get; private set; }
        public ICommand MouseLeftButtonDownCommand { get; private set; }

        #endregion

        #region Constructors
        public ViewModelMain()
        {
            MouseEnterCommand = new RelayCommand(MouseEnterEvent);
            MouseLeftButtonDownCommand = new RelayCommand(MouseLeftButtonDownEvent);

            CardsControl = new UserControlCard();
            CardsControl.DataContext = new ViewModelCard();

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
