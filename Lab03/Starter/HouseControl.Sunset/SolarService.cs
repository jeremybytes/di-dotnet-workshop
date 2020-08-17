using System;
using System.Net;

namespace HouseControl.Sunset
{
    public interface ISolarService
    {
        string GetServiceData(DateTime date);
    }

    public class SolarService : ISolarService
    {
        WebClient client = new WebClient();
        string baseUri = "http://localhost:8973/";


        public string GetServiceData(DateTime date)
        {
            var address = $"{baseUri}api/SolarCalculator/33.7676/-84.5606/{date:yyyy-MM-dd}";
            string reply = client.DownloadString(address);
            return reply;
        }
    }
}
