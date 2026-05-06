using System;
using System.Drawing;
using System.Windows.Forms;

namespace TravelManager
{
    public partial class TripReportForm : Form
    {
        private readonly Tip trip;

        public TripReportForm(Tip trip)
        {
            this.trip = trip;
            InitializeComponent();
            LoadTripData();
        }

        private void LoadTripData()
        {
            lblTripTitle.Text = "Отчёт: " + trip.Destination;
            destVal.Text = trip.Destination;
            startVal.Text = trip.StartDate.ToString("dd.MM.yyyy");
            endVal.Text = trip.EndDate.ToString("dd.MM.yyyy");
            durationVal.Text = trip.DurationDays() + " дн.";
            budVal.Text = trip.Budget.ToString("N0") + " руб.";
            decimal total = trip.CalculateTotalExpenses();
            decimal remaining = trip.RemainingBudget();
            totVal.Text = total.ToString("N0") + " руб.";
            remVal.Text = remaining.ToString("N0") + " руб.";
            remVal.ForeColor = remaining < 0 ? Color.Red : Color.FromArgb(16, 185, 129);
            int pct = trip.Budget > 0 ? (int)Math.Min((total / trip.Budget) * 100m, 100m) : 0;
            budgetBar.Value = pct;
            lblPct.Text = pct + "%  бюджета";
            lblPct.ForeColor = pct >= 90 ? Color.Red : pct >= 70 ? Color.DarkOrange : Color.Gray;
            expensesListView.Items.Clear();
            foreach (var exp in trip.Expenses)
            {
                var item = new ListViewItem(exp.Date.ToString("dd.MM.yyyy"));
                item.SubItems.Add(exp.Category);
                item.SubItems.Add(exp.Description);
                item.SubItems.Add(exp.Amount.ToString("N2"));
                expensesListView.Items.Add(item);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
