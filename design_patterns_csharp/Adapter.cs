using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace design_patterns_csharp
{
    class Target
    {
        public virtual void Request()
        {
            Console.WriteLine(" Target's Request() method is called");
        }
    }

    class Adapter : Target
    {
        private Adaptee m_adaptee = new Adaptee();

        public override void Request()
        {
            // do some work ,and then call SpecificRequest
            m_adaptee.SpecificRequest();
        }
    };

    class Adaptee
    {
        public void SpecificRequest()
        {
            Console.WriteLine("Adaptee's SpecificRequest() is called");
        }
    }

    // below is the real-world example
    // The Target class
    class Compound
    {
        protected string m_chemical;

        public Compound(string chemical)
        {
            this.m_chemical = chemical;
        }

        public virtual void Display()
        {
            Console.WriteLine("\nCompound : {0} ----", m_chemical);
        }
    }

    // The Adapter class
    class ComplexCompound : Compound
    {
        private CompundDB m_comdb;

        public ComplexCompound(string chemical)
            : base(chemical)
        {
            m_comdb = new CompundDB();
        }

        public override void Display()
        {
            base.Display();
            Console.WriteLine("The ComplexCompound class shows :{0}", m_comdb.GetShowName(m_chemical));
        }
    };

    class CompundDB
    {
        public string GetShowName(string chemical)
        {
            switch(chemical)
            {
                case "h2o": return "water";
                default: return "default name";
            }
        }
    };
}
