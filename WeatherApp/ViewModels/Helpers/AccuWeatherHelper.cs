using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.ViewModels.Helpers
{
    public class AccuWeatherHelper
    {
        public const string BASE_URL = "http://dataservice.accuweather.com/";
        public const string AUTO_COMPLETE_ENDPOINT = "locations/v1/cities/autocomplete?apikey={0}&q={1}";
        public const string CURRENT_CONDITIONS_ENDPOINT = "currentconditions/v1/{0}?apikey={1}";
        public const string API_KEY = "";

        public static async Task<List<City>> GetCities(string query)
        // Task<string> represents a promise (or a future) that eventually resolves to a `string` value once the asynchronous operation completes.
        // This is commonly used in asynchronous programming in C# to handle tasks that may take some time to complete,
        // such as reading from a network stream, accessing a database, or performing I/O operations, without blocking the main thread of execution.
        {
            List<City> cities = new List<City>();
            string url = BASE_URL + string.Format(AUTO_COMPLETE_ENDPOINT, API_KEY, query);
            // string.format: 자리 표시자({0}, {1})에 값을 대입할 수 있는 결합 방식
            using(HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                string json = await response.Content.ReadAsStringAsync();
                // ReadAsStringAsync()
                // It asynchronously reads the content of the HTTP response as a string.
                // It returns a Task<string>, which represents the asynchronous operation of reading the content as a string.

                cities = JsonConvert.DeserializeObject<List<City>>(json);
                // This method is used to deserialize JSON data into an object of a specified type (`T`).
                // In this case, `List<City>` is specified as the type parameter `T`,
                // indicating that the JSON data will be deserialized into a list of `City` objects.
            }

            return cities;
        }

        public static async Task<CurrentConditions> GetCurrentConditions(string citykey)
        {
            CurrentConditions currentConditions = new CurrentConditions();

            string url = BASE_URL + string.Format(CURRENT_CONDITIONS_ENDPOINT, citykey, API_KEY);

            using(HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                string json = await response.Content.ReadAsStringAsync();

                currentConditions = (JsonConvert.DeserializeObject<List<CurrentConditions>>(json)).FirstOrDefault();
            }

            return currentConditions;
        }
    }
}
