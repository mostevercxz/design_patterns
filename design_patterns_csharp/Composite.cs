using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace design_patterns_csharp
{


    // Component abstract class
    abstract class Component
    {
        protected string m_name;

        public Component(string name)
        {
            m_name = name;
        }

        public abstract void Add(Component c);
        public abstract void Remove(Component c);
        public abstract void Display(int depth);
    }

    // The Leaf class
    class Leaf : Component
    {
        public Leaf(string name):
            base(name)
        {

        }

        public override void Add(Component c)
        {
            Console.WriteLine("Can not add to a leaf");
        }

        public override void Remove(Component c)
        {
            Console.WriteLine("Can not Remove from a leaf");
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + m_name);
        }
    }//end The Leaf class

    // The Composite class
    class Composite : Component
    {
        private List<Component> _children = new List<Component>();

        public Composite(string name)
            : base(name)
        { }

        public override void Add(Component c)
        {
            _children.Add(c);
        }

        public override void Remove(Component c)
        {
            _children.Remove(c);
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + m_name);
            foreach(Component c in _children)
            {
                c.Display(depth + 2);
            }
        }
    }//End The Composite class

    // Real-world example, the real-world example is the same as the Composite example...
}
