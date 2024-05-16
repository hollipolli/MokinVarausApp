using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using Syncfusion.Maui.Calendar;

namespace MokinVarausApp.Views
{
    public partial class CalendarPage : ContentPage
    {
        public CalendarPage()
        {
            SfCalendar calendar = new SfCalendar();
            this.Content = calendar;

            InitializeComponent();
            LoadCalendar();
        }
        //vittu m‰ ostan viinaa eti t‰‰‰‰‰‰‰f adsigjfhknldsjklfgdskhjlfdsbhjnklfdskjnfdsnjk.lfdskljfdskljnfdwjklkmjlfdskmjfdsjkfdsjkfdsjkhfjkdskjfdsjkdfsjk
        private async void LoadCalendar()
        {
            var reservations = await GetReservationsAsync();
            var appointments = new List<CalendarInlineEvent>();

            foreach (var reservation in reservations)
            {
                for (DateTime date = reservation.ArrivalDate; date <= reservation.DepartureDate; date = date.AddDays(1))
                {
                    appointments.Add(new CalendarInlineEvent
                    {
                        StartTime = date,
                        EndTime = date,
                        Subject = "Reserved",
                        Color = Colors.Red
                    });
                }
            }

            Calendar.DataSource = appointments;
        }

        private async Task<List<Reservation>> GetReservationsAsync()
        {
            // Replace with your actual database access code
            await Task.Delay(500); // Simulate async delay
            return new List<Reservation>
            {
                new Reservation { ArrivalDate = new DateTime(2024, 5, 1), DepartureDate = new DateTime(2024, 5, 10) }
            };
        }

        public class Reservation
        {
            public DateTime ArrivalDate { get; set; }
            public DateTime DepartureDate { get; set; }
        }
    }
}
