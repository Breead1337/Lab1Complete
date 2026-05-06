using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TravelManager
{
    public partial class Form1 : Form
    {
        private List<Tip> trips = new List<Tip>();

        public Form1()
        {
            InitializeComponent();
            LoadSampleData();
            RefreshList();
        }

        private void LoadSampleData()
        {
            var t1 = new Tip("Париж", new DateTime(2026, 6, 1), new DateTime(2026, 6, 8), 80000m);
            t1.AddExpense(new Expense("Авиабилеты", 25000m, "Транспорт", new DateTime(2026, 6, )));
            t1.AddExpense(new Expense("Отell (7 ночей)", 35000m, "Проживание", new DateTime(2026, 6, 1)));
            trips.Add(t1);

            var t2 = new Tip("Берлин", new DateTime(2026, 8, 15), new DateTime(2026, 8, 20), 50000m);
            trips.Add(t2);

            var t3 = new Tip("Токио", new DateTime(2026, 11, 1), new DateTime(2026, 11, 14), 200000m);
            trips.Add(t3);
        }

        private void RefreshList()
        {
            tripsListView.Items.Clear();
            foreach (var trip in trips)
            {
                var item = new ListViewItem(trip.Destination);
                item.SubItems.Add(trip.StartDate.ToString("dd.MM.yyyy"));
                item.SubItems.Add(trip.EndDate.ToString("dd.MM.yyyy"));
                item.SubItems.Add(trip.DurationDays() + " дн.");
                item.SubItems.Add(trip.Budget.ToString("N0") + " руб.");
                item.Tag = trip;
                tripsListView.Items.Add(item);
            }
            UpdateButtons();
            lblCount.Text = "Всего поездок: " + trips.Count;
        }

        private void UpdateButtons()
        {
            bool sel = tripsListView.SelectedItems.Count > 0;
            btnOpen.Enabled = sel;
            btnDelete.Enabled = sel;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var form = new AddTripForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    trips.Add(form.CreatedTrip);
                    RefreshList();
                }
            }
        }
    }
}
