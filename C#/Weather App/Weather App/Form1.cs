// Copied tutorial from https://www.youtube.com/watch?v=zW26MZBV-9o&list=PL6A_3faIhQVsoea-iclL9JFPGpdci6JPW&index=5 to learn the concepts

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json; // Allows users to serialize .NET into JSON and vice versa
using System.Net;

namespace Weather_App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        string APIKey = "d2799acd565d7c09ed175a1c33dd6e13";

        private void btnSearch_Click(object sender, EventArgs e)
        {
            getWeather();
        }

        private void lblSunrise_Click(object sender, EventArgs e)
        {

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void lblCondition_Click(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        void getWeather()
        {
            using (WebClient web = new WebClient()) //  Provides common methods for sending data to or receiving data from any local, intranet, or Internet resource identified by a URI
            {
                string url = string.Format("https://api.openweathermap.org/data/2.5/weather?q={0}&appid={1}", TBCity.Text, APIKey); // Dynamically adding in the city name from the search box and the API key to the url
                var json = web.DownloadString(url); // Downloads the information into a JSON file format
                WeatherInfo.root Info = JsonConvert.DeserializeObject<WeatherInfo.root>(json); // Referencing the root class on the WeatherInfo page, and then converts the object into a string JSON format

                picIcon.ImageLocation = "https://openweathermap.org/img/w/" + Info.weather[0].icon + ".png"; // Finding the image based on dynamic URL using the weather's list to access the specific value
                lblCondition.Text = Info.weather[0].main; // Main weather for the day
                lblDetails.Text = Info.weather[0].description; // Description of weather
                lblSunrise.Text = convertDateTime(Info.sys.sunrise).ToShortTimeString(); // Using .ToString() from here and below as the values must be converted
                lblSunset.Text = convertDateTime(Info.sys.sunset).ToShortTimeString();
                lblWindSpeed.Text = Info.wind.speed.ToString();
                lblPressure.Text = Info.main.pressure.ToString();
            }
        }

        DateTime convertDateTime(long seconds)
        {
            DateTime day = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc).ToLocalTime(); // Using this date as the API uses 1970/01/01 as its reference data
            day = day.AddSeconds(seconds).ToLocalTime();

            return day;
        }
    }
}
