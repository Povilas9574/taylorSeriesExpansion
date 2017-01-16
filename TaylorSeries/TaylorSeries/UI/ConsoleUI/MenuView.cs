using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaylorSeries.UI.ConsoleUI
{
    class MenuView : IMenuView
    {
        public string ShowMenu(List<string> menuItems)
        {
            int id = 1;
            foreach (string item in menuItems)
            {
                Console.WriteLine(id + " " + item);
                id++;
            }
            return Console.ReadLine();
        }
    }
}
