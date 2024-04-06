using ScrollButton.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace ScrollButton.ViewModels
{
    public class ViewModelImageViewer
    {
        #region Properties
        private ImageSource _selectedImageSource;

        public ImageSource SelectedImageSource
        {
            get { return _selectedImageSource; }
            set { _selectedImageSource = value; }
        }

        #endregion

        #region Commands
        public RelayCommand CloseWindowCommand => null ?? new RelayCommand(CloseWindowEvent);



        #endregion

        #region Constructors
        public ViewModelImageViewer(ImageSource selectedImageSource)
        {
            SelectedImageSource = selectedImageSource;
        }
        #endregion

        #region Methods
        private void CloseWindowEvent(object parameter)
        {
            Window window = parameter as Window;
            window.Close();
        }

        #endregion
    }
}
