using System;
using System.Drawing;
using System.Windows.Forms;

namespace TravelManager
{
    public class TripForm : Form
    {
        private Trip trip;
        private Button addExpenseButton;
        private Button displayDetailsButton;

        public TripForm(Trip trip)
        {
            this.trip = trip;
            this.Text = "Управление путешествием";
            this.Width = 300;
            this.Height = 150;
            CreateControls();
        }

        private void CreateControls()
        {
            addExpenseButton = new Button
            {
                Location = new Point(10, 20),
                Text = "Добавить расход",
                Size = new Size(120, 25)
            };
            addExpenseButton.Click += (sender, e) =>
            {
                var addExpenseForm = new AddExpenseForm();
                addExpenseForm.ShowDialog();
                if (addExpenseForm.DialogResult == DialogResult.OK)
                {
                    var expense = new Expense(addExpenseForm.Description, addExpenseForm.Amount);
                    trip.AddExpense(expense);
                }
            };

            displayDetailsButton = new Button
            {
                Location = new Point(140, 20),
                Text = "Показать детали",
                Size = new Size(120, 25)
            };
            displayDetailsButton.Click += (sender, e) => trip.DisplayTripDetails();

            this.Controls.Add(addExpenseButton);
            this.Controls.Add(displayDetailsButton);
        }
    }
}
