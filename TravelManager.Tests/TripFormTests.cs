using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Forms;
using TravelManager;

namespace TravelManager.Tests
{
    [TestClass]
    public class TripFormTests
    {
        private Trip _trip;
        private TripForm _form;

        [TestInitialize]
        public void SetUp()
        {
            _trip = new Trip("Барселона", new DateTime(2024, 7, 1), new DateTime(2024, 7, 10), 80000m);
            _form = new TripForm(_trip);
        }

        [TestCleanup]
        public void TearDown()
        {
            _form?.Dispose();
        }

        [TestMethod]
        public void Form_WhenCreated_TitleIsCorrect()
        {
            Assert.AreEqual("Управление путешествием", _form.Text);
        }

        [TestMethod]
        public void Form_WhenCreated_SizeIsSet()
        {
            Assert.AreEqual(300, _form.Width);
            Assert.AreEqual(150, _form.Height);
        }

        [TestMethod]
        public void AddExpenseButton_IsVisibleAndEnabled()
        {
            Button btn = null;
            foreach (Control c in _form.Controls)
                if (c is Button b && b.Text == "Добавить расход") { btn = b; break; }

            Assert.IsNotNull(btn, "Кнопка 'Добавить расход' не найдена");
            Assert.IsTrue(btn.Visible);
            Assert.IsTrue(btn.Enabled);
        }

        [TestMethod]
        public void DisplayDetailsButton_IsVisibleAndEnabled()
        {
            Button btn = null;
            foreach (Control c in _form.Controls)
                if (c is Button b && b.Text == "Показать детали") { btn = b; break; }

            Assert.IsNotNull(btn, "Кнопка 'Показать детали' не найдена");
            Assert.IsTrue(btn.Visible);
            Assert.IsTrue(btn.Enabled);
        }

        [TestMethod]
        public void Form_HasExactlyTwoButtons()
        {
            int count = 0;
            foreach (Control c in _form.Controls)
                if (c is Button) count++;

            Assert.AreEqual(2, count);
        }

        [TestMethod]
        public void Form_TripDataIsCorrect()
        {
            Assert.AreEqual("Барселона", _trip.Destination);
            Assert.AreEqual(80000m, _trip.Budget);
        }

        [TestMethod]
        public void Form_WhenCreated_TripHasNoExpenses()
        {
            Assert.AreEqual(0, _trip.Expenses.Count);
        }
    }
}
