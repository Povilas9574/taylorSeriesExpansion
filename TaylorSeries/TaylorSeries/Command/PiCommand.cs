using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaylorSeries.MathSAF.MathSAF.TaylorSeriesExpansions;
using TaylorSeries.MathSAF.MathSAF.TaylorSeriesExpansionsAPI;
using TaylorSeries.UI;
namespace TaylorSeries.Command
{
    class PiCommand : ICommand
    {
        private readonly IUIFactory uiFactory;
        public void Execute()
        {
            IMessagePrinter printer = uiFactory.CreateMessagePrinter();
            List<String> args = new List<string>();
            args.Add("Error");
            IDialogView dialog = uiFactory.CreateDialogView();
            List<string> results = dialog.ShowSelectionDialog(args);
            double error = 0;
            bool parsingfailed = false;
            if (!double.TryParse(results.ElementAt(0), out error))
            {
                parsingfailed = true;
                printer.Print("First input is not a number");
            }
            if (!parsingfailed)
            {
                ITaylorExpansion exp = new Pi(error);
                Result result = exp.Calculate();
                printer.Print("Answer " + result.Answer);
            }
        }
        public PiCommand(IUIFactory fact)
        {
            this.uiFactory = fact;
        }
    }
}