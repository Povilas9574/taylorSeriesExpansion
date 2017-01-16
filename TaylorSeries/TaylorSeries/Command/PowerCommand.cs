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
    class PowerCommand : ICommand
    {
        private readonly IUIFactory uiFactory;
        public void Execute()
        {
            IMessagePrinter printer = uiFactory.CreateMessagePrinter();
            List<String> args = new List<string>();
            args.Add("Error");
            args.Add("Number");
            args.Add("Power");
            IDialogView dialog = uiFactory.CreateDialogView();
            List<string> results = dialog.ShowSelectionDialog(args);
            double number = 0;
            double error = 0;
            double power = 0;
            bool parsingfailed = false;
            if (!double.TryParse(results.ElementAt(0), out error))
            {
                parsingfailed = true;
                printer.Print("First input is not a number");
            }
            if (!double.TryParse(results.ElementAt(1), out number))
            {
                parsingfailed = true;
                printer.Print("Second input is not a number");
            }
            if (!double.TryParse(results.ElementAt(1), out power))
            {
                parsingfailed = true;
                printer.Print("Third input is not a number");
            }
            if (!parsingfailed)
            {
                ITaylorExpansion exp = new Power(error, number, power);
                Result result = exp.Calculate();
                if(result.Exist)
                {
                    printer.Print("Answer " + result.Answer);
                }
                else
                {
                    printer.Print("Answer does not exist");
                }
            }
        }
        public PowerCommand(IUIFactory fact)
        {
            this.uiFactory = fact;
        }
    }
}