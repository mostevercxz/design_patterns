//#define _DECORATOR_PATTERN
//#define _ADAPTER_PATTERN
//#define _BRIDGE_PATTERN
//#define _COMPOSITE_PATTERN
//#define _FACADE_PATTERN
//#define _FLY_WEIGHT_PATTERN
//#define _PROXY_PATTERN
#define _COMMAND_PATTERN
#define _ITERATOR_PATTERN
#define _OBSERVER_PATTERN
#define _STATE_PATTERN
#define _STRATEGY_PATTERN
//#define _FACTORY_PATTERN
#define _ABSTRACT_FACTORY_PATTERN
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
#if _ADAPTER_PATTERN
            Target target = new Adapter();
            target.Request();

            Compound compound = new Compound("Unknown");
            compound.Display();

            ComplexCompound complex = new ComplexCompound("h2o");
            complex.Display();
            Console.ReadKey();
#endif
#if _BRIDGE_PATTERN
            Abstraction ab = new RefinedAbstraction();
            ab.impl = new ConcreteImplementorA();
            ab.Operation();

            ab.impl = new ConcreteImplementorB();
            ab.Operation();

            Customers cus = new Customers("root");
            cus.data = new CustomerData();
            cus.Show();
            cus.Next();
            cus.Show();
            cus.Next();
            cus.Show();
            cus.Add("Another Customer");
            cus.ShowAll();

            Console.ReadKey();
#endif
#if _COMPOSITE_PATTERN
            Composite root = new Composite("root");
            root.Add(new Leaf("l Leaf"));
            root.Add(new Leaf("r Leaf"));

            Composite comp = new Composite("Compisite X");
            comp.Add(new Leaf("Composite X L Leaf"));
            comp.Add(new Leaf("Composite X R Leaf"));

            root.Add(comp);
            root.Add(new Leaf("m Leaf"));

            Leaf leaf = new Leaf("Leaf D");
            root.Add(leaf);
            root.Remove(leaf);

            root.Display(1);
            Console.ReadKey();
#endif
#if _FACADE_PATTERN
            Facade facade = new Facade();
            facade.MethodA();
            facade.MethodB();
            Console.ReadKey();
#endif
#if _FLY_WEIGHT_PATTERN
            int extrinsic_state = 22;
            FlyweightFactory factory = new FlyweightFactory();

            Flyweight fx = factory.GetFlyWeight("X");
            fx.Operation(--extrinsic_state);

            Flyweight fy = factory.GetFlyWeight("Y");
            fy.Operation(--extrinsic_state);

            UnsharedConcreteFlyweight fu = new UnsharedConcreteFlyweight();
            fu.Operation(--extrinsic_state);

            Console.ReadKey();
#endif
#if _PROXY_PATTERN
            Proxy proxy = new Proxy();
            proxy.Request();

            MathProxy mathProxy = new MathProxy();
            mathProxy.Add(4, 2);

            Console.ReadKey();
#endif
#if _FACTORY_PATTERN
            Creator[] creators = new Creator[2];
            creators[0] = new ConcreteCreatorA();
            creators[1] = new ConcreateCreatorB();

            foreach(Creator crea in creators)
            {
                Product product = crea.FactoryMethod();
                Console.WriteLine("Create {0}", product.GetType().Name);
            }

            Document[] docs = new Document[2];

            docs[0] = new Resume();
            docs[1] = new Report();

            foreach(Document document in docs)
            {
                Console.WriteLine("\n" + document.GetType().Name + "----");
                foreach(Page page in document.pages)
                {
                    Console.WriteLine("Page:" + page.GetType().Name);
                }
            }

            Console.ReadKey();
#endif
        }
    }
}
