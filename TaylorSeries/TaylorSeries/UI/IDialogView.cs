using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaylorSeries.UI
{
    interface IDialogView
    {
        void ShowMessage(string message);
        List<string> ShowSelectionDialog(List< string> selections);
        string ShowSelectionDialogSelectOne(IEnumerable<string> arguments);
    }
}
