using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TravelManager
{
    public class TripReportForm : Form
    {
        private readonly Trip trip;

        public TripReportForm(Trip trip)
        {
            this.trip = trip;
            this.Text = "Отчёт по путешествию";
            this.Width = 400;
            this.Height = 300;
            CreateControls();
        }

        private void CreateControls()
        {
            var destLabel  = new Label { Location = new Point(10, 10),  Text = "Пункт назначения:", AutoSize = true };
            var startLabel = new Label { Location = new Point(10, 35),  Text = "Дата начала:",       AutoSize = true };
            var endLabel   = new Label { Location = new Point(10, 60),  Text = "Дата окончания:",    AutoSize = true };
            var budLabel   = new Label { Location = new Point(10, 85),  Text = "Бюджет:",            AutoSize = true };
            var totLabel   = new Label { Location = new Point(10, 110), Text = "Общие расходы:",     AutoSize = true };
            var remLabel   = new Label { Location = new Point(10, 135), Text = "Осталось:",          AutoSize = true };

            var destVal  = new Label { Location = new Point(160, 10),  Text = trip.Destination,                         AutoSize = true };
            var startVal = new Label { Location = new Point(160, 35),  Text = trip.StartDate.ToString("dd.MM.yyyy"),     AutoSize = true };
            var endVal   = new Label { Location = new Point(160, 60),  Text = trip.EndDate.ToString("dd.MM.yyyy"),       AutoSize = true };
            var budVal   = new Label { Location = new Point(160, 85),  Text = $"{trip.Budget} руб.",                    AutoSize = true };
            var totVal   = new Label { Location = new Point(160, 110), Text = $"{trip.CalculateTotalExpenses()} руб.",   AutoSize = true };
            var remVal   = new Label { Location = new Point(160, 135), Text = $"{trip.RemainingBudget()} руб.",          AutoSize = true };

            var listBox = new ListBox { Location = new Point(10, 165), Size = new Size(360, 100) };
            foreach (var exp in trip.Expenses)
                listBox.Items.Add($"{exp.Description} — {exp.Amount} руб.");

            this.Controls.AddRange(new Control[] {
                destLabel, startLabel, endLabel, budLabel, totLabel, remLabel,
                destVal,  startVal,  endVal,  budVal,  totVal,  remVal,
                listBox
            });
        }
    }
}
