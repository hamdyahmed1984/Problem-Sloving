using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.Moderate
{
    /// <summary>
    /// 16.10 Living People: Given a list of people with their birth and death years, implement a method to
    /// compute the year with the most number of people alive.You may assume that all people were born
    /// between 1900 and 2000 (inclusive). If a person was alive during any portion of that year, they should
    /// be included in that year's count. For example, Person (birth= 1908, death= 1909) is included in the counts for both 1908 and 1909.
    /// </summary>
    class LivingPeople
    {
        public void Test()
        {
            Person[] people ={
                new Person(1992,1995),
                new Person(1993,1999),
                new Person(1990,1999),
                new Person(1991,1997),
                new Person(1991,1998),
                new Person(1992,1998),
                new Person(1993,1996),
                new Person(1990,1998),
                new Person(1993,1999),
                new Person(1995,1997)
            };

            int maxAliveYear = MaxAliveYear_BF(people, 1990, 2000);
            maxAliveYear = MaxAliveYear_BF_Better(people, 1990, 2000);
            maxAliveYear = MaxAliveYear_Optimal(people, 1990, 2000);
        }

        /// <summary>
        /// O (RP), where R is the range of years (100 in this case) and P is the number of people.
        /// </summary>
        /// <param name="people"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        private int MaxAliveYear_BF(Person[] people, int min, int max)
        {
            int maxAlive = 0;
            int maxAliveYear = min;
            for (int year = min; year <= max; year++)
            {
                int alive = 0;
                foreach (Person p in people)
                {
                    if (p.BirthYear <= year && year <= p.DeathYear)
                    {
                        alive++;
                    }
                }
                if(alive > maxAlive)
                {
                    maxAlive = alive;
                    maxAliveYear = year;
                }
            }
            return maxAliveYear;
        }

        /// <summary>
        /// O(PY + R), where R is the range of years (100 in this case), P is the number of people and Y is the number of years a person is alive. In the worst case, Y is Rand we have done no better than we did in the first algorithm.
        /// </summary>
        /// <param name="people"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        private int MaxAliveYear_BF_Better(Person[] people, int min, int max)
        {
            int[] yearsPopulation = new int[max - min + 1];
            foreach (Person p in people)
            {
                for (int year = p.BirthYear - min; year <= p.DeathYear - min; year++)
                {
                    yearsPopulation[year]++;
                }
            }

            int maxAlive = yearsPopulation[0];
            int maxAliveYear = min;
            for (int i = 1; i < yearsPopulation.Length; i++)
            {
                if (yearsPopulation[i] > maxAlive)
                {
                    maxAlive = yearsPopulation[i];
                    maxAliveYear = i + min;
                }
            }
            return maxAliveYear;
        }

        /// <summary>
        /// a birth is just adding a person and a death is just subtracting a person.
        /// 
        /// This algorithm takesO(R + P) time, where R is the range of years and Pis the number of people. Although
        /// O(R + P) might be faster than O(P log P) for many expected inputs, you cannot directly compare the
        /// speeds to say that one is faster than the other.
        /// </summary>
        /// <param name="people"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        private int MaxAliveYear_Optimal(Person[] people, int min, int max)
        {
            int[] populationDeltas = GetPopulationDeltas(people, min, max);
            int maxAliveYear = GetMaxAliveYearFromDeltas(populationDeltas);
            return maxAliveYear + min;
        }

       
        /// <summary>
        ///  /* Add birth and death years to deltas array. */
        /// </summary>
        /// <param name="people"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        private int[] GetPopulationDeltas(Person[] people, int min, int max)
        {
            //We need to count a person as alive in the year he died in also so we add 2 here, if we didn't do that we get out of bound exception when we decrement below
            int[] populationDeltas = new int[max - min + 2];
            foreach(Person p in people)
            {
                int birth = p.BirthYear - min;
                populationDeltas[birth]++;

                int death = p.DeathYear - min;
                populationDeltas[death + 1]--;//We decrement the next year count because we want to coun the person in the year he died in.
            }
            return populationDeltas;
        }

        /// <summary>
        /// /* Compute running sums and return index with max. */
        /// </summary>
        /// <param name="populationDeltas"></param>
        private int GetMaxAliveYearFromDeltas(int[] populationDeltas)
        {
            int maxAlive = 0;
            int maxAliveYear = 0;
            int currentlyAlive = 0;
            for(int year = 0; year < populationDeltas.Length; year++)
            {
                currentlyAlive += populationDeltas[year];
                if(currentlyAlive > maxAlive)
                {
                    maxAlive = currentlyAlive;
                    maxAliveYear = year;
                }
            }
            return maxAliveYear;
        }

        public class Person
        {
            public int BirthYear { get; set; }
            public int DeathYear { get; set; }
            public Person(int birth, int death)
            {
                this.BirthYear = birth;
                this.DeathYear = death;
            }
        }
    }
}
