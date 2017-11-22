using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.StacksQueues
{
    class AnimalShelter
    {
        int order = 0;
        LinkedList<Dog> dogs = new LinkedList<Dog>();
        LinkedList<Cat> cats = new LinkedList<Cat>();

        public void Enqueue(Animal a)
        {
            a.Order = order++;
            if (a is Dog)
                dogs.AddLast((Dog)a);
            else if (a is Cat)
                cats.AddLast((Cat)a);
        }

        public Animal DequeueAny()
        {
            if (cats.Count == 0)
                return DequeueCat();
            else if (dogs.Count == 0)
                return DequeueDog();

            Dog dog = dogs.First.Value;
            Cat cat = cats.First.Value;

            if (dog.IsOlderThan(cat))
                return DequeueDog();
            else
                return DequeueCat();
        }
        public Dog DequeueDog()
        {
            if (dogs.First != null)
            {
                Dog dog = dogs.First.Value;
                dogs.RemoveFirst();
                return dog;
            }
            else
                return null;
        }
        public Cat DequeueCat()
        {
            if (cats.First != null)
            {
                Cat cat = cats.First.Value;
                cats.RemoveFirst();
                return cat;
            }
            else
                return null;                 
        }
    }

    class Animal
    {
        protected string Name { get; set; }
        public int Order { get; set; }
        public bool IsOlderThan(Animal a)
        {
            return this.Order < a.Order;
        }
    }
    class Dog : Animal {
        public Dog(string name)
        {
            this.Name = name;
        }
    }
    class Cat : Animal {
        public Cat(string name)
        {
            this.Name = name;
        }
    }
}
