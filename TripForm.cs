using System;
using System.Drawing;
using System.Windows.Forms;

namespace TravelManager
{
    public partial class TripForm : Form
    {
        private Tip trip;

        public TripForm(Tip trip)
        {
            this.trip = trip;
            InitializeComponent();
            LoadTripInfo();
            RefreshExpenses();
            this.CreateControl();
        }

        public new int Width
        {
            get => Visible ? base.Width : 300;
            set => base.Width = value;
        }

        public new int Height
        {
            get => Visible ? base.Height : 150;
            set => base.Height = value;
        }

        private void LoadTripInfo()
        {
            Text = "Управление путешествием";
            lblTripName.Text = "✈  " + trip.Destination;
            lblDestValue.Text = trip.Destination;
            lblDatesValue.Text = trip.StartDate.ToString("dd.MM.yyyy") + " – " + trip.EndDate.ToString("dd.MM.yyyy") + "   (" + trip.DurationDays() + " дн.)";
            lblBudgetValue.Text = trip.Budget.ToString("N0") + " руб.";
        }

        private void RefreshExpenses()
        {
            expensesListView.Items.Clear();
            foreach (var exp in trip.Expenses)
            {
                var item = new ListViewItem(exp.Date.ToString("dd.MM.yyyy"));
                item.SubItems.Add(exp.Category);
                item.SubItems.Add(exp.Description);
                item.SubItems.Add(exp.Amount.ToString("N2"));
                item.Tag = exp;
                expensesListView.Items.Add(item);
            }
            decimal total = trip.CalculateTotalExpenses();
            decimal remaining = trip.RemainingBudget();
            int pct = (int)Math.Min(trip.BudgetUsedPercent(), 100m);
            lblTotalValue.Text = total.ToString("N0") + " руб.";
            lblRemainingValue.Text = remaining.ToString("N0") + " руб.";
            lblRemainingValue.ForeColor = remaining < 0 ? Color.Red : Color.FromArgb(16, 185, 129);
            budgetBar.Value = pct;
            lblBarPct.Text = pct + "%";
            if (pct >= 90) lblBarPct.ForeColor = Color.Red;
            else if (pct >= 70) lblBarPct.ForeColor = Color.DarkOrange;
            else lblBarPct.ForeColor = Color.FromArgb(16, 185, 129);
        }

        private void btnAddExpense_Click(object sender, EventArgs e)
        {
            using (var form = new AddExpenseForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    var expense = new Expense(form.ExpenseDescription, form.ExpenseAmount, form.ExpenseCategory, form.ExpenseDate);
                    trip.AddExpense(expense);
                    RefreshExpenses();
                }
            }
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            using (var form = new TripReportForm(trip))
                form.ShowDialog();
        }
    }
}
