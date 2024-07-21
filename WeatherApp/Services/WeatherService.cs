using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Models;
using System.Configuration;
using System.Collections.Specialized;

namespace WeatherApp.Services
{
    public class WeatherService
    {
        public readonly HttpClient _httpClient;
        private readonly string _api = ConfigurationManager.AppSettings.Get("api");

        public WeatherService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<WeatherModel> GetWeatherAsync(string cityName)
        {
            WeatherModel weatherData;
            string url = $"http://api.openweathermap.org/data/2.5/weather?q={cityName}&appid={this._api}&units=metric";
            var response = await _httpClient.GetStringAsync(url);
            if(!string.IsNullOrEmpty(response))
            {
                 weatherData = JsonConvert.DeserializeObject<WeatherModel>(response);
            }

            else
            {
                weatherData = JsonConvert.DeserializeObject<WeatherModel>(await _httpClient.GetStringAsync($"http://api.openweathermap.org/data/2.5/weather?q=London&appid={this._api}&units=metric"));
            }


            return weatherData;
        }
    }
}
