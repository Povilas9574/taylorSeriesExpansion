
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaylorSeries.Command;

namespace TaylorSeries.UI.ConsoleUI
{
    class ConsoleUIController : IUIController
    {
        private readonly ICommandProcessor commandProcessor;
        private readonly IUIFactory uiFactory;
        private readonly Dictionary<string, ICommand> commands;

        public ConsoleUIController(Dictionary<string, ICommand> commands, ICommandProcessor commandProcessor, IUIFactory uiFactory)
        {
            this.commandProcessor = commandProcessor;
            this.uiFactory = uiFactory;
            this.commands = commands;
        }

        public void ShowMenu()
        {
            IDialogView dialogView = uiFactory.CreateDialogView();
            dialogView.ShowMessage("MENU");
            IMenuView menuView = uiFactory.CreateMenuView();
            List<string> menuItems = commands.Keys.ToList();

            menuItems.Add("Exit");

            while (true)
            {
                string result = menuView.ShowMenu(menuItems);
                int parsedResult = -1;
                if (int.TryParse(result,out parsedResult))
                {
                    
                    if (parsedResult <= commands.Count)
                    {
                        commandProcessor.Execute(commands.Values.ToList().ElementAt(parsedResult-1));
                       
                    }
                    else if (parsedResult == commands.Count + 1)
                    {
                        dialogView.ShowMessage("Exiting");
                        return;
                    }
                    else
                    {
                        dialogView.ShowMessage("No such menu item");
                    }
                }
                
            }
        }
    }
}
