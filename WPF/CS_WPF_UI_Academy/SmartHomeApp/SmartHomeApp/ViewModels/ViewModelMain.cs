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
using System.Windows.Media.Imaging;

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
        private UserControl _userControlCard1;

        public UserControl UserControlCard1
        {
            get { return _userControlCard1; }
            set { _userControlCard1 = value; }
        }

        private UserControl _userControlCard2;

        public UserControl UserControlCard2
        {
            get { return _userControlCard2; }
            set { _userControlCard2 = value; }
        }

        private UserControl _userControlCard3;

        public UserControl UserControlCard3
        {
            get { return _userControlCard3; }
            set { _userControlCard3 = value; }
        }

        private UserControl _userControlCard4;

        public UserControl UserControlCard4
        {
            get { return _userControlCard4; }
            set { _userControlCard4 = value; }
        }

        private UserControl _userControlAddButton;

        public UserControl UserControlAddButton
        {
            get { return _userControlAddButton; }
            set { _userControlAddButton = value; }
        }


        #endregion

        #region Commands
        public ICommand MouseEnterCommand { get; private set; }
        public ICommand MouseLeftButtonDownCommand { get; private set; }

        #endregion

        #region Constructors
        public ViewModelMain()
        {
            UserControlCard1 = new UserControlCard();
            UserControlCard1.DataContext = new ViewModelCard("First"
                                                             , new BitmapImage(new Uri("pack://application:,,,/Resources/loopy2_1.png"))
                                                             , new BitmapImage(new Uri("pack://application:,,,/Resources/loopy2_2.png")));

            UserControlCard2 = new UserControlCard();
            UserControlCard2.DataContext = new ViewModelCard("Second"
                                                             , new BitmapImage(new Uri("pack://application:,,,/Resources/loopy2_3.png"))
                                                             , new BitmapImage(new Uri("pack://application:,,,/Resources/loopy2_4.png")));

            UserControlCard3 = new UserControlCard();
            UserControlCard3.DataContext = new ViewModelCard("Third"
                                                             , new BitmapImage(new Uri("pack://application:,,,/Resources/loopy2_5.png"))
                                                             , new BitmapImage(new Uri("pack://application:,,,/Resources/loopy2_6.png")));

            UserControlCard4 = new UserControlCard();
            UserControlCard4.DataContext = new ViewModelCard("Fourth"
                                                             , new BitmapImage(new Uri("pack://application:,,,/Resources/loopy2_7.png"))
                                                             , new BitmapImage(new Uri("pack://application:,,,/Resources/loopy2_8.png")));

            UserControlAddButton = new UserControlAddButton();
            UserControlAddButton.DataContext = new ViewModelAddButton("Add New Room");

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
