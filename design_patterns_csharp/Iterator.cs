using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace design_patterns_csharp
{
    abstract class Iterator
    {
        public abstract object First();
        public abstract object Next();
        public abstract bool IsDone();
        public abstract object CurrentItem();
    }

    class ConcreteIterator : Iterator
    {
        private ConcreteAggregate m_aggre;
        private int m_current = 0;

        public ConcreteIterator(ConcreteAggregate agg)
        {
            m_aggre = agg;
        }

        public override object First()
        {
            return m_aggre[0];
        }

        public override object CurrentItem()
        {
            return m_aggre[m_current];
        }

        public override object Next()
        {
            object ret = null;
            if(m_current < m_aggre.Count - 1)
            {
                ret = m_aggre[++m_current];
            }

            return ret;
        }

        public override bool IsDone()
        {
            return m_current >= m_aggre.Count;
        }
    }

    abstract class Aggregate
    {
        public abstract Iterator CreateIterator();
    }

    class ConcreteAggregate : Aggregate
    {
        private System.Collections.ArrayList m_list = new System.Collections.ArrayList();

        public override Iterator CreateIterator()
        {
            return new ConcreteIterator(this);
        }

        public int Count
        {
            get { return m_list.Count; }
        }

        public object this[int index]
        {
            get { return m_list[index]; }
            set { m_list.Insert(index, value); }
        }
    }
}
