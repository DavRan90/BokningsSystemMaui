using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BokningsSystemMaui
{
    public class WeatherDataManager
    {
        public static async Task<Models.Weather> GetWeather(string uri)
        {
            var client = new HttpClient();

            client.BaseAddress = new Uri("https://api.api-ninjas.com/");
            client.DefaultRequestHeaders.Add("X-Api-Key", "8DweuqCST19TaRueXokhIw==mrV2c4m3q5TINEAA");

            Models.Weather weather = null;

            HttpResponseMessage response = await client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                string responseString = await response.Content.ReadAsStringAsync();
                weather = JsonSerializer.Deserialize<Models.Weather>(responseString);
            }

            return weather;
        }
    }
}
