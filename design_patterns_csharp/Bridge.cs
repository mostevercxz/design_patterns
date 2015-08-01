using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace design_patterns_csharp
{
    class Bridge
    {
    }

    abstract class Implementor
    {
        public abstract void Operation();
    }

    class Abstraction
    {
        protected Implementor m_impl;

        public Implementor impl
        {
            set
            {
                m_impl = value;
            }
        }

        public virtual void Operation()
        {
            m_impl.Operation();
        }
    }

    class RefinedAbstraction : Abstraction
    {
        public override void Operation()
        {
            m_impl.Operation();
        }
    }

    class ConcreteImplementorA : Implementor
    {
        public override void Operation()
        {
            Console.WriteLine("ConcreteImplementorA operation");
        }
    }

    class ConcreteImplementorB : Implementor
    {
        public override void Operation()
        {
            Console.WriteLine("ConcreteImplementorB operation");
        }
    }

    // Real-world examples
    // Implementor Abstraction class
    abstract class DataObject
    {
        public abstract void NextRecord();
        public abstract void PriorRecord();
        public abstract void AddRecord(string name);
        public abstract void DeleteRecord(string name);
        public abstract void ShowRecord();
        public abstract void ShowAllRecords();
    }

    // Implementator DataObject Concrete implementation
    class CustomerData : DataObject
    {
        private List<string> _customers = new List<string>();
        private int _current = 0;

        public CustomerData()
        {
            // maybe load from database
            _customers.Add("Customer1");
            _customers.Add("Customer2");
            _customers.Add("Customer3");
            _customers.Add("Customer4");
        }

        public override void NextRecord()
        {
            if(_current < _customers.Count - 1)
            {
                ++_current;
            }
        }

        public override void PriorRecord()
        {
            if(_current > 0)
            {
                --_current;
            }
        }

        public override void AddRecord(string name)
        {
            _customers.Add(name);
        }

        public override void DeleteRecord(string name)
        {
            if(_customers.Contains(name))
            {
                _customers.Remove(name);
            }
        }

        public override void ShowRecord()
        {
            Console.WriteLine(_customers[_current]);
        }

        public override void ShowAllRecords()
        {
            foreach(string cus in _customers)
            {
                Console.WriteLine(cus);
            }
        }
    }

    // Abstraction class
    class CustomerBase
    {
        private DataObject m_dataObj;
        protected string m_group;

        public CustomerBase(string group)
        {
            this.m_group = group;
        }

        public DataObject data
        {
            set { m_dataObj = value; }
            get { return m_dataObj; }
        }

        public virtual void Next()
        {
            m_dataObj.NextRecord();
        }

        public virtual void Prior()
        {
            m_dataObj.PriorRecord();
        }

        public virtual void Add(string customer)
        {
            m_dataObj.AddRecord(customer);
        }

        public virtual void Delete(string customer)
        {
            m_dataObj.DeleteRecord(customer);
        }

        public virtual void Show()
        {
            m_dataObj.ShowRecord();
        }

        public virtual void ShowAll()
        {
            m_dataObj.ShowAllRecords();
        }
    }

    // Refined Abstraction class
    class Customers : CustomerBase
    {
        public Customers(string group) : 
            base(group)
        {

        }

        public override void ShowAll()
        {
            Console.Write("\n------------\n");
            base.ShowAll();
            Console.WriteLine("-----------------");
        }
    }
}
