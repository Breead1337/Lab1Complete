using System;
using System.Collections.Generic;
using System.Linq;

namespace TravelManager
{
    public class Tip
    {
        public string Destination { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Budget { get; set; }
        public List<Expense> Expenses { get; private set; }

        public Tip(string destination, DateTime startDate, DateTime endDate, decimal budget)
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
        }

        public void RemoveExpense(Expense expense)
        {
            Expenses.Remove(expense);
        }

        public decimal CalculateTotalExpenses() => Expenses.Sum(e => e.Amount);

        public decimal RemainingBudget() => Budget - CalculateTotalExpenses();

        public int DurationDays() => (EndDate - StartDate).Days + 1;

        public decimal BudgetUsedPercent() =>
            Budget > 0 ? (CalculateTotalExpenses() / Budget) * 100m : 0m;

        public bool IsStartingSoon(int daysBeforeNotify)
        {
            double daysLeft = (StartDate - DateTime.Today).TotalDays;
            return daysLeft >= 0 && daysLeft <= daysBeforeNotify;
        }

        public bool IsOverdue()
        {
            return EndDate < DateTime.Today;
        }

        public override string ToString() =>
            $"{Destination} ({StartDate:dd.MM} – {EndDate:dd.MM.yyyy})";
    }
}
