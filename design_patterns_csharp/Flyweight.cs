using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace design_patterns_csharp
{
    abstract class Flyweight
    {
        public abstract void Operation(int extrinsic_state);
    }//end of abstract class Flyweight

    class ConcreteFlyweight : Flyweight
    {
        public override void Operation(int extrinsic_state)
        {
            Console.WriteLine("ConcreteFlyweight :" + extrinsic_state);
        }
    }//end of class ConcreteFlyweight

    class UnsharedConcreteFlyweight : Flyweight
    {
        public override void Operation(int extrinsic_state)
        {
            Console.WriteLine("Unshared ConcreteFlyweight :" + extrinsic_state);
        }
    }//end of class UnsharedConcreteFlyweight

    class FlyweightFactory
    {
        private Hashtable m_flyweights = new Hashtable();

        public FlyweightFactory()
        {
            m_flyweights.Add("X", new ConcreteFlyweight());
            m_flyweights.Add("Y", new ConcreteFlyweight());
            m_flyweights.Add("Z", new ConcreteFlyweight());
        }

        public Flyweight GetFlyWeight(string key)
        {
            return ((Flyweight)m_flyweights[key]);
        }
    }//end of class FlyweightFactory
}
