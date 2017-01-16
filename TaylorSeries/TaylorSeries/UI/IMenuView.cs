using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaylorSeries.UI
{
    interface IMenuView
    {
        string ShowMenu(List<string> menuItems);
    }
}
