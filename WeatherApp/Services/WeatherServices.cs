using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Net.Http;
using Newtonsoft.Json;
using WeatherApp.Models;
using System.Configuration;

namespace WeatherApp.Services
{
    public class WeatherServices
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey = Environment.GetEnvironmentVariable("OPENWEATHER_API_KEY");

        public WeatherServices()
        {
            _httpClient = new HttpClient();
        }

        public async Task<WeatherResponse> GetWeatherAsync(string city)
        {
            string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={_apiKey}&units=metric";

            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode) return null;

            string json = await response.Content.ReadAsStringAsync();
            WeatherResponse weather = JsonConvert.DeserializeObject<WeatherResponse>(json);

            return weather;
        }


    }
}