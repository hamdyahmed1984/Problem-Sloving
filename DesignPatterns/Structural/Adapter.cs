using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structural
{
    /*
     * Definition
       Convert the interface of a class into another interface clients expect. 
       Adapter lets classes work together that couldn't otherwise because of incompatible interfaces.

        Participants:       
       The classes and objects participating in this pattern are:       
       Target   (Duck)
       defines the domain-specific interface that Client uses.
       Adapter   (TurkeyAdapter)
       adapts the interface Adaptee to the Target interface.
       Adaptee   (Turkey)
       defines an existing interface that needs adapting.
       Client   (AdapterApp)
       collaborates with objects conforming to the Target interface.
     */

    public interface Duck
    {
        void Quak();
        void Fly();
    }

    public class MallardDuck : Duck
    {
        public void Quak()
        {
            Console.WriteLine("MallardDuck: Quak.");
        }

        public void Fly()
        {
            Console.WriteLine("MallardDuck: Fly.");
        }
    }

    public interface Turkey
    {
        void Gobble();
        void Fly();
    }

    public class WildTurkey : Turkey
    {
        public void Fly()
        {
            Console.WriteLine("WildTurkey: Quak for a short distance.");
        }

        public void Gobble()
        {
            Console.WriteLine("WildTurkey: Gobble.");
        }
    }

    public class TurkeyAdapter : Duck
    {
        private Turkey _turkey;

        public TurkeyAdapter(Turkey turkey)
        {
            this._turkey = turkey;
        }
        public void Fly()
        {
            _turkey.Fly();
        }

        public void Quak()
        {
            _turkey.Gobble();
        }
    }
}

