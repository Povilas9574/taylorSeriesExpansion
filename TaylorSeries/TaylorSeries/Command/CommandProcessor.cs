
using System.Collections.Generic;

namespace TaylorSeries.Command
{
    class CommandProcessor : ICommandProcessor
    {
        Stack<ICommand> commandStack = new Stack<ICommand>();
        public void Execute(ICommand command)
        {
            command.Execute();

        }


    }
}

