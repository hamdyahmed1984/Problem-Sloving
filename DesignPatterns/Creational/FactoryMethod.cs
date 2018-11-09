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
    /// Product  (Pizza)
    /// defines the interface of objects the factory method creates
    /// ConcreteProduct  (NyStyleCheesePizza, NyStyleVeggiePizza, ChicagoStyleCheesePizza, ChicagoStyleVeggiePizza)
    /// implements the Product interface
    /// Creator  (PizzaStore)
    /// declares the factory method, which returns an object of type Product. Creator may also define a default implementation of the factory method that returns a default ConcreteProduct object.
    /// may call the factory method to create a Product object.
    /// ConcreteCreator  (NYPizzaStore, ChicagoPizzaStore)
    /// overrides the factory method to return an instance of a ConcreteProduct.
    /// </summary>
    ///

    /// <summary>
    /// Creator
    /// </summary>
    abstract class PizzaStore
    {
        public Pizza OrderPizza(string type)
        {
            Pizza pizza = CreatePizza(type);
           
            pizza.Prepare();
            pizza.Bake();
            pizza.Cut();
            pizza.Box();

            return pizza;
        }
        protected abstract Pizza CreatePizza(string type);
    }

    /// <summary>
    /// ConcreteCreator
    /// </summary>
    class NYPizzaStore : PizzaStore
    {
        protected override Pizza CreatePizza(string type)
        {
            switch (type)
            {
                case "cheese":
                    return new NyStyleCheesePizza();
                case "veggie":
                    return new NyStyleVeggiePizza();
                default:
                    return null;
            }
        }
    }
    /// <summary>
    /// ConcreteCreator
    /// </summary>
    class ChicagoPizzaStore : PizzaStore
    {
        protected override Pizza CreatePizza(string type)
        {
            switch (type)
            {
                case "cheese":
                    return new ChicagoStyleCheesePizza();
                case "veggie":
                    return new ChicagoStyleVeggiePizza();
                default:
                    return null;
            }
        }
    }
    /// <summary>
    /// Product
    /// </summary>
    abstract class Pizza
    {
        protected string name = "";
        public void Prepare() => Console.WriteLine($"Preparing {name}..");
        public void Bake() => Console.WriteLine($"Baking {name}..");
        public void Cut() => Console.WriteLine($"Cutting {name}..");
        public void Box() => Console.WriteLine($"Boxing {name}..");

        public string GetName() => name;
    }
    /// <summary>
    /// ConcreteProduct
    /// </summary>
    class NyStyleCheesePizza : Pizza
    {
        public NyStyleCheesePizza()
        {
            name = "New York Style Cheese Pizza";
        }
    }
    /// <summary>
    /// ConcreteProduct
    /// </summary>
    class NyStyleVeggiePizza : Pizza
    {
        public NyStyleVeggiePizza()
        {
            name = "New York Style Veggie Pizza";
        }
    }
    /// <summary>
    /// ConcreteProduct
    /// </summary>
    class ChicagoStyleCheesePizza : Pizza
    {
        public ChicagoStyleCheesePizza()
        {
            name = "Chicago Style Cheese Pizza";
        }
    }
    /// <summary>
    /// ConcreteProduct
    /// </summary>
    class ChicagoStyleVeggiePizza : Pizza
    {
        public ChicagoStyleVeggiePizza()
        {
            name = "Chicago Style Veggie Pizza";
        }
    }
}
