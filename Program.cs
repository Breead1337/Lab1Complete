using System;
using System.Windows.Forms;

namespace TravelManager
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var trip = new Trip("Париж", DateTime.Now, DateTime.Now.AddDays(7), 50000m);
            Application.Run(new TripForm(trip));
        }
    }
}
