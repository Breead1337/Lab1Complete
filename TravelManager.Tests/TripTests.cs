using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TravelManager;

namespace TravelManager.Tests
{
    [TestClass]
    public class TripTests
    {
        private DateTime _startDate;
        private DateTime _endDate;

        [TestInitialize]
        public void SetUp()
        {
            _startDate = new DateTime(2024, 6, 1);
            _endDate   = new DateTime(2024, 6, 10);
        }

        [TestMethod]
        public void Constructor_WhenValidData_SetsPropertiesCorrectly()
        {
            var trip = new Trip("Париж", _startDate, _endDate, 50000m);

            Assert.AreEqual("Париж", trip.Destination);
            Assert.AreEqual(_startDate, trip.StartDate);
            Assert.AreEqual(_endDate, trip.EndDate);
            Assert.AreEqual(50000m, trip.Budget);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_WhenDestinationIsEmpty_ThrowsArgumentException()
        {
            new Trip("", _startDate, _endDate, 50000m);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_WhenEndDateBeforeStartDate_ThrowsArgumentException()
        {
            new Trip("Рим", _endDate, _startDate, 50000m);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_WhenBudgetIsZero_ThrowsArgumentException()
        {
            new Trip("Рим", _startDate, _endDate, 0m);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_WhenBudgetIsNegative_ThrowsArgumentException()
        {
            new Trip("Рим", _startDate, _endDate, -100m);
        }

        [TestMethod]
        public void Constructor_WhenCreated_ExpensesListIsEmpty()
        {
            var trip = new Trip("Берлин", _startDate, _endDate, 30000m);

            Assert.AreEqual(0, trip.Expenses.Count);
        }

        [TestMethod]
        public void CalculateTotalExpenses_WhenNoExpenses_ReturnsZero()
        {
            var trip = new Trip("Берлин", _startDate, _endDate, 30000m);

            Assert.AreEqual(0m, trip.CalculateTotalExpenses());
        }

        [TestMethod]
        public void CalculateTotalExpenses_WhenMultipleExpenses_ReturnsSumCorrectly()
        {
            var trip = new Trip("Берлин", _startDate, _endDate, 30000m);
            trip.Expenses.Add(new Expense("Отель", 12000m));
            trip.Expenses.Add(new Expense("Еда",    3000m));
            trip.Expenses.Add(new Expense("Такси",   500m));

            Assert.AreEqual(15500m, trip.CalculateTotalExpenses());
        }

        [TestMethod]
        public void RemainingBudget_WhenExpensesLessThanBudget_ReturnsPositive()
        {
            var trip = new Trip("Токио", _startDate, _endDate, 100000m);
            trip.Expenses.Add(new Expense("Авиабилет", 40000m));

            Assert.AreEqual(60000m, trip.RemainingBudget());
        }

        [TestMethod]
        public void RemainingBudget_WhenExpensesExceedBudget_ReturnsNegative()
        {
            var trip = new Trip("Токио", _startDate, _endDate, 10000m);
            trip.Expenses.Add(new Expense("Авиабилет", 40000m));

            Assert.IsTrue(trip.RemainingBudget() < 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddExpense_WhenExpenseIsNull_ThrowsArgumentNullException()
        {
            var trip = new Trip("Дубай", _startDate, _endDate, 20000m);

            trip.AddExpense(null);
        }

        [TestMethod]
        public void Expenses_WhenAddedDirectly_IncreasesCount()
        {
            var trip = new Trip("Прага", _startDate, _endDate, 25000m);

            trip.Expenses.Add(new Expense("Мутей", 500m));
            trip.Expenses.Add(new Expense("Ужин",  800m));

            Assert.AreEqual(2, trip.Expenses.Count);
        }
    }
}
