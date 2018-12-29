using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral
{
    /*
     * Definition:
      Define the skeleton of an algorithm in an operation, deferring some steps to subclasses. 
      Template Method lets subclasses redefine certain steps of an algorithm without changing the algorithm's structure.

    Participants:       
       The classes and objects participating in this pattern are:       
       AbstractClass  (CaffeineBeverage)
       defines abstract primitive operations that concrete subclasses define to implement steps of an algorithm
       implements a template method defining the skeleton of an algorithm. The template method calls primitive operations as well as operations defined in AbstractClass or those of other objects.
       ConcreteClass  (Tea,Coffee)
       implements the primitive operations ot carry out subclass-specific steps of the algorithm
     */
    
    public abstract class CaffeineBeverage
    {
        //Brew= يخمر, Steep=ينقع
        public void PrepareBeverage()
        {
            BoilWater();
            Brew();
            PourInCup();
            AddCondiments();
        }

        private void BoilWater() => Console.WriteLine("Boiling water.");
        private void PourInCup() => Console.WriteLine("Pouring beverage in cup.");
        public abstract void Brew();
        public abstract void AddCondiments();
    }

    public class Tea : CaffeineBeverage
    {
        public override void Brew() => Console.WriteLine("Brewing Tea");

        public override void AddCondiments() => Console.WriteLine("Adding Lemon.");
    }

    public class Coffee : CaffeineBeverage
    {
        public override void Brew() => Console.WriteLine("Brewing Coffee");

        public override void AddCondiments() => Console.WriteLine("Adding Milk and Chocolate.");
    }
}
