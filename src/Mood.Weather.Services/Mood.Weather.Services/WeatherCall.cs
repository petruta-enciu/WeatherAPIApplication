using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mood.Weather.Services
{

    public class WeatherCall
    {
        public static String GetCity(string country, string city)
        {
            
            return  (country + "/"+city);
        }

    }
}
