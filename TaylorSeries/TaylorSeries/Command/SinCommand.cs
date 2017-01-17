﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaylorSeries.MathSAF.MathSAF.TaylorSeriesExpansions.TrigonometricalExpansions.BaseExpansions;
using TaylorSeries.MathSAF.MathSAF.TaylorSeriesExpansionsAPI;
using TaylorSeries.UI;

namespace TaylorSeries.Command
{
    class SinCommand : ICommand
    {
        private readonly IUIFactory uiFactory;
        public void Execute()
        {
            IMessagePrinter printer = uiFactory.CreateMessagePrinter();
            List<String> args = new List<string>();
            args.Add("Number");
            args.Add("Error");

            IDialogView dialog = uiFactory.CreateDialogView();
            List<string> results = dialog.ShowSelectionDialog(args);
            double number = 0;
            double error = 0;
            if (!double.TryParse(results.ElementAt(0), out number))
            {
                printer.Print("First input is not a number");
            }
            if (!double.TryParse(results.ElementAt(1), out error))
            {
                printer.Print("Second input is not a number");
            }
            ITaylorExpansion exp = new SinExpansion(number, error);
            Result result = exp.Calculate();

            printer.Print("Answer " + result.Answer);
        }

        public SinCommand(IUIFactory fact)
        {
            this.uiFactory = fact;
        }
    }
}
