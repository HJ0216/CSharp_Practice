using ScrollButton.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Reflection.Metadata;
using System.ComponentModel;

namespace ScrollButton.ViewModels
{
    public class ViewModelMain : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region Properties
        private ImageSource _selectedImageSource;

        public ImageSource SelectedImageSource
        {
            get { return _selectedImageSource; }
            set 
            {
                _selectedImageSource = value;
                OnPropertyChanged(nameof(SelectedImageSource));
            }
        }

        private int _SelectedImageSourceIndex;

        public int SelectedImageSourceIndex
        {
            get { return _SelectedImageSourceIndex; }
            set { _SelectedImageSourceIndex = value; }
        }

        private ObservableCollection<ImageSource> _imageSources = new ObservableCollection<ImageSource>();

        public ObservableCollection<ImageSource> ImageSources
        {
            get { return _imageSources; }
            set { _imageSources = value; }
        }

        #endregion



        #region Commands
        public RelayCommand ScrollImageCommand => null ?? new RelayCommand(ScrollImageEvent);

        #endregion



        #region Constructors
        public ViewModelMain()
        {
            ImageSources = new ObservableCollection<ImageSource>
            {
                new BitmapImage(new Uri("pack://application:,,,/Resources/number0.png"))
                , new BitmapImage(new Uri("pack://application:,,,/Resources/number1.png"))
                , new BitmapImage(new Uri("pack://application:,,,/Resources/number2.png"))
                , new BitmapImage(new Uri("pack://application:,,,/Resources/number3.png"))
                , new BitmapImage(new Uri("pack://application:,,,/Resources/number4.png"))
                , new BitmapImage(new Uri("pack://application:,,,/Resources/number5.png"))
                , new BitmapImage(new Uri("pack://application:,,,/Resources/number6.png"))
                , new BitmapImage(new Uri("pack://application:,,,/Resources/number7.png"))
                , new BitmapImage(new Uri("pack://application:,,,/Resources/number8.png"))
                , new BitmapImage(new Uri("pack://application:,,,/Resources/number9.png"))
            };

            SelectedImageSource = ImageSources[0];
        }

        #endregion



        #region Methods
        private void ScrollImageEvent(object obj)
        {
            if (obj is ListView listView)
            {
                var scrollViewer = FindScrollViewer(listView);

                if (scrollViewer != null)
                {
                    int middlePositionIndex = 2; // 중앙에 위치시키고자 하는 인덱스
                    double newHorizontalOffset = SelectedImageSourceIndex - middlePositionIndex;

                    scrollViewer.ScrollToHorizontalOffset(newHorizontalOffset);
                    scrollViewer.UpdateLayout();
                }
            }
        }

        private ScrollViewer FindScrollViewer(DependencyObject dependencyObject)
        {
            if (dependencyObject is ScrollViewer)
            {
                return dependencyObject as ScrollViewer;
            }

            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(dependencyObject); i++)
            {
                var child = VisualTreeHelper.GetChild(dependencyObject, i);
                var scrollViewerInListView = FindScrollViewer(child);
                if (scrollViewerInListView != null)
                {
                    return scrollViewerInListView;
                }
            }

            return null;
        }

        #endregion
    }
}
