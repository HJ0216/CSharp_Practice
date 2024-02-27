using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Models;
using WeatherApp.ViewModels.Commands;
using WeatherApp.ViewModels.Helpers;

namespace WeatherApp.ViewModels
{
    public class WeatherVM : INotifyPropertyChanged
    {
		private string _query;

		public string Query
		{
			get { return _query; }
			set 
			{ 
				_query = value;
				OnPropertyChanged("Query");
                // This is used to notify any subscribers that the value of the Query property has changed.
            }
        }
        public ObservableCollection<City> Cities{ get; set; }

        private CurrentConditions _currentConditions;

		public CurrentConditions CurrentConditions
        {
			get { return _currentConditions; }
			set 
			{ 
				_currentConditions = value;
				OnPropertyChanged("CurrentConditions");
			}
		}

        private City _selectedCity;

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

        public SearchCommand SearchCommand{ get; set; }

        public WeatherVM()
        {
			if(DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject()))
            // whether the application is currently running in design mode
            {
                SelectedCity = new City
                {
                    LocalizedName = "Seoul"
                };

                CurrentConditions = new CurrentConditions
                {
                    WeatherText = "Clear",
                    Temperature = new Temperature
                    {
                        Metric = new Units
                        {
                            Value = "0"
                        }
                    }
                };
            }

            SearchCommand = new SearchCommand(this);
            Cities = new ObservableCollection<City>();
        }

        private async void GetCurrentConditions()
        {
            Query = string.Empty;
            Cities.Clear();

            CurrentConditions = await AccuWeatherHelper.GetCurrentConditions(SelectedCity.Key);
        }

        public async void MakeQuery()
        {
            var cities = await AccuWeatherHelper.GetCities(Query);

            Cities.Clear();
            foreach(var city in cities)
            {
                Cities.Add(city);
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        // PropertyChangedEventHandler: This event is raised when a property value changes.

        private void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            // When a property's value changes, the `OnPropertyChanged` method is called, which in turn invokes the `PropertyChanged` event.
            // This notifies any subscribed event handlers that a property has changed,
            // providing information about which property has changed (`propertyName`) and who raised the event (`this(=the current instance of the WeatherVM class)`).
            // The subscriber to the `PropertyChanged` event is typically the UI component that is bound to the property of the data object
        }

    }
}
