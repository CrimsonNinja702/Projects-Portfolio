using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather_App
{
    internal class WeatherInfo //Defining various classes for the relevant data
    {
        public class coord
        {
            public double lon { get; set; } // Method to collect the data and set it accordingly
            public double lat { get; set; }
        }
        public class weather
        {
            public string main { get; set; }
            public string description { get; set; }
            public string icon { get; set;}
        }
        public class main
        {
            public double temp { get; set; }
            public double humidity { get; set; }
            public double pressure { get; set; }
        }
        public class wind
        {
            public double speed { get; set; }
        }
        public class sys
        {
            public long sunrise { get; set; }
            public long sunset { get; set; }
        }
        public class root // Creates attributes of the classes
        {
            public coord coord { get; set; }
            public List <weather> weather { get; set; }
            public main main { get; set; }
            public wind wind { get; set; }
            public sys sys { get; set; }
        }
    }
}
