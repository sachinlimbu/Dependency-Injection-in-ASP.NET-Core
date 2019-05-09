using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TennisBookings.Services
{
    public class WeatherForecaster
    {
        // Pretend we call out to a remote 3rd party API here to get the real forecast!
        // For demo purposes, the result is hard-coded.
        public WeatherResult GetCurrentWeather()
        {
            return new WeatherResult
            {
                WeatherCondition = WeatherCondition.Sun
            };
        }


    }
}
