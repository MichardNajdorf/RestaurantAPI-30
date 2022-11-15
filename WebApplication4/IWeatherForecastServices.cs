using System.Collections.Generic;

namespace WebApplication4
{
    public interface IWeatherForecastServices
    {
       
        IEnumerable<WeatherForecast> Get(int count, int MinTemperature, int MaxTemperature);
    }
}