using GraphApp.MVVM;
using GraphApp.Services;
using GraphApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GraphApp.ViewModels
{
    public class HomeViewModel : ObservableObject, IPageViewModel
    {
        public HomeViewModel()
        {
            DailyList = new ObservableCollection<RootObject>();
            WeatherAccess weather = new WeatherAccess();
            DailyList.Add(weather.getWeatherForecast());
            Name = "7 Day";
        }

        private ICommand _displayHourlyView;
        private ObservableCollection<RootObject> _dailyList;
        
        public ObservableCollection<RootObject> DailyList
        {
            get { return _dailyList; }
            set
            {
                if (value != _dailyList)
                {
                    _dailyList = value;
                    NotifyPropertyChanged("DailyList");
                }
            }
        }
        public static DateTime UnixTimeStampToDateTime(int unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }

        public ICommand DisplayHourlyView
        {
            get
            {
                if (_displayHourlyView == null)
                {
                    _displayHourlyView = new RelayCommand(
                        param => displayView(),
                        param => (true)
                    );
                }

                return _displayHourlyView;
            }
        }

        public void displayView()
        {

        }

        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set {
                _name = value;
            }
        }
        
    }
    #region RootObject weather

    public class Currently
    {
        public int time { get; set; }
        public string summary { get; set; }
        public string icon { get; set; }
        public int nearestStormDistance { get; set; }
        public int nearestStormBearing { get; set; }
        public double precipIntensity { get; set; }
        public double precipProbability { get; set; }
        public double temperature { get; set; }
        public double apparentTemperature { get; set; }
        public double dewPoint { get; set; }
        public double humidity { get; set; }
        public double windSpeed { get; set; }
        public int windBearing { get; set; }
        public double visibility { get; set; }
        public double cloudCover { get; set; }
        public double pressure { get; set; }
        public double ozone { get; set; }
    }

    public class Datum
    {
        public int time { get; set; }
        public float precipIntensity { get; set; }
        public float precipProbability { get; set; }
    }

    public class Minutely
    {
        public string summary { get; set; }
        public string icon { get; set; }
        public List<Datum> data { get; set; }
    }

    public class Datum2
    {
        private double _temperature;
        private string _icon;
        private int _time;
        private double _humidity;
        private double _windSpeed;
        public int time {
            get { return _time; }
            set
            {
                _time = value;

                DateTime dt = HomeViewModel.UnixTimeStampToDateTime(value);
                DateTime hour = DateTime.Now;

                if (dt.Hour == hour.Hour)
                {
                    timeOfDay = "Now";
                }
                else
                {
                    timeOfDay = dt.ToString("hh:tt");
                }
            }
        }
        public string summary { get; set; }
        public string icon
        {
            get { return _icon; }
            set
            {
                _icon = value;
                imageIconPath = "pack://application:,,,/Media/" + icon + ".png";
            }
        }
        public double precipIntensity { get; set; }
        public double precipProbability { get; set; }
        public double temperature
        {
            get { return _temperature; }
            set
            {
                _temperature = Math.Round(value, 0);

            }
        }
        public double apparentTemperature { get; set; }
        public double dewPoint { get; set; }
        public double humidity
        {
            get { return _humidity; }
            set { _humidity = value * 100; }
        }
        public double windSpeed
        {  
            get { return _windSpeed; }
            set { }
            
        }
        public int windBearing { get; set; }
        public double visibility { get; set; }
        public double cloudCover { get; set; }
        public double pressure { get; set; }
        public double ozone { get; set; }
        public string precipType { get; set; }
        public string timeOfDay { get; set; }
        public string imageIconPath { get; set; }
    }

    public class Hourly
    {
        public string summary { get; set; }
        public string icon { get; set; }
        public List<Datum2> data { get; set; }
    }

    public class Datum3
    {
        private double _temperatureMin;
        private double _temperatureMax;
        private int _time;
        private string _icon;
        public int time
        {
            get { return _time; }
            set {
                _time = value;
                
                DateTime dt = HomeViewModel.UnixTimeStampToDateTime(value);
                DateTime today = DateTime.Now;
                
                if (dt.DayOfYear == today.DayOfYear )
                {
                    dayOfWeek = "Today";
                }
                else
                {
                    dayOfWeek = dt.DayOfWeek.ToString();
                }
            }
        }
        public string summary { get; set; }
        public string icon
        {
            get { return _icon; }
            set {
                _icon = value;
                imageIconPath = "pack://application:,,,/Media/" + icon + ".png";
            }
        }
        public int sunriseTime { get; set; }
        public int sunsetTime { get; set; }
        public double moonPhase { get; set; }
        public double precipIntensity { get; set; }
        public double precipIntensityMax { get; set; }
        public int precipIntensityMaxTime { get; set; }
        public double precipProbability { get; set; }
        public string precipType { get; set; }
        public double temperatureMin
        {
            get { return _temperatureMin; }
            set
            {
                _temperatureMin = Math.Round(value, 0);
         
            }
        }
        public int temperatureMinTime { get; set; }
        public double temperatureMax
        {
            get { return _temperatureMax; }
            set
            {
                _temperatureMax = Math.Round(value, 0);

            }
        }
        public int temperatureMaxTime { get; set; }
        public double apparentTemperatureMin { get; set; }
        public int apparentTemperatureMinTime { get; set; }
        public double apparentTemperatureMax { get; set; }
        public int apparentTemperatureMaxTime { get; set; }
        public double dewPoint { get; set; }
        public double humidity { get; set; }
        public double windSpeed { get; set; }
        public int windBearing { get; set; }
        public double visibility { get; set; }
        public double cloudCover { get; set; }
        public double pressure { get; set; }
        public double ozone { get; set; }
        public string dayOfWeek { get; set; }
        public string imageIconPath { get; set; }

    }

    public class Daily
    {
        public string summary { get; set; }
        public string icon { get; set; }
        public List<Datum3> data { get; set; }
    }

    public class Alert
    {
        public string title { get; set; }
        public int time { get; set; }
        public int expires { get; set; }
        public string description { get; set; }
        public string uri { get; set; }
    }

    public class RootObject
{
        public RootObject()
        {

        }
    public double latitude { get; set; }
    public double longitude { get; set; }
    public string timezone { get; set; }
    public int offset { get; set; }
    public Currently currently { get; set; }
    public Minutely minutely { get; set; }
    public Hourly hourly { get; set; }
    public Daily daily { get; set; }
    public List<Alert> alerts { get; set; }

}
    #endregion

    public class HourlyView : HomeViewModel {
        public HourlyView()
        {
            Name = "Hourly";
        }
    }

  
}
