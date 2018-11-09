using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structural
{

    /*
     * Definition
       Attach additional responsibilities to an object dynamically. Decorators provide a flexible alternative to subclassing for extending functionality.
     * Participants
       
       The classes and objects participating in this pattern are:
       
       Component   (Beverage)
       defines the interface for objects that can have responsibilities added to them dynamically.
       ConcreteComponent   (Espresso, Decaf, DarkRoast)
       defines an object to which additional responsibilities can be attached.
       Decorator   (CondimentDecorator)
       maintains a reference to a Component object and defines an interface that conforms to Component's interface.
       ConcreteDecorator   (Milk, Mocha, Whip)
       adds responsibilities to the component.
     */

    /// <summary>
    /// Component   (Beverage)
    /// defines the interface for objects that can have responsibilities added to them dynamically.
    /// </summary>
    public abstract class Beverage
    {
        protected string description = "Unknown beverage";

        public abstract string GetDescription();
        public abstract double GetCost();
    }

    /// <summary>
    ///ConcreteComponent
    ///defines an object to which additional responsibilities can be attached.
    /// </summary>
    public class Espresso : Beverage
    {
        public Espresso() => description = "Espresso";

        public override string GetDescription() => description;

        public override double GetCost()
        {
            return 0.55;
        }
    }

    /// <summary>
    ///ConcreteComponent
    ///defines an object to which additional responsibilities can be attached.
    /// </summary>
    public class Decaf : Beverage
    {
        public Decaf() => description = "Decaf";

        public override string GetDescription() => description;

        public override double GetCost()
        {
            return 0.66;
        }
    }

    /// <summary>
    ///ConcreteComponent
    ///defines an object to which additional responsibilities can be attached.
    /// </summary>
    public class DarkRoast : Beverage
    {
        public DarkRoast() => description = "DarkRoast";

        public override string GetDescription() => description;

        public override double GetCost()
        {
            return 0.77;
        }
    }


    /// <summary>
    /// Decorator   (CondimentDecorator)
    ///maintains a reference to a Component object and defines an interface that conforms to Component's interface.
    /// </summary>
    public abstract class CondimentDecorator : Beverage
    {
        //public abstract string GetDescription();
    }

    /// <summary>
    /// ConcreteDecorator
    ///adds responsibilities to the component.
    /// </summary>
    public class Milk : CondimentDecorator
    {
        private readonly Beverage _beverage;
        public Milk(Beverage beverage)
        {
            this._beverage = beverage;
        }

        public override double GetCost() => this._beverage.GetCost() + 0.1;

        public override string GetDescription() => this._beverage.GetDescription() + ", Milk";
    }

    /// <summary>
    /// ConcreteDecorator
    ///adds responsibilities to the component.
    /// </summary>
    public class Mocha : CondimentDecorator
    {
        private readonly Beverage _beverage;
        public Mocha(Beverage beverage)
        {
            this._beverage = beverage;
        }

        public override double GetCost() => this._beverage.GetCost() + 0.2;

        public override string GetDescription() => this._beverage.GetDescription() + ", Mocha";
    }

    /// <summary>
    /// ConcreteDecorator
    ///adds responsibilities to the component.
    /// </summary>
    public class Whip : CondimentDecorator
    {
        private readonly Beverage _beverage;
        public Whip(Beverage beverage)
        {
            this._beverage = beverage;
        }

        public override double GetCost() => this._beverage.GetCost() + 0.1;

        public override string GetDescription() => this._beverage.GetDescription() + ", Whip";
    }
}
