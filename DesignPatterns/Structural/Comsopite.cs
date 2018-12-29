using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structural
{
    /*
     * Definition:
       Compose objects into tree structures to represent part-whole hierarchies. Composite lets clients treat individual objects and compositions of objects uniformly.

    Participants:       
       The classes and objects participating in this pattern are:       
       Component   (MenuComponent)
           declares the interface for objects in the composition.
           implements default behavior for the interface common to all classes, as appropriate.
           declares an interface for accessing and managing its child components.
           (optional) defines an interface for accessing a component's parent in the recursive structure, and implements it if that's appropriate.
       Leaf   (MenuItem)
           represents leaf objects in the composition. A leaf has no children.
           defines behavior for primitive objects in the composition.
       Composite   (Menu)
           defines behavior for components having children.
           stores child components.
           implements child-related operations in the Component interface.
       Client  (Waitress)
             manipulates objects in the composition through the Component interface.
     */

    public abstract class MenuComponent
    {
        public void Add(MenuComponent menuComponent)
        {
            throw new InvalidOperationException();
        }

        public void Remove(MenuComponent menuComponent)
        {
            throw new InvalidOperationException();
        }

        public MenuComponent GetChild(int i)
        {
            throw new InvalidOperationException();
        }

        public string GetName()
        {
            throw new InvalidOperationException();
        }

        public double GetPrice()
        {
            throw new InvalidOperationException();
        }

        public void Print()
        {
            throw new InvalidOperationException();
        }
    }

    public class MenuItem : MenuComponent
    {
        String name;

        double price;

        public MenuItem(String name, double price)
        {
            this.name = name;
            this.price = price;
        }

        public string GetName()
        {
            return name;
        }

        public double GetPrice()
        {
            return price;
        }

        public void print()
        {
            Console.WriteLine(name + " - " + price);
        }
    }

    public class Menu : MenuComponent
    {
        List<MenuComponent> menuComponents = new List<MenuComponent>();
        String name;

        public Menu(String name)
        {
            this.name = name;
        }

        public void Add(MenuComponent menuComponent)
        {
            menuComponents.Add(menuComponent);
        }

        public void remove(MenuComponent menuComponent)
        {
            menuComponents.Remove(menuComponent);
        }

        public MenuComponent getChild(int i)
        {
            return (MenuComponent) menuComponents[i];
        }

        public String GetName()
        {
            return name;
        }

        public void Print()
        {
            Console.WriteLine(name);
            Console.WriteLine("---------------------");

            IEnumerator<MenuComponent> enumerator = menuComponents.GetEnumerator();
            while (enumerator.MoveNext())
            {
                MenuComponent menuComponent = (MenuComponent)enumerator.Current;
                menuComponent.Print();
            }
        }
    }

    public class Waitress
    {
        MenuComponent allMenus;
        public Waitress(MenuComponent allMenus)
        {
            this.allMenus = allMenus;
        }
        public void PrintMenu()
        {
            allMenus.Print();
        }
    }

}
