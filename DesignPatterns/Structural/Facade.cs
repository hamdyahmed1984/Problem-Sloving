using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structural
{
    /*
     * Definition:
       Provide a unified interface to a set of interfaces in a subsystem. Façade defines a higher-level interface that makes the subsystem easier to use.

        Participants:       
       The classes and objects participating in this pattern are:       
       Facade   (HomeTheatreFacade)
       knows which subsystem classes are responsible for a request.
       delegates client requests to appropriate subsystem objects.
       Subsystem classes   (DVD, Light, Projector)
       implement subsystem functionality.
       handle work assigned by the Facade object.
       have no knowledge of the facade and keep no reference to it.
     */
    public class HomeTheatreFacade
    {
        private Lights _lights;
        private DVD _dvd;
        private Projector _projector;

        public HomeTheatreFacade(Lights lights, DVD dvd, Projector projector)
        {
            this._lights = lights;
            this._dvd = dvd;
            this._projector = projector;
        }


        public void WatchMovie(string movieName)
        {
            _lights.Dim(20);
            _projector.On();
            _dvd.PlayMovie(movieName);
        }

        public void EndMovie(string movieName)
        {
            _lights.On();
            _projector.Off();
            _dvd.EndMovie(movieName);
        }
    }

    public class Lights
    {
        public void On() => Console.WriteLine("Lights ON.");
        public void Off() => Console.WriteLine("Lights ON.");
        public void Dim(int percentage) => Console.WriteLine("Lights Dimmed by " + percentage + "%.");
    }

    public class DVD
    {
        public void PlayMovie(string movieName) => Console.WriteLine("Playing movie: " + movieName);
        public void EndMovie(string movieName) => Console.WriteLine("Movie " + movieName + " is stopped.");
    }

    public class Projector
    {
        public void On() => Console.WriteLine("Projector ON.");
        public void Off() => Console.WriteLine("Projector ON.");
    }
}
