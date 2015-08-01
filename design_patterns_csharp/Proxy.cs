using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace design_patterns_csharp
{
    abstract class Subject
    {
        public abstract void Request();
    }//end of abstract class Subject

    class RealSubject : Subject
    {
        public override void Request()
        {
            Console.WriteLine("call RealSubject.Request()");
        }
    }//end of class RealSubject

    class Proxy : Subject
    {
        private RealSubject m_real;
        public override void Request()
        {
            if(m_real == null)
            {
                m_real = new RealSubject();
            }
            m_real.Request();
        }
    }//end of class Proxy : Subject

    //Real-world examples
    // The Subject interface
    public interface IMath
    {
        double Add(double x, double y);
        double Sub(double x, double y);
        double Mul(double x, double y);
        double Div(double x, double y);
    }

    // the RealSubject interface
    class Math : IMath
    {
        public double Add(double x, double y) { return x + y; }
        public double Sub(double x, double y) { return x - y; }
        public double Mul(double x, double y) { return x * y; }
        public double Div(double x, double y) { return x / y; }
    }

    class MathProxy : IMath
    {
        private Math m_math = new Math();

        public double Add(double x, double y)
        {
            return m_math.Add(x, y);
        }

        public double Sub(double x, double y)
        {
            return m_math.Sub(x, y);
        }

        public double Mul(double x, double y)
        {
            return m_math.Mul(x, y);
        }

        public double Div(double x, double y)
        {
            return m_math.Div(x, y);
        }
    }
}
