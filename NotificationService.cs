using System;
using System.Collections.Generic;

namespace TravelManager
{
    public class NotificationService
    {
        private int _daysBeforeNotify;

        public NotificationService(int daysBeforeNotify = 3)
        {
            if (daysBeforeNotify < 0)
                throw new ArgumentException("Количество дней не может быть отрицательным");
            _daysBeforeNotify = daysBeforeNotify;
        }

        public int DaysBeforeNotify => _daysBeforeNotify;

        public bool IsEnabled { get; set; } = true;

        public void SetDaysBeforeNotify(int days)
        {
            if (days < 0)
                throw new ArgumentException("Количество дней не может быть отрицательным");
            _daysBeforeNotify = days;
        }

        public List<string> GetNotifications(List<Tip> trips)
        {
            var notifications = new List<string>();
            if (!IsEnabled) return notifications;
            foreach (var trip in trips)
            {
                if (trip.IsOverdue())
                {
                    notifications.Add(
                        $"Поездка в {trip.Destination} просрочена (окончание: {trip.EndDate:dd.MM.yyyy})");
                }
                else if (trip.IsStartingSoon(_daysBeforeNotify))
                {
                    int days = (int)(trip.StartDate - DateTime.Today).TotalDays;
                    notifications.Add(
                        $"Поездка в {trip.Destination} начнётся через {days} дн. ({trip.StartDate:dd.MM.yyyy})");
                }
            }
            return notifications;
        }
    }
}
