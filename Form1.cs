using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace TravelManager
{
    public partial class Form1 : Form
    {
        private List<Tip> trips = new List<Tip>();
        private NotificationService notificationService = new NotificationService(3);

        public Form1()
        {
            InitializeComponent();

            LoadTrips();

            if (trips.Count == 0)
            {
                LoadSampleData();
            }

            RefreshList();

            ShowNotifications();
        }

        private void LoadSampleData()
        {
            var t1 = new Tip("Париж", DateTime.Today.AddDays(60), DateTime.Today.AddDar�)�
            t.AddExpense(new Expense("Авиабилеты", 500m));
            trips.Add(t1);

            var t2 = new Tip("Токио", DateTime.Today.AddDar�(365), DateTime.Today.AddDays(372), 3000m);
            trips.Add