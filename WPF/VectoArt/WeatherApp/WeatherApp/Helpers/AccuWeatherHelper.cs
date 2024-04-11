using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.Helpers
{
    public class AccuWeatherHelper
    {
        public const string BASE_URL = "http://dataservice.accuweather.com/";
        public const string AUTO_COMPLETE_ENDPOINT = "locations/v1/cities/autocomplete?apikey={0}&q={1}";
        public const string CURRENT_CONDITIONS_ENDPOINT = "currentconditions/v1/{0}?apikey={1}";
        public const string API_KEY = "39YxJNsXNUrkXnAFyfe7mx5jDlUdotkO";

        public static async Task<List<City>> GetCities(string city)
        // This is commonly used in asynchronous programming in C# to handle tasks that may take some time to complete,
        // such as reading from a network stream, accessing a database, or performing I/O operations, without blocking the main thread of execution.
        {
            List<City> cities = new List<City>();
            string url = BASE_URL + string.Format(AUTO_COMPLETE_ENDPOINT, API_KEY, city);
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                string json = await response.Content.ReadAsStringAsync();

                cities = JsonConvert.DeserializeObject<List<City>>(json);
            }

            return cities;
        }

        public static async Task<CurrentConditions> GetCurrentConditions(string citykey)
        {
            CurrentConditions currentConditions = new CurrentConditions();

            string url = BASE_URL + string.Format(CURRENT_CONDITIONS_ENDPOINT, citykey, API_KEY);

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                string json = await response.Content.ReadAsStringAsync();

                currentConditions = JsonConvert.DeserializeObject<List<CurrentConditions>>(json).FirstOrDefault();
            }

            return currentConditions;
        }
    }
}
