﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaylorSeries.Command;
using TaylorSeries.MathSAF.MathSAF.Helpers;
using TaylorSeries.MathSAF.MathSAF.TaylorSeriesExpansions.LogarithmicExpansion;
using TaylorSeries.UI;
using TaylorSeries.UI.ConsoleUI;

namespace TaylorSeries
{
    static class Program
    {

        static void Main()
        {

            ICommandProcessor processor = new CommandProcessor();

            IUIFactory uiFactory = new UIFactory();

            var commands = new Dictionary<string, ICommand>
            {
                {"Logarithm", new LogartihmCommand(uiFactory)},
                {"Arctg", new ArctgCommand(uiFactory) },
                {"Arcctg", new ArcctgCommand(uiFactory) },
                {"Arcsin", new ArcsinCommand(uiFactory) },
                {"Arccos", new ArccosCommand(uiFactory) },
                {"Coth", new HiperbolicalCothCommand(uiFactory) },
                {"Tanh", new HiperbolicalTanhCommand(uiFactory) },
                {"Sinh", new HiperbolicalSinhCommand(uiFactory) },
                {"Cosh", new HiperbolicalCoshCommand(uiFactory) },
                {"Power", new PowerCommand(uiFactory) },
                {"Pi", new PiCommand(uiFactory) }
            };

            var controller = uiFactory.CreateController(commands, processor);
            controller.ShowMenu();
        }
    }
}
