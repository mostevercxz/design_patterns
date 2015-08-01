using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace design_patterns_csharp
{
    class SubSystem1
    {
        public void Method1()
        {
            Console.WriteLine("SubSystem1 Method");
        }
    }

    class Subsystem2
    {
        public void Method2()
        {
            Console.WriteLine("Subsystem2 Method");
        }
    }//end class Subsystem2

    class SubSystem3
    {
        public void Method3()
        {
            Console.WriteLine("Subsystem3 Methos3");
        }
    }//end class SubSystem3
    class Facade
    {
        private SubSystem1 _one;
        private Subsystem2 _two;
        private SubSystem3 _three;

        public Facade()
        {
            _one = new SubSystem1();
            _two = new Subsystem2();
            _three = new SubSystem3();
        }

        public void MethodA()
        {
            Console.WriteLine("\nMethodA()-----");
            _one.Method1();
            _three.Method3();
        }

        public void MethodB()
        {
            Console.WriteLine("\nMethodB()------");
            _two.Method2();
        }
    }//end class Facade

    // Real-world example
    // 这个设计模式，把一堆类放到一个类里面，这个类统一管理。和上面的例子差不多,就不实际书写了.
}
