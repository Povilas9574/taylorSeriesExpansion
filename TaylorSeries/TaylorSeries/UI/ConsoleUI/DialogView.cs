using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaylorSeries.UI.ConsoleUI
{
    class DialogView : IDialogView
    {
        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }

        public List<string> ShowSelectionDialog(List<string> selections)
        {
            List<string> results = new List<string>();
            foreach (string argument in selections)
            {
                Console.WriteLine(argument);
                results.Add(Console.ReadLine());
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            return results;
        }

        public string ShowSelectionDialogSelectOne(IEnumerable<string> arguments)
        {
            string result;
            Console.WriteLine("Select:");
            foreach (var argument in arguments)
            {
                Console.WriteLine(argument);
            }
            result = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            return result;
        }
    }
}


