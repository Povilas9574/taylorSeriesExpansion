using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TaylorSeries.Command;

namespace TaylorSeries.UI.ConsoleUI
{
    class UIFactory : IUIFactory
    {
        public IUIController CreateController(Dictionary<string, ICommand> commands, ICommandProcessor processor)
        {
            return new ConsoleUIController(commands, processor, this);
        }

        public IDialogView CreateDialogView()
        {
            return new DialogView();
        }

        public IMenuView CreateMenuView()
        {
            return new MenuView();
        }

        public IMessagePrinter CreateMessagePrinter()
        {
            return new ConsolePrinter();
        }
    }
}
