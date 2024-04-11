using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using WeatherApp.Helpers;
using WeatherApp.Models;

namespace WeatherApp.ViewModels
{
    public class ViewModelMain : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region Properties
        private string _city = string.Empty;

        public string City
        {
            get { return _city; }
            set 
            {
                _city = value;
                OnPropertyChanged("City");
            }
        }

        public ObservableCollection<City> Cities { get; set; } = new ObservableCollection<City>();

        private CurrentConditions _currentConditions = new CurrentConditions();

        public CurrentConditions CurrentConditions
        {
            get { return _currentConditions; }
            set
            {
                _currentConditions = value;
                OnPropertyChanged("CurrentConditions");

                setImageRaining(_currentConditions.HasPrecipitation);
            }
        }

        private City _selectedCity = new City();

        public City SelectedCity
        {
            get { return _selectedCity; }
            set
            {
                _selectedCity = value;
                OnPropertyChanged("SelectedCity");

                GetCurrentConditions();
            }
        }

        private ImageSource _imageRaining;

        public ImageSource ImageRaining
        {
            get { return _imageRaining; }
            set 
            {
                _imageRaining = value;
                OnPropertyChanged(nameof(ImageRaining));
            }
        }

        private string currentTime;
        public string CurrentTime
        {
            get { return currentTime; }
            set
            {
                if (currentTime != value)
                {
                    currentTime = value;
                    OnPropertyChanged(nameof(CurrentTime));
                }
            }
        }

        #endregion



        #region Commands
        public ICommand SearchCommand => null ?? new RelayCommand(SearchEvent);
        
        #endregion



        #region Constructors
        public ViewModelMain()
        {
            UpdateTime();
        }
        #endregion



        #region Methods
        private async void GetCurrentConditions()
        {
            City = string.Empty;
            //Cities.Clear();

            CurrentConditions = await AccuWeatherHelper.GetCurrentConditions(SelectedCity.Key);
        }

        public async void MakeQuery()
        {
            var cities = await AccuWeatherHelper.GetCities(City);

            Cities.Clear();
            foreach (var city in cities)
            {
                Cities.Add(city);
            }
        }

        public void SearchEvent(object obj)
        {
            MakeQuery();
        }

        private void setImageRaining(bool isRaining)
        {
            if (isRaining)
            {
                ImageRaining = new BitmapImage(new Uri("pack://application:,,,/Resources/loopy2_7.png"));
            }
            else
            {
                ImageRaining = new BitmapImage(new Uri("pack://application:,,,/Resources/loopy2_9.png"));
            }
        }

        private void UpdateTime()
        {
            CurrentTime = DateTime.Now.ToString("HH:mm");

            var timer = new System.Windows.Threading.DispatcherTimer();
            timer.Interval = TimeSpan.FromMinutes(1);
            timer.Tick += (sender, args) =>
            {
                CurrentTime = DateTime.Now.ToString("HH:mm");
            };
            timer.Start();
        }

        #endregion
    }
}
