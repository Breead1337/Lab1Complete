using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TravelManager;

namespace TravelManager.Tests
{
    [TestClass]
    public class ExpenseTests
    {
        [TestMethod]
        public void Constructor_WhenValidData_SetsPropertiesCorrectly()
        {
            var expense = new Expense("Отель", 4500m);

            Assert.AreEqual("Отель", expense.Description);
            Assert.AreEqual(4500m, expense.Amount);
        }

        [TestMethod]
        public void Constructor_WhenZeroAmount_SetsAmountToZero()
        {
            var expense = new Expense("Бесплатный трансфер", 0m);

            Assert.AreEqual(0m, expense.Amount);
        }

        [TestMethod]
        public void Description_CanBeUpdated()
        {
            var expense = new Expense("Еда", 300m);

            expense.Description = "Ресторан";

            Assert.AreEqual("Ресторан", expense.Description);
        }

        [TestMethod]
        public void Amount_CanBeUpdated()
        {
            var expense = new Expense("Такси", 200m);

            expense.Amount = 350m;

            Assert.AreEqual(350m, expense.Amount);
        }

        [TestMethod]
        public void Constructor_WhenNegativeAmount_SetsNegativeAmount()
        {
            var expense = new Expense("Воврат", -1000m);

            Assert.AreEqual(-1000m, expense.Amount);
        }
    }
}
