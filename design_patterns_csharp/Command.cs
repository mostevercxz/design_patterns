using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace design_patterns_csharp
{
    class Receiver
    {
        public void Action()
        {
            Console.WriteLine("call Receiver.Action()");
        }
    }

    abstract class Command
    {
        protected Receiver m_recv;

        public Command(Receiver recv)
        {
            m_recv = recv;
        }

        public abstract void Execute();
    }

    class ConcreteCommand : Command
    {
        public ConcreteCommand(Receiver recv)
            :base(recv)
        {

        }

        public override void Execute()
        {
            m_recv.Action();
        }
    }

    class Invoker
    {
        private Command m_command;

        public void SetCommand(Command command)
        {
            m_command = command;
        }

        public void ExecuteCommand()
        {
            m_command.Execute();
        }
    }
}
