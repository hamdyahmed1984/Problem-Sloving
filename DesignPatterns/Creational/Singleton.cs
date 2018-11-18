using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational
{
    /*
     * Definition
       Ensure a class has only one instance and provide a global point of access to it.
       Participants:       
       The classes and objects participating in this pattern are:       
       Singleton 
       defines an Instance operation that lets clients access its unique instance. Instance is a class operation.
       responsible for creating and maintaining its own unique instance.
     */

    /// <summary>
    /// When you get a singleton instance you then deal with it as an instance object and can access its members as instance members not class members
    /// </summary>
    class Singleton
    {
        private static Singleton _instance;
        private static readonly object _syncLock = new object();

        private Singleton()
        {
        }

        public static Singleton Createinstance()
        {
            // Support multithreaded applications through 'Double checked locking' pattern which (once the instance exists) avoids locking each time the method is invoked
            if (_instance == null)
            {
                lock (_syncLock)
                {
                    if (_instance == null)
                        _instance = new Singleton();
                }

                return _instance;
            }

            return _instance;
        }
    }

}
