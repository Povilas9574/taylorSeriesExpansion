using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaylorSeries.MathSAF.MathSAF.Helpers;

namespace TaylorSeries
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            BernulliNumbers numbers = new BernulliNumbers();
            Console.WriteLine("{0:R}", numbers.BernulliNumber(0));
            Console.WriteLine("{0:R}", numbers.BernulliNumber(1));
            Console.WriteLine("{0:R}", numbers.BernulliNumber(2));
            Console.WriteLine("{0:R}", numbers.BernulliNumber(3));
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

           
        }
    }
}
