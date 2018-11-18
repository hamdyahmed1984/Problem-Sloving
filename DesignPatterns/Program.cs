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

            #region Command Pattern Test
            RemoteControl rc = new RemoteControl();
            
            Light livingRoomLight = new Light("Living Room");
            Light kitchenLight=new Light("Kitchen");
            Garage garage=new Garage();
            Fan fan = new Fan("Bedroom");

            LightOnCommand livingRoomLightOnCommand = new LightOnCommand(livingRoomLight);
            LightOffCommand livingRoomLightOffCommand=new LightOffCommand(livingRoomLight);

            LightOnCommand kitchenLightOnCommand = new LightOnCommand(kitchenLight);
            LightOffCommand kitchenLightOffCommand = new LightOffCommand(kitchenLight);

            GarageOpenCommand garageOpenCommand=new GarageOpenCommand(garage);
            GarageCloseCommand garageCloseCommand=new GarageCloseCommand(garage);

            FanOffCommand fanOffCommand=new FanOffCommand(fan);
            FanHighCommand fanHighCommand=new FanHighCommand(fan);

            rc.SetCommand(0, livingRoomLightOnCommand, kitchenLightOffCommand);
            rc.SetCommand(1, kitchenLightOnCommand, kitchenLightOffCommand);
            rc.SetCommand(2, garageOpenCommand, garageCloseCommand);
            rc.SetCommand(3, fanHighCommand, fanOffCommand);

            Console.WriteLine(rc.ToString());
            rc.OnButtonPushed(0);
            rc.OnButtonPushed(1);
            rc.OnButtonPushed(2);
            rc.OffButtonPushed(1);
            rc.OnButtonPushed(3);
            rc.OnButtonPushed(7);
            rc.Undo();
            rc.Undo();
            rc.Undo();
            rc.Undo();
            rc.Undo();
            rc.Undo();
            rc.Undo();
            Console.WriteLine(rc.ToString());
            #endregion

            #region Singleton Pattern Test

            //Singleton s1 = Singleton.Createinstance();
            //Singleton s2 = Singleton.Createinstance();
            //Console.WriteLine(s1 == s2);

            #endregion

            #region Abstract Factory Pattern Test
            //NYPizzaStoreConcreteFactory nyStore = new NYPizzaStoreConcreteFactory();
            //nyStore.OrderPizza("cheese");
            //nyStore.OrderPizza("veggie");

            //ChicagoPizzaStoreConcreteFactory chicagoStore = new ChicagoPizzaStoreConcreteFactory();
            //chicagoStore.OrderPizza("cheese");
            //chicagoStore.OrderPizza("veggie");
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
