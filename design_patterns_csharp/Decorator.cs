using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace design_patterns_csharp
{
    // defines the interface for objects that can have responsibilities added to them dynamically
    abstract class Component
    {
        public abstract void Operation();
    }

    // defines an object to which additional responsibilities can be attached
    class ConcreteComponent : Component
    {
        public override void Operation()
        {
            Console.WriteLine("ConcreteCompnonet.Operation() do something");
        }
    }

    // maintains a reference  to a Component object and 
    // defines an interface that conforms to Component's interface
    abstract class Decorator : Component
    {
        protected Component m_component;

        public void SetComponent(Component com)
        {
            m_component = com;
        }

        public override void Operation()
        {
            if(m_component != null)
            {
                m_component.Operation();
            }
        }
    }

    // The concrete decoratoor that do somethings
    class ConcreteDecoratorA : Decorator
    {
        public override void Operation()
        {
            base.Operation();
            Console.WriteLine("ConcreteDecoratorA.Operation()");
        }
    }

    class ConcreateDecoratorB : Decorator
    {
        public override void Operation()
        {
            base.Operation();
            Console.WriteLine("ConcreateDecoratorB.Operation()");
        }
    }

    /// <summary>
    /// Real-world examples
    /// </summary>
    
    // Similar to the Component abstract class
    abstract class LibraryItem
    {
        private int m_numOfCopies;

        public int NumCopies
        {
            set;
            get;
        }

        public abstract void Display();
    }

    // Similar to the ConcerteComponent class
    class Book : LibraryItem
    {
        private string m_author;
        private string m_title;

        public Book(string author, string title, int numCopies)
        {
            m_author = author;
            m_title = title;
            this.NumCopies = numCopies;
        }

        public override void Display()
        {
            string content = "\n ---Book--- Author : {0}, Title : {1}, Number of copies:{2}";
            string writeContent = String.Format(content, this.m_author, this.m_title, this.NumCopies);
            Console.Write(writeContent);
        }
    }

    // Similar to the ConcerteComponent class
    class Viedo : LibraryItem
    {
        private string m_director;
        private string m_title;
        private int m_playedTimes;

        public Viedo(string director, string title, int copies, int times)
        {
            this.NumCopies = copies;
            m_director = director;
            m_title = title;
            m_playedTimes = times;
        }

        public override void Display()
        {
            string content = "\n ---Viedo--- Director:{0}, Title:{1}, Copies:{2}, PlayTimes:{3}";
            string writeContent = String.Format(content, this.m_director, this.m_title, this.NumCopies, this.m_playedTimes);
            Console.Write(writeContent);
        }
    }

    // Similar to the Decorator class
    abstract class RealWorldDecorator : LibraryItem
    {
        protected LibraryItem m_librarItem;

        public RealWorldDecorator(LibraryItem item)
        {
            m_librarItem = item;
        }

        public override void Display()
        {
            m_librarItem.Display();
        }
    }

    // Similar to the ConcreteDecorator class
    class Borrowable : RealWorldDecorator
    {
        protected List<string> borrowers = new List<string>();

        public Borrowable(LibraryItem item)
            : base(item)
        {

        }

        public void BorrowItem(string name)
        {
            borrowers.Add(name);
            --m_librarItem.NumCopies;
        }

        public void ReturnItem(string name)
        {
            borrowers.Remove(name);
            ++m_librarItem.NumCopies;
        }

        public override void Display()
        {
            base.Display();

            foreach(string borrower in borrowers)
            {
                Console.WriteLine("The borrower is " + borrower);
            }
        }
    }
}
