using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral
{
    /*
     * Definition:
       Provide a way to access the elements of an aggregate object sequentially without exposing its underlying representation.

    Participants:      
       The classes and objects participating in this pattern are:       
       Iterator  (Iterator)
            defines an interface for accessing and traversing elements.
       ConcreteIterator  (BreakfastIterator, DinnerIterator)
            implements the Iterator interface.
            keeps track of the current position in the traversal of the aggregate.
       Aggregate  (Menu)
            defines an interface for creating an Iterator object
       ConcreteAggregate  (BreakfastMenu, DinnerMenu)
            implements the Iterator creation interface to return an instance of the proper ConcreteIterator
     */

    public interface Iterator
    {
        bool HasNext();
        object Next();
    }

    public interface Menu
    {
        Iterator CreatorIterator();
    }

    public class Waitress
    {
        private Menu _breakFastMenu;
        private Menu _dinnerMenu;

        public Waitress(Menu breakFastMenu, Menu dinnerMenu)
        {
            this._breakFastMenu = breakFastMenu;
            this._dinnerMenu = dinnerMenu;
        }

        public void PrintMenu()
        {
            Iterator breakFastIterator = _breakFastMenu.CreatorIterator();
            Iterator dinnerIterator = _dinnerMenu.CreatorIterator();

            Console.WriteLine("Breakfast menu:");
            PrintMenu(breakFastIterator);
            Console.WriteLine("Dinner menu:");
            PrintMenu(dinnerIterator);
        }

        private void PrintMenu(Iterator iterator)
        {
            while (iterator.HasNext())
            {
                MenuItem itm = (MenuItem)iterator.Next();
                Console.WriteLine(itm.Name + " - " + itm.Price);
            }
        }
    }

    public class BreakfastIterator : Iterator
    {
        private int position = 0;
        private List<MenuItem> _menuItems;

        public BreakfastIterator(List<MenuItem> menuItems)
        {
            this._menuItems = menuItems;
        }
        public bool HasNext()
        {
            if (position >= _menuItems.Count)
                return false;
            return true;
        }

        public object Next()
        {
            MenuItem itm = _menuItems[position];
            position++;
            return itm;
        }
    }

    public class DinnerIterator : Iterator
    {
        private int position = 0;
        private MenuItem[] _menuItems;

        public DinnerIterator(MenuItem[] menuItems)
        {
            this._menuItems = menuItems;
        }
        public bool HasNext()
        {
            if (position >= _menuItems.Length || _menuItems[position] == null)//the array may not be full so we check for null
                return false;
            return true;
        }

        public object Next()
        {
            MenuItem itm = _menuItems[position];
            position++;
            return itm;
        }
    }

    public class BreakfastMenu : Menu
    {
        private List<MenuItem> menuItems;

        public BreakfastMenu()
        {
            menuItems = new List<MenuItem>();
            menuItems.Add(new MenuItem("BreakFast1", 1.0));
            menuItems.Add(new MenuItem("BreakFast2", 2.0));
            menuItems.Add(new MenuItem("BreakFast3", 3.0));
        }

        public Iterator CreatorIterator()
        {
            return new BreakfastIterator(menuItems);
        }
    }



    public class DinnerMenu : Menu
    {
        private readonly int MAX_ITEMS = 10;
        private MenuItem[] menuItems;

        public DinnerMenu()
        {
            menuItems = new MenuItem[MAX_ITEMS];

            menuItems[0] = new MenuItem("Dinner1", 1.5);
            menuItems[1] = new MenuItem("Dinner2", 2.5);
            menuItems[2] = new MenuItem("Dinner3", 3.5);
        }

        public Iterator CreatorIterator()
        {
            return new DinnerIterator(menuItems);
        }
    }

    public class MenuItem
    {
        public MenuItem(string name, double price)
        {
            this.Name = name;
            this.Price = price;
        }
        public string Name { get; set; }
        public double Price { get; set; }
    }

    


   
}
