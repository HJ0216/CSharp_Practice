using SmartHomeApp.Helpers;
using SmartHomeApp.Views.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata;
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
        private UserControl _userControlCard11;

        public UserControl UserControlCard11
        {
            get { return _userControlCard11; }
            set { _userControlCard11 = value; }
        }

        private UserControl _userControlCard12;

        public UserControl UserControlCard12
        {
            get { return _userControlCard12; }
            set { _userControlCard12 = value; }
        }

        private UserControl _userControlCard13;

        public UserControl UserControlCard13
        {
            get { return _userControlCard13; }
            set { _userControlCard13 = value; }
        }

        private UserControl _userControlCard14;

        public UserControl UserControlCard14
        {
            get { return _userControlCard14; }
            set { _userControlCard14 = value; }
        }

        private UserControl _userControlCard21;

        public UserControl UserControlCard21
        {
            get { return _userControlCard21; }
            set { _userControlCard21 = value; }
        }

        private UserControl _userControlCard22;

        public UserControl UserControlCard22
        {
            get { return _userControlCard22; }
            set { _userControlCard22 = value; }
        }

        private UserControl _userControlCard23;

        public UserControl UserControlCard23
        {
            get { return _userControlCard23; }
            set { _userControlCard23 = value; }
        }

        private UserControl _userControlCard24;

        public UserControl UserControlCard24
        {
            get { return _userControlCard24; }
            set { _userControlCard24 = value; }
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
            UserControlCard11 = new UserControlCard();
            UserControlCard11.DataContext = new ViewModelCard("First"
                                                             , new BitmapImage(new Uri("pack://application:,,,/Resources/loopy2_1.png"))
                                                             , new BitmapImage(new Uri("pack://application:,,,/Resources/loopy2_2.png"))
                                                             , false);
            UserControlCard21 = new UserControlCard();
            UserControlCard21.DataContext = new ViewModelCard("First"
                                                             , new BitmapImage(new Uri("pack://application:,,,/Resources/loopy2_1.png"))
                                                             , new BitmapImage(new Uri("pack://application:,,,/Resources/loopy2_2.png"))
                                                             , true);

            UserControlCard12 = new UserControlCard();
            UserControlCard12.DataContext = new ViewModelCard("Second"
                                                             , new BitmapImage(new Uri("pack://application:,,,/Resources/loopy2_3.png"))
                                                             , new BitmapImage(new Uri("pack://application:,,,/Resources/loopy2_4.png"))
                                                             , false);
            UserControlCard22 = new UserControlCard();
            UserControlCard22.DataContext = new ViewModelCard("Second"
                                                             , new BitmapImage(new Uri("pack://application:,,,/Resources/loopy2_3.png"))
                                                             , new BitmapImage(new Uri("pack://application:,,,/Resources/loopy2_4.png"))
                                                             , true);

            UserControlCard13 = new UserControlCard();
            UserControlCard13.DataContext = new ViewModelCard("Third"
                                                             , new BitmapImage(new Uri("pack://application:,,,/Resources/loopy2_5.png"))
                                                             , new BitmapImage(new Uri("pack://application:,,,/Resources/loopy2_6.png"))
                                                             , false);
            UserControlCard23 = new UserControlCard();
            UserControlCard23.DataContext = new ViewModelCard("Third"
                                                             , new BitmapImage(new Uri("pack://application:,,,/Resources/loopy2_5.png"))
                                                             , new BitmapImage(new Uri("pack://application:,,,/Resources/loopy2_6.png"))
                                                             , true);

            UserControlCard14 = new UserControlCard();
            UserControlCard14.DataContext = new ViewModelCard("Fourth"
                                                             , new BitmapImage(new Uri("pack://application:,,,/Resources/loopy2_7.png"))
                                                             , new BitmapImage(new Uri("pack://application:,,,/Resources/loopy2_8.png"))
                                                             , false);
            UserControlCard24 = new UserControlCard();
            UserControlCard24.DataContext = new ViewModelCard("Fourth"
                                                             , new BitmapImage(new Uri("pack://application:,,,/Resources/loopy2_7.png"))
                                                             , new BitmapImage(new Uri("pack://application:,,,/Resources/loopy2_8.png"))
                                                             , true);

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
