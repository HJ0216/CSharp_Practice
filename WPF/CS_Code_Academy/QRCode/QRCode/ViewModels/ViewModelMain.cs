using MessagingToolkit.QRCode.Codec;
using MessagingToolkit.QRCode.Codec.Data;
using QRCode.Helpers;
using QRCode.Models;
using QRCode.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace QRCode.ViewModels
{
    public class ViewModelMain : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChange(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

        #endregion



        #region Properties
        private ObservableCollection<MenuModel> _menuModels = new ObservableCollection<MenuModel>();

        public ObservableCollection<MenuModel> MenuModels
        {
            get { return _menuModels; }
            set { _menuModels = value; }
        }

        private UserControl _currentView;
        /// <summary>
        /// 현재 UserControl
        /// </summary>
        public UserControl CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChange(nameof(CurrentView));
            }
        }

        private string _textQr;

        public string TextQr
        {
            get { return _textQr; }
            set { _textQr = value; }
        }


        #endregion



        #region Commands
        public ICommand WindowDragCommand => null ?? new RelayCommand(WindowDragEvent);
        public ICommand ApplicationShutDownCommand => null ?? new RelayCommand(ApplicationShutDownEvent);
        public ICommand CreateQRCommand => null ?? new RelayCommand(CreateQREvent);
        public ICommand SaveQRCommand => null ?? new RelayCommand(SaveQREvent);

        #endregion



        #region Constructors
        public ViewModelMain()
        {
            MenuModels = new ObservableCollection<MenuModel>()
            {
                new MenuModel("Create QR", "Qrcode")
                , new MenuModel("Edit QR", "QrcodeEdit")
                , new MenuModel("Access Point", "AccessPointSuccess")
            };

            CurrentView = new UserControlCreateQR();
            CurrentView.DataContext = this;
        }
        #endregion



        #region Methods
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

        private void CreateQREvent(object obj)
        {
            QRCodeEncoder qRCodeEncoder = new QRCodeEncoder();
            qRCodeEncoder.QRCodeScale = 8;

            Bitmap bitmap = qRCodeEncoder.Encode(TextQr);
        }

        private void SaveQREvent(object obj)
        {
            throw new NotImplementedException();
        }



        #endregion
    }
}
