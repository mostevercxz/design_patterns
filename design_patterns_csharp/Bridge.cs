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
    abstract class DataObject
    {
        public abstract void NextRecord();
        public abstract void PriorRecord();
        public abstract void AddRecord(string name);
        public abstract void DeleteRecord(string name);
        public abstract void ShowRecord();
        public abstract void ShowAllRecords();
    }

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
    }
}
