
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaylorSeries.Command;

namespace TaylorSeries.UI
{
    interface IUIFactory
    {
        IUIController CreateController(Dictionary<string, ICommand> commands, ICommandProcessor processor);
        IMenuView CreateMenuView();

        IDialogView CreateDialogView();

        IMessagePrinter CreateMessagePrinter();
    }
}
