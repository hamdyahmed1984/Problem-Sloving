using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatterns.Behavioral;
using DesignPatterns.Creational;
using DesignPatterns.Structural;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Abstract Factory Pattern Test
            NYPizzaStoreConcreteFactory nyStore = new NYPizzaStoreConcreteFactory();
            nyStore.OrderPizza("cheese");
            nyStore.OrderPizza("veggie");

            ChicagoPizzaStoreConcreteFactory chicagoStore = new ChicagoPizzaStoreConcreteFactory();
            chicagoStore.OrderPizza("cheese");
            chicagoStore.OrderPizza("veggie");
            #endregion

            #region Factory Method Pattern Test
            //NYPizzaStore nyStore = new NYPizzaStore();
            //nyStore.OrderPizza("cheese");
            //nyStore.OrderPizza("veggie");

            //ChicagoPizzaStore chicagoStore = new ChicagoPizzaStore();
            //chicagoStore.OrderPizza("cheese");
            //chicagoStore.OrderPizza("veggie");
            #endregion

            #region Decorator Pattern Test
            //Beverage beverage = new Espresso();
            //Console.WriteLine(beverage.GetDescription() + " $" + beverage.GetCost());

            //Beverage beverage2 = new DarkRoast();
            //Console.WriteLine(beverage2.GetDescription() + " $" + beverage2.GetCost());

            //Beverage beverage3 = new Milk(beverage2);
            //Console.WriteLine(beverage3.GetDescription() + " $" + beverage3.GetCost());

            //Beverage beverage4 = new Milk(beverage3);
            //beverage4=new Mocha(beverage4);
            //beverage4=new Mocha(beverage4);
            //beverage4=new Whip(beverage4);
            //Console.WriteLine(beverage4.GetDescription() + " $" + beverage4.GetCost());
            #endregion`

            #region Observer Pattern Test
            //WeatherData wd = new WeatherData();

            //CurrentWeather cw = new CurrentWeather(wd);
            //ForecastWeather fw=new ForecastWeather(wd);
            //StatisticsWeather sw=new StatisticsWeather(wd);

            //wd.ChangeWeatherData(100, 200, 300);

            #endregion

            #region Strategy Pattern Test

            //SortedList sortedList = new SortedList(new List<string>() { "1", "4", "3", "2", "5" });

            //sortedList.SetSortStrategy(new MergekSort());
            //sortedList.SortTheList();

            //sortedList.SetSortStrategy(new QuickSort());
            //sortedList.SortTheList();

            //sortedList.SetSortStrategy(new ShellSort());
            //sortedList.SortTheList(); 

            #endregion

            Console.ReadLine();
        }
    }
}
