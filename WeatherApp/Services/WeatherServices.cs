using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Net.Http;
using Newtonsoft.Json;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    public class WeatherServices
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey = "API_KEY";

        public WeatherServices()
        {
            _httpClient = new HttpClient();
        }

        public async Task<WeatherResponse> ObtenerClimaPorCiudadAsync(string ciudad)
        {
            string url = $"https://api.openweathermap.org/data/2.5/weather?q={ciudad}&appid={_apiKey}&units=metric";

            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode) return null;

            string json = await response.Content.ReadAsStringAsync();
            WeatherResponse clima = JsonConvert.DeserializeObject<WeatherResponse>(json);

            return clima;
        }


    }
}