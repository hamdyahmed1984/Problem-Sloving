using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structural
{
    /*
     * Definition:
     * Decouple an abstraction from its implementation so that the two can vary independently.
     * 
     * Participants:
        The classes and objects participating in this pattern are:
        Abstraction   (BusinessObject)
        defines the abstraction's interface.
        maintains a reference to an object of type Implementor.
        RefinedAbstraction   (CustomersBusinessObject)
        extends the interface defined by Abstraction.
        Implementor   (DataObject)
        defines the interface for implementation classes. This interface doesn't have to correspond exactly to Abstraction's interface; in fact the two interfaces can be quite different. Typically the Implementation interface provides only primitive operations, and Abstraction defines higher-level operations based on these primitives.
        ConcreteImplementor   (CustomersDataObject)
        implements the Implementor interface and defines its concrete implementation.
     */


    public class ClientTester
    {
        public void Test(String[] args)
        {
            Shape redCircle = new Circle(100, 100, 10, new RedCircle());
            Shape greenCircle = new Circle(100, 100, 10, new GreenCircle());

            redCircle.Draw();
            greenCircle.Draw();
        }
    }

    public interface DrawingAPI
    {
        void DrawCircle(int radius, int x, int y);
    }

    public class RedCircle : DrawingAPI
    {
        public void DrawCircle(int radius, int x, int y)
        {
            Console.WriteLine($"Drawing Circle[ color: red, radius: { radius }, x: { x }, { y }]");
        }
    }

    public class GreenCircle : DrawingAPI
    {
        public void DrawCircle(int radius, int x, int y)
        {
            Console.WriteLine($"Drawing Circle[ color: green, radius: { radius }, x: { x }, { y }]");
        }
    }

    public abstract class Shape
    {
        protected DrawingAPI drawingAPI;

        protected Shape(DrawingAPI drawAPI)
        {
            this.drawingAPI = drawAPI;
        }
        public abstract void Draw();
    }

    public class Circle : Shape
    {
        private int x, y, radius;

        public Circle(int x, int y, int radius, DrawingAPI drawingAPI) : base(drawingAPI)
        {            
            this.x = x;
            this.y = y;
            this.radius = radius;
        }

        public override void Draw()
        {
            drawingAPI.DrawCircle(radius, x, y);
        }
    }
}
