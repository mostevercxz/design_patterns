using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace design_patterns_csharp
{
    abstract class Observer
    {
        public abstract void Update();
    }

    class ConcreteObserver : Observer
    {
        private string m_name;
        private string m_observerState;
        private ConcreteSubject m_sub;

        public ConcreteObserver(ConcreteSubject sub, string name)
        {
            m_sub = sub;
            m_name = name;
        }

        public override void Update()
        {
            m_observerState = m_sub.state;
            Console.WriteLine("Observer {0}'s new state is {1}", m_name, m_observerState);
        }
    }

    abstract class Subject
    {
        private List<Observer> m_objservers = new List<Observer>();

        public void Attach(Observer ob)
        {
            m_objservers.Add(ob);
        }

        public void Detach(Observer ob)
        {
            m_objservers.Remove(ob);
        }

        public void Notify()
        {
            foreach(Observer o in m_objservers)
            {
                o.Update();
            }
        }
    }

    class ConcreteSubject : Subject
    {
        private string m_subState;

        public string state
        {
            get { return m_subState; }
            set { m_subState = value; }
        }
    }//end of class ConcreteObject : Subject

    // Real-world examples, stock
    abstract class Stock
    {
        private string m_stockSymbol;
        private double m_stockPrice;
        private List<IInvestor> m_investors = new List<IInvestor>();

        public Stock(string symbol, double price)
        {
            m_stockSymbol = symbol;
            m_stockPrice = price;
        }

        public void Attach(IInvestor investor)
        {
            m_investors.Add(investor);
        }

        public void Detach(IInvestor investor)
        {
            m_investors.Remove(investor);
        }

        public void Notify()
        {
            foreach(IInvestor inv in m_investors)
            {
                inv.Update();
            }
        }

        public double stockPrice
        {
            get { return m_stockPrice; }
            set
            {
                double old = m_stockPrice;
                m_stockPrice = value;
                if(old != m_stockPrice)
                {
                    Notify();
                }
            }
        }
    }//end of abstract class Stock

    class IBM : Stock
    {
        public IBM(double price):
            base("ibm", price)
        {

        }
    }

    interface IInvestor
    {
        void Update();
    }//end of abstract interface IInvestor

    class Investor : IInvestor
    {
        private string m_investorName;
        private Stock m_stock;

        public Investor(string name, Stock stock)
        {
            m_investorName = name;
            m_stock = stock;
        }

        public void Update()
        {
            string content = "Old stock is " + m_stock.stockPrice.ToString();            
            content += " New stock is " + m_stock.stockPrice.ToString();
            Console.WriteLine(content);
        }
    }//end of class Investor : IInvestor

}
