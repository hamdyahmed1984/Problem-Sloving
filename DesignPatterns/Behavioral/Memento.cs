using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral
{
    /*
     * 
     * Definition:
     * Without violating encapsulation, capture and externalize an object's internal state so that the object can be restored to this state later.
     * 
     * Use the Memento Pattern when you need to be able to return an object to one of its previous states; for instance, if your user requests an “undo.”
     * 
     * Participants:
     *  The classes and objects participating in this pattern are:
     *      Memento  (Memento)
            stores internal state of the Originator object. The memento may store as much or as little of the originator's internal state as necessary at its originator's discretion.
            protect against access by objects of other than the originator. Mementos have effectively two interfaces. Caretaker sees a narrow interface to the Memento -- it can only pass the memento to the other objects. Originator, in contrast, sees a wide interface, one that lets it access all the data necessary to restore itself to its previous state. Ideally, only the originator that produces the memento would be permitted to access the memento's internal state.
            Originator  (SalesProspect)
            creates a memento containing a snapshot of its current internal state.
            uses the memento to restore its internal state
            Caretaker  (Caretaker)
            is responsible for the memento's safekeeping
            never operates on or examines the contents of a memento.
     * 
     */
      
        public class MomentoPatternTester
    {
        public void Main()
        {
            Originator originator = new Originator();
            CareTaker careTaker = new CareTaker();

            originator.setState("State #1");
            originator.setState("State #2");
            careTaker.add(originator.saveStateToMemento());

            originator.setState("State #3");
            careTaker.add(originator.saveStateToMemento());

            originator.setState("State #4");
            Console.WriteLine("Current State: " + originator.getState());

            originator.getStateFromMemento(careTaker.get(0));
            Console.WriteLine("First saved State: " + originator.getState());
            originator.getStateFromMemento(careTaker.get(1));
            Console.WriteLine("Second saved State: " + originator.getState());
        }
    }
    public class Memento
    {
        private String state;

        public Memento(String state)
        {
            this.state = state;
        }

        public String getState()
        {
            return state;
        }
    }

    public class Originator
    {
        private String state;

        public void setState(String state)
        {
            this.state = state;
        }

        public String getState()
        {
            return state;
        }

        public Memento saveStateToMemento()
        {
            return new Memento(state);
        }

        public void getStateFromMemento(Memento memento)
        {
            state = memento.getState();
        }
    }


    public class CareTaker
    {
        private List<Memento> mementoList = new List<Memento>();

        public void add(Memento state)
        {
            mementoList.Add(state);
        }

        public Memento get(int index)
        {
            return mementoList[index];
        }
    }

}
