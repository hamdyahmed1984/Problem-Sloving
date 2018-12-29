using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structural
{
    /*
     * Definition:
        Provide a surrogate or placeholder for another object to control access to it.
        Participants:
            The classes and objects participating in this pattern are:
            Proxy   (MathProxy)
            maintains a reference that lets the proxy access the real subject. Proxy may refer to a Subject if the RealSubject and Subject interfaces are the same.
            provides an interface identical to Subject's so that a proxy can be substituted for for the real subject.
            controls access to the real subject and may be responsible for creating and deleting it.
            other responsibilites depend on the kind of proxy:
            remote proxies are responsible for encoding a request and its arguments and for sending the encoded request to the real subject in a different address space.
            virtual proxies may cache additional information about the real subject so that they can postpone accessing it. For example, the ImageProxy from the Motivation caches the real images's extent.
            protection proxies check that the caller has the access permissions required to perform a request.
            Subject   (IMath)
            defines the common interface for RealSubject and Proxy so that a Proxy can be used anywhere a RealSubject is expected.
            RealSubject   (Math)
            defines the real object that the proxy represents.
     */

    /// <summary>

    /// The 'Subject interface

    /// </summary>

    public interface IMath
    {
        double Add(double x, double y);
        double Sub(double x, double y);
        double Mul(double x, double y);
        double Div(double x, double y);
    }

    /// <summary>
    /// The 'RealSubject' class
    /// </summary>
    class Math : IMath
    {
        public double Add(double x, double y) => x + y;
        public double Sub(double x, double y)=> x - y;
        public double Mul(double x, double y) => x * y;
        public double Div(double x, double y) => x / y;}

    /// <summary>
    /// The 'Proxy Object' class
    /// </summary>
    class MathProxy : IMath
    {
        private Math _math = new Math();

        public double Add(double x, double y) => _math.Add(x, y);
        public double Sub(double x, double y) => _math.Sub(x, y);
        public double Mul(double x, double y) => _math.Mul(x, y);
        public double Div(double x, double y) => _math.Div(x, y);
    }
}
