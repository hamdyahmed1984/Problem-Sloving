using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational
{
    /*
     * Definition: 
     *      Specify the kind of objects to create using a prototypical instance, and create new objects by copying this prototype.
     *      
     *      Use the Prototype Pattern when creating an instance of a given class is either expensive or complicated.
     *      
     *      Participants:
     *          The classes and objects participating in this pattern are:
     *              Prototype  (ColorPrototype)
                    declares an interface for cloning itself
                    ConcretePrototype  (Color)
                    implements an operation for cloning itself
                    Client  (ColorManager)
                    creates a new object by asking a prototype to clone itself
     * 
     * 
     */

    public class PrototypePatternTester
    {
        public void Main()
        {
            ColorManager colormanager = new ColorManager();
            // Initialize with standard colors

            colormanager["red"] = new Color(255, 0, 0);
            colormanager["green"] = new Color(0, 255, 0);
            colormanager["blue"] = new Color(0, 0, 255);

            // User adds personalized colors

            colormanager["angry"] = new Color(255, 54, 0);
            colormanager["peace"] = new Color(128, 211, 128);
            colormanager["flame"] = new Color(211, 34, 20);

            // User clones selected colors

            Color color1 = colormanager["red"].Clone() as Color;
            Color color2 = colormanager["peace"].Clone() as Color;
            Color color3 = colormanager["flame"].Clone() as Color;

            // Wait for user

            Console.ReadKey();
        }
    }

    /// <summary>
    /// The 'Prototype' abstract class
    /// </summary>

    abstract class ColorPrototype
    {
        public abstract ColorPrototype Clone();
    }

    /// <summary>
    /// The 'ConcretePrototype' class
    /// </summary>

    class Color : ColorPrototype
    {
        private int _red;
        private int _green;
        private int _blue;

        // Constructor
        public Color(int red, int green, int blue)
        {
            this._red = red;
            this._green = green;
            this._blue = blue;
        }

        // Create a shallow copy
        public override ColorPrototype Clone()
        {
            Console.WriteLine( "Cloning color RGB: {0,3},{1,3},{2,3}",  _red, _green, _blue);
            return this.MemberwiseClone() as ColorPrototype;
        }
    }

    /// <summary>
    /// Prototype manager
    /// </summary>
    class ColorManager
    {
        private Dictionary<string, ColorPrototype> _colors = new Dictionary<string, ColorPrototype>();

        // Indexer
        public ColorPrototype this[string key]
        {
            get { return _colors[key]; }
            set { _colors.Add(key, value); }
        }
    }
}
