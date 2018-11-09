using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral
{
    public interface IObservable
    {
        void RegisterObserver(IObserver observer);
        void UnregisterObserver(IObserver observer);
        void NotifyObservers();
    }
    public interface IObserver
    {
        void Update(float temp, float humidity, float pressure);
    }

    public class WeatherData : IObservable
    {
        List<IObserver> observers=new List<IObserver>();
        private float _temp, _humidity, _pressure;

        public void ChangeWeatherData(float temp, float humidity, float pressure)
        {
            this._temp = temp;
            this._humidity = humidity;
            this._pressure = pressure;
            NotifyObservers();
        }

        public void NotifyObservers()
        {
            foreach (var observer in observers)
            {
                observer.Update(_temp, _humidity, _pressure);
            }
        }

        public void RegisterObserver(IObserver observer)
        {
            observers.Add(observer);
        }

        public void UnregisterObserver(IObserver observer)
        {
            observers.Remove(observer);
        }
    }

    public class CurrentWeather : IObserver
    {
        private readonly WeatherData _wd;
        public CurrentWeather(WeatherData weatherData)
        {
            this._wd = weatherData;
            this._wd.RegisterObserver(this);
        }
        public void Update(float temp, float humidity, float pressure)
        {
            Display(temp, humidity, pressure);
        }

        private void Display(float temp, float humidity, float pressure)
        {
            Console.WriteLine($"Current weather data: Temp= {temp}, Humidity= {humidity} and Pressure= {pressure}");
        }
    }

    public class ForecastWeather : IObserver
    {
        private readonly WeatherData _wd;
        public ForecastWeather(WeatherData weatherData)
        {
            this._wd = weatherData;
            this._wd.RegisterObserver(this);
        }
        public void Update(float temp, float humidity, float pressure)
        {
            Display(temp, humidity, pressure);
        }

        private void Display(float temp, float humidity, float pressure)
        {
            Console.WriteLine($"Forecast weather data: Temp= {temp}, Humidity= {humidity} and Pressure= {pressure}");
        }
    }

    public class StatisticsWeather : IObserver
    {
        private readonly WeatherData _wd;
        public StatisticsWeather(WeatherData weatherData)
        {
            this._wd = weatherData;
            this._wd.RegisterObserver(this);
        }
        public void Update(float temp, float humidity, float pressure)
        {
            Display(temp, humidity, pressure);
        }

        private void Display(float temp, float humidity, float pressure)
        {
            Console.WriteLine($"Statistics weather data: Temp= {temp}, Humidity= {humidity} and Pressure= {pressure}");
        }
    }
}
