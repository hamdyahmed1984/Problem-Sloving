using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational
{
    /// <summary>
    /// Participants
    /// 
    /// The classes and objects participating in this pattern are:
    /// 
    /// AbstractFactory  (ContinentFactory)
    /// declares an interface for operations that create abstract products
    /// ConcreteFactory   (AfricaFactory, AmericaFactory)
    /// implements the operations to create concrete product objects
    /// AbstractProduct   (Herbivore, Carnivore)
    /// declares an interface for a type of product object
    /// Product  (Wildebeest, Lion, Bison, Wolf)
    /// defines a product object to be created by the corresponding concrete factory
    /// implements the AbstractProduct interface
    /// Client  (AnimalWorld)
    /// uses interfaces declared by AbstractFactory and AbstractProduct classes
    /// </summary>
    class AbstractFactory
    {
    }

    interface IPizzaIngredientsFactory
    {
        Sauce CreateSause();
        Cheese CreateCheese();
        Clams CreateClams();
    }

    class ChicagoPizzaIngredientsFactory : IPizzaIngredientsFactory
    {
        public Sauce CreateSause()
        {
            return new TomatoSause();
        }

        public Cheese CreateCheese()
        {
            return new MozarellaCheeze();
        }

        public Clams CreateClams()
        {
            return new FrozenClams();
        }
    }

    class NyPizzaIngredientsFactory : IPizzaIngredientsFactory
    {
        public Sauce CreateSause()
        {
            return  new MariniaraSause();
        }

        public Cheese CreateCheese()
        {
            return new MozarellaCheeze();
        }

        public Clams CreateClams()
        {
            return new FreshClams();
        }
    }

    abstract class PizzaAbstractProduct
    {
        protected string name;
        protected Sauce sauce;
        protected Cheese cheese;
        protected Clams clams;

        public void Bake() => Console.WriteLine($"Baking {name}..");
        public void Cut() => Console.WriteLine($"Cutting {name}..");
        public void Box() => Console.WriteLine($"Boxing {name}..");

        public abstract void Prepare();

        public void SetName(string name) => this.name = name;
        public string GetName() => name;
    }

    class CheesePizzaProduct : PizzaAbstractProduct
    {
        private IPizzaIngredientsFactory pizzaIngredientsFactory;

        public CheesePizzaProduct(IPizzaIngredientsFactory pizzaIngredientsFactory)
        {
            this.pizzaIngredientsFactory = pizzaIngredientsFactory;
        }
        public override void Prepare()
        {
            Console.WriteLine($"Preparing {name}..");
            sauce = pizzaIngredientsFactory.CreateSause();
            cheese = pizzaIngredientsFactory.CreateCheese();
            clams = pizzaIngredientsFactory.CreateClams();
        }
    }

    class VeggiePizzaProduct : PizzaAbstractProduct
    {
        private IPizzaIngredientsFactory pizzaIngredientsFactory;

        public VeggiePizzaProduct(IPizzaIngredientsFactory pizzaIngredientsFactory)
        {
            this.pizzaIngredientsFactory = pizzaIngredientsFactory;
        }
        public override void Prepare()
        {
            Console.WriteLine($"Preparing {name}..");
            sauce = pizzaIngredientsFactory.CreateSause();
            cheese = pizzaIngredientsFactory.CreateCheese();
        }
    }

    abstract class PizzaStoreAbstractFactory
    {
        public PizzaAbstractProduct OrderPizza(string type)
        {
            PizzaAbstractProduct pizza = CreatePizza(type);

            pizza.Prepare();
            pizza.Bake();
            pizza.Cut();
            pizza.Box();

            return pizza;
        }
        protected abstract PizzaAbstractProduct CreatePizza(string type);
    }

    /// <summary>
    /// ConcreteCreator
    /// </summary>
    class NYPizzaStoreConcreteFactory : PizzaStoreAbstractFactory
    {
        protected override PizzaAbstractProduct CreatePizza(string type)
        {
            PizzaAbstractProduct pizza;
            IPizzaIngredientsFactory ingredientsFactory = new NyPizzaIngredientsFactory();      
            switch (type)
            {
                case "cheese":
                    pizza = new CheesePizzaProduct(ingredientsFactory);
                    pizza.SetName("NY Cheese Pizza");
                    break;
                case "veggie":
                    pizza = new VeggiePizzaProduct(ingredientsFactory);
                    pizza.SetName("NY Veggie Pizza");
                    break;
                default:
                    pizza = null;
                    break;
            }

            return pizza;
        }
    }
    /// <summary>
    /// ConcreteCreator
    /// </summary>
    class ChicagoPizzaStoreConcreteFactory : PizzaStoreAbstractFactory
    {
        protected override PizzaAbstractProduct CreatePizza(string type)
        {
            PizzaAbstractProduct pizza;
            IPizzaIngredientsFactory ingredientsFactory = new ChicagoPizzaIngredientsFactory();
            switch (type)
            {
                case "cheese":
                    pizza = new CheesePizzaProduct(ingredientsFactory);
                    pizza.SetName("Chicago Cheese Pizza");
                    break;
                case "veggie":
                    pizza = new VeggiePizzaProduct(ingredientsFactory);
                    pizza.SetName("Chicago Veggie Pizza");
                    break;
                default:
                    pizza = null;
                    break;
            }

            return pizza;
        }
    }

    internal class Sauce
    {}

    class TomatoSause:Sauce
    {}

    class MariniaraSause:Sauce
    {}

    internal class Clams
    {}
    class FrozenClams:Clams
    { }
    class FreshClams:Clams
    { }

    internal class Cheese
    {
    }
    class MozarellaCheeze:Cheese
    { }
    class ReggianoCheese:Cheese
    { }
}
