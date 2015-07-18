﻿#define _DECORATOR_PATTERN
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace design_patterns_csharp
{
    class Program
    {
        static void Main(string[] args)
        {            
#if _DECORATOR_PATTERN
            // test Decorator Design Patterns
            ConcreteComponent concrete = new ConcreteComponent();
            ConcreteDecoratorA concreteA = new ConcreteDecoratorA();
            ConcreateDecoratorB concreteB = new ConcreateDecoratorB();

            // link decorators
            concreteA.SetComponent(concrete);
            concreteB.SetComponent(concreteA);

            concreteB.Operation();

            // wait for user's input
            Console.ReadKey();

            Book book = new Book("Google", "Do not be evil", 10);
            book.Display();

            Viedo viedo = new Viedo("Youtube", "How to build apps", 20, 90);
            viedo.Display();

            // Make viedo borrowable, then borrow and display
            Borrowable borrowViedo = new Borrowable(viedo);
            borrowViedo.BorrowItem("John");
            borrowViedo.BorrowItem("Smith");
            borrowViedo.Display();
            Console.ReadKey();
#endif
        }
    }
}
