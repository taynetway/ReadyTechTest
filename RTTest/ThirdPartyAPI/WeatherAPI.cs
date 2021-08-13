using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebApp.ThirdPartyAPI
{

    public class WeatherAPI : IWeatherAPI {

        public string City { get; set; } 
        public string  ApiCode { get; set; }

        public WeatherAPI()
        {
            City = "saigon";
            ApiCode  = "74ceab6a63e871c6e3908970c5a07bb4";
        }

        public async Task<float> GetTemperature() {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://api.openweathermap.org");
            var response = await client.GetAsync($"/data/2.5/weather?q={City}&appid={ApiCode}");
            response.EnsureSuccessStatusCode();
            var stringResult = await response.Content.ReadAsStringAsync();
            var rawWeather = JsonConvert.DeserializeObject<OpenWeatherResponse>(stringResult);
            float temp = float.Parse(rawWeather.Main.Temp);
            //change to Cencius degree
            temp = (float)(temp - 273.15);
            return temp;  
        }
    }

    public class OpenWeatherResponse
    {
        public string Name { get; set; }

        public IEnumerable<WeatherDescription> Weather { get; set; }

        public Main Main { get; set; }
    }

    public class WeatherDescription
    {
        public string Main { get; set; }
        public string Description { get; set; }
    }

    public class Main
    {
        public string Temp { get; set; }
    }
}
