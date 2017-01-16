using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaylorSeries.UI.ConsoleUI
{
    class ConsolePrinter : IMessagePrinter
    {
        public void Print(string message)
        {
            Console.WriteLine(message);
        }
    }
}
