using MessagingToolkit.QRCode.Codec;
using MessagingToolkit.QRCode.Codec.Data;
using Microsoft.Win32;
using QRCode.Converters;
using QRCode.Helpers;
using QRCode.Models;
using QRCode.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

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

        private ImageSource _imageQr;

        public ImageSource ImageQr
        {
            get { return _imageQr; }
            set 
            {
                _imageQr = value;
                OnPropertyChange(nameof(ImageQr));
            }
        }

        public Bitmap bitmap;


        private ImageSource _imageScanQr;

        public ImageSource ImageScanQr
        {
            get { return _imageScanQr; }
            set
            {
                _imageScanQr = value;
                OnPropertyChange(nameof(ImageScanQr));
            }
        }

        private string _textScanQr = string.Empty;

        public string TextScanQr
        {
            get { return _textScanQr; }
            set 
            {
                _textScanQr = value;
                OnPropertyChange(nameof(TextScanQr));
            }
        }

        #endregion



        #region Commands
        public ICommand WindowDragCommand => null ?? new RelayCommand(WindowDragEvent);
        public ICommand ApplicationShutDownCommand => null ?? new RelayCommand(ApplicationShutDownEvent);
        public ICommand ChangeTabCommand => null ?? new RelayCommand(ChangeTabEvent);
        public ICommand CreateQRCommand => null ?? new RelayCommand(CreateQREvent);
        public ICommand SaveQRCommand => null ?? new RelayCommand(SaveQREvent);
        public ICommand ScanQRCommand => null ?? new RelayCommand(ScanQREvent);

        

        #endregion



        #region Constructors
        public ViewModelMain()
        {
            MenuModels = new ObservableCollection<MenuModel>()
            {
                new MenuModel("Create QR", "Qrcode")
                , new MenuModel("Scan QR", "QrcodeEdit")
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

        private void ChangeTabEvent(object param)
        {
            if(param is MenuModel)
            {
                string title = (param as MenuModel).Title;

                switch (title)
                {
                    case "Create QR":
                        CurrentView = new UserControlCreateQR();
                        CurrentView.DataContext = this;
                        break;
                    case "Scan QR":
                        CurrentView = new UserControlScanQR();
                        CurrentView.DataContext = this;
                        break;
                    default:
                        CurrentView = new UserControlCreateQR();
                        CurrentView.DataContext = this;
                        break;
                }
            }
            Console.WriteLine(param.ToString());
        }


        private void CreateQREvent(object obj)
        {
            QRCodeEncoder qRCodeEncoder = new QRCodeEncoder();
            qRCodeEncoder.QRCodeScale = 8;

            bitmap = qRCodeEncoder.Encode(TextQr);
            ImageQr = Converters.ImageConverter.ToBitmapImage(bitmap);
        }

        private void SaveQREvent(object obj)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PNG|*.png";
            saveFileDialog.FileName = TextQr;

            if(saveFileDialog.ShowDialog() == true)
            {
                if(bitmap != null)
                {
                    bitmap.Save(saveFileDialog.FileName, ImageFormat.Png);
                }
            }
        }

        private void ScanQREvent(object obj)
        {
            QRCodeDecoder qRCodeDecoder = new QRCodeDecoder();
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if(openFileDialog.ShowDialog() == true)
            {
                ImageScanQr = new BitmapImage(new Uri(openFileDialog.FileName));
                TextScanQr = qRCodeDecoder.Decode(new QRCodeBitmapImage(new Bitmap(openFileDialog.FileName)));
            }
        }


        #endregion
    }
}
