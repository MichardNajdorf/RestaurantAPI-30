using System.Collections.Generic;
using System.Linq;
using System;
using WebApplication4;

namespace WebApplication4
{
    public class WeatherForecastServices : IWeatherForecastServices
    {


        private static readonly string[] Summaries = new[]
{
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public IEnumerable<WeatherForecast> Get(int count,int MinTemperature,int MaxTemperature)
        {
            var rng = new Random();
            return Enumerable.Range(1, count).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(MinTemperature,MaxTemperature),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
