using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    /*
     * Patterns are often used together and combined within the same design solution.
     * A compound pattern combines two or more patterns into a solution that solves a recurring or general problem.
     * 
     * 
     * Classes in this program implement 6 design patters:
     * Adapter
     * Decorator
     * Astract Factory
     * Composite
     * Iterator
     * Observer
     */




    public class DuckSimulator
    {
        public void Simulate(AbstractDuckFactory duckFactory)
        {
            Console.WriteLine("\nDuck Simulator");

            Quackable mallardDuck = duckFactory.CreateMallardDuck();
            Quackable redheadDuck = duckFactory.CreateRedheadDuck();
            Quackable duckCall = duckFactory.CreateDuckCall();
            Quackable rubberDuck = duckFactory.CreateRubberDuck();
            Quackable gooseDuck = new GooseAdapter(new Goose());

            Quackable mallardOne = duckFactory.CreateMallardDuck();
            Quackable mallardTwo = duckFactory.CreateMallardDuck();
            Quackable mallardThree = duckFactory.CreateMallardDuck();
            Quackable mallardFour = duckFactory.CreateMallardDuck();

            Flock flockOfDucks = new Flock();
            flockOfDucks.Add(redheadDuck);
            flockOfDucks.Add(duckCall);
            flockOfDucks.Add(rubberDuck);
            flockOfDucks.Add(gooseDuck);

            Flock flockOfMallards = new Flock();            
                
            flockOfMallards.Add(mallardOne);
            flockOfMallards.Add(mallardTwo);
            flockOfMallards.Add(mallardThree);
            flockOfMallards.Add(mallardFour);

            flockOfDucks.Add(flockOfMallards);

            Quackologist quackologist = new Quackologist();
            flockOfDucks.RegisterObserver(quackologist);

            Console.WriteLine("\nDuck Simulator: Whole Flock Simulation");
            Simulate(flockOfDucks);
            Console.WriteLine("\nDuck Simulator: Mallard Flock Simulation");
            Simulate(flockOfMallards);

            Console.WriteLine($"The ducks quacked {QuackCounterDecorator.GetNumberOfQuacks()} times");
        }
        void Simulate(Quackable duck)
        {
            duck.Quack();
        }
    }

    public class Quackologist : Observer
    {
        public void Update(QuackObservable duck)
        {
            Console.WriteLine($"Quackologist: {duck} just quacked.");
        }
    }
    public interface Observer
    {
        void Update(QuackObservable duck);
    }

    /// <summary>
    /// Observer design pattern
    /// </summary>
    public class Observable : QuackObservable
    {
        List<Observer> observers = new List<Observer>();
        QuackObservable duck;
        public Observable(QuackObservable duck)
        {
            this.duck = duck;
        }
        public void RegisterObserver(Observer observer)
        {
            observers.Add(observer);
        }
        public void NotifyObservers()
        {
            foreach (Observer observer in observers)
                observer.Update(duck);
        }
    }

    public interface QuackObservable
    {
        void RegisterObserver(Observer observer);
        void NotifyObservers();
    }

    /// <summary>
    /// Composite design pattern
    /// </summary>
    public class Flock : Quackable
    {
        List<Quackable> ducks = new List<Quackable>();
        public void Add(Quackable duck)
        {
            ducks.Add(duck);
        }
        public void Quack()
        {
            foreach (Quackable duck in ducks)//This is the Iterator patterns
                duck.Quack();
        }
        public void RegisterObserver(Observer observer)
        {
            foreach (Quackable duck in ducks)
                duck.RegisterObserver(observer);
        }
        public void NotifyObservers() { }
    }

    /// <summary>
    /// Abstract Factory design pattern
    /// </summary>
    public class CountingDuckFactory : AbstractDuckFactory
    {
        public override Quackable CreateMallardDuck()
        {
            return new QuackCounterDecorator(new MallardDuck());
        }
        public override Quackable CreateRedheadDuck()
        {
            return new QuackCounterDecorator(new RedheadDuck());
        }
        public override Quackable CreateDuckCall()
        {
            return new QuackCounterDecorator(new DuckCall());
        }
        public override Quackable CreateRubberDuck()
        {
            return new QuackCounterDecorator(new RubberDuck());
        }
    }
    public abstract class AbstractDuckFactory
    {
        public abstract Quackable CreateMallardDuck();
        public abstract Quackable CreateRedheadDuck();
        public abstract Quackable CreateDuckCall();
        public abstract Quackable CreateRubberDuck();
    }

    /// <summary>
    /// Decorator design pattern
    /// </summary>
    public class QuackCounterDecorator : Quackable
    {
        private Quackable duck;
        private static int numberOfQuacks;

        public QuackCounterDecorator(Quackable duck)
        {
            this.duck = duck;
        }

        public static int GetNumberOfQuacks() => numberOfQuacks;

        public void Quack()
        {
            this.duck.Quack();
            numberOfQuacks++;
        }

        public void RegisterObserver(Observer observer)
        {
            duck.RegisterObserver(observer);
        }
        public void NotifyObservers()
        {
            duck.NotifyObservers();
        }
    }
    /// <summary>
    /// Adapter design pattern
    /// </summary>
    public class GooseAdapter : Quackable
    {
        Observable observable;
        private Goose _goose;
        public GooseAdapter(Goose goose)
        {
            this._goose = goose;
            observable = new Observable(this);
        }

        public void Quack()
        {
            this._goose.Honk();
            NotifyObservers();
        }

        public void RegisterObserver(Observer observer)
        {
            observable.RegisterObserver(observer);
        }

        public void NotifyObservers()
        {
            observable.NotifyObservers();
        }
    }

    public interface Quackable: QuackObservable
    {
        void Quack();
    }

    public class MallardDuck : Quackable
    {
        Observable observable;
        public MallardDuck()
        {
            observable = new Observable(this);
        }
        public void Quack()
        {
            Console.WriteLine("Quack");
            NotifyObservers();
        }

        public void RegisterObserver(Observer observer)
        {
            observable.RegisterObserver(observer);
        }

        public void NotifyObservers()
        {
            observable.NotifyObservers();
        }
    }

    public class RedheadDuck : Quackable
    {
        Observable observable;
        public RedheadDuck()
        {
            observable = new Observable(this);
        }
        public void Quack()
        {
            Console.WriteLine("Quack");
            NotifyObservers();
        }

        public void RegisterObserver(Observer observer)
        {
            observable.RegisterObserver(observer);
        }

        public void NotifyObservers()
        {
            observable.NotifyObservers();
        }
    }

    public class DuckCall : Quackable
    {
        Observable observable;
        public DuckCall()
        {
            observable = new Observable(this);
        }

        public void Quack()
        {
            Console.WriteLine("Kwak");
            NotifyObservers();
        }

        public void RegisterObserver(Observer observer)
        {
            observable.RegisterObserver(observer);
        }

        public void NotifyObservers()
        {
            observable.NotifyObservers();
        }
    }

    public class RubberDuck : Quackable
    {
        Observable observable;

        public RubberDuck()
        {
            observable = new Observable(this);
        }
        public void Quack()
        {
            Console.WriteLine("Squeak");
            NotifyObservers();
        }

        public void RegisterObserver(Observer observer)
        {
            observable.RegisterObserver(observer);
        }

        public void NotifyObservers()
        {
            observable.NotifyObservers();
        }
    }

    public class Goose//Goose = وزة
    {
        public void Honk()
        {
            Console.WriteLine("Honk");
        }
    }
}
