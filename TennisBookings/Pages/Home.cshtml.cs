using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using TennisBookings.Configuration;
using TennisBookings.Models.ViewModels;
using TennisBookings.Services;

namespace TennisBookings.Pages
{
    public class HomeModel : PageModel
    {
        private readonly IWeatherForecaster _weatherForecaster;
        private readonly IOptions<FeaturesConfiguration> _featuresConfiguration;

        public HomeViewModel HomeView { get; set; }

        public HomeModel(IWeatherForecaster weatherForecaster, IOptions<FeaturesConfiguration> options)
        {
            HomeView = new HomeViewModel();
            this._weatherForecaster = weatherForecaster;
            this._featuresConfiguration = options;
        }

        public void OnGet()
        {
            //var viewModel = new HomeViewModel();
            //var weatherForecaster = new WeatherForecaster();


            if (_featuresConfiguration.Value.EnableWeatherForecast)
            {
                var currentWeather = _weatherForecaster.GetCurrentWeather();

                HomeView.DisplayWeatherForecast = true;

                switch (currentWeather.WeatherCondition)
                {
                    case WeatherCondition.Sun:
                        HomeView.WeatherDescription = "It's sunny right now. " +
                                                       "A great day for tennis.";
                        break;
                    case WeatherCondition.Rain:
                        HomeView.WeatherDescription = "We're sorry but it's raining " +
                                                       "here. No outdoor courts in use.";
                        break;
                    default:
                        HomeView.WeatherDescription = "We don't have the latest weather " +
                                                       "information right now, please check again later.";
                        break;
                }
            }
        }
    }
}