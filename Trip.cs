using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TravelManager
{
    public class Trip
    {
        public string Destination { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Budget { get; set; }
        public List<Expense> Expenses { get; set; }

        public Trip(string destination, DateTime startDate, DateTime endDate, decimal budget)
        {
            if (string.IsNullOrWhiteSpace(destination))
                throw new ArgumentException("Пункт назначения не может быть пустым");
            if (endDate < startDate)
                throw new ArgumentException("Дата окончания не может быть раньше даты начала");
            if (budget <= 0)
                throw new ArgumentException("Бюджет должен быть больше нуля");

            Destination = destination;
            StartDate = startDate;
            EndDate = endDate;
            Budget = budget;
            Expenses = new List<Expense>();
        }

        public void AddExpense(Expense expense)
        {
            if (expense == null) throw new ArgumentNullException(nameof(expense));
            Expenses.Add(expense);
            MessageBox.Show($"Расход добавлен: {expense.Amount} руб. - {expense.Description}");
        }

        public decimal CalculateTotalExpenses()
        {
            return Expenses.Sum(e => e.Amount);
        }

        public decimal RemainingBudget()
        {
            return Budget - CalculateTotalExpenses();
        }

        public void DisplayTripDetails()
        {
            var reportForm = new TripReportForm(this);
            reportForm.ShowDialog();
        }
    }
}
