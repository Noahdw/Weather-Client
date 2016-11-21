using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using GraphApp.ViewModels;

namespace GraphApp.Services
{
    class WeatherAccess
    {
   
        string latitude = "32.806372";
        string longitude = "-116.998751";
        string key = "808457e6646d99056f3b9499282be5f8";
        string jsonData;
        //https://api.darksky.net/forecast/[key]/[latitude],[longitude]

        public RootObject getWeatherForecast()
        {
            string url = "https://api.darksky.net/forecast/" + key +"/" + latitude + "," + longitude + "?exclude=flags";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            WebResponse timeLineResponse = request.GetResponse();

            var timeLineJson = string.Empty;
            //Reads the response and deserializes into a list
            try
            {
                using (timeLineResponse)
                {
                    using (var reader = new StreamReader(timeLineResponse.GetResponseStream()))
                    {
                        jsonData = reader.ReadToEnd();
                    }

                  

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            RootObject root = new RootObject();

            root = JsonConvert.DeserializeObject<RootObject>(jsonData);
            return root;
            
            
            
        }

    }
}
