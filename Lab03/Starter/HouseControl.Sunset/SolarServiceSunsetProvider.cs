using System;
using Newtonsoft.Json;

namespace HouseControl.Sunset
{
    public class SolarServiceSunsetProvider : ISunsetProvider
    {
        private ISolarService service;

        public ISolarService Service
        {
            get
            {
                if (service == null)
                    service = new SolarService();
                return service;
            }
            set { service = value; }
        }

        public DateTimeOffset GetSunrise(DateTime date)
        {
            string serviceData = Service.GetServiceData(date);
            string sunriseTimeString = ParseSunriseTime(serviceData);
            DateTime sunriseTime = ToLocalTime(sunriseTimeString, date);
            return new DateTimeOffset(sunriseTime);
        }

        public DateTimeOffset GetSunset(DateTime date)
        {
            string serviceData = Service.GetServiceData(date);
            string sunsetTimeString = ParseSunsetTime(serviceData);
            DateTime sunsetTime = ToLocalTime(sunsetTimeString, date);
            return new DateTimeOffset(sunsetTime);
        }

        public static DateTime ToLocalTime(string inputTime, DateTime date)
        {
            DateTime time = DateTime.Parse(inputTime);
            DateTime result = date.Date + time.TimeOfDay;
            return result;
        }

        public static string ParseSunsetTime(string jsonData)
        {
            dynamic data = JsonConvert.DeserializeObject(jsonData);
            string sunsetTimeString = data.results.sunset;
            return sunsetTimeString;
        }

        public static string ParseSunriseTime(string jsonData)
        {
            dynamic data = JsonConvert.DeserializeObject(jsonData);
            return data.results.sunrise;
        }
    }
}
