using Microsoft.Maui.Controls;
using MokinVarausApp.Models;
using MokinVarausApp.Services;
using System;
using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;

namespace MokinVarausApp
{
    public partial class RentPage : ContentPage
    {
        DateTime startDate;
        DateTime endDate;
        public RentPage()
        {
        }

        private void OnStartDateSelected(object sender, DateChangedEventArgs e)
        {
            startDate = e.NewDate;
        }

        private void OnEndDateSelected(object sender, DateChangedEventArgs e)
        {
            endDate = e.NewDate;
        }

        private void OnRentClicked(object sender, EventArgs e)
        {
            if (startDate >= endDate)
            {
                DisplayAlert("Error", "End date must be after start date.", "OK");
                return;
            }

            // Check availability of selected time range (You need to implement this)
            bool isAvailable = CheckAvailability(startDate, endDate);

            if (isAvailable)
            {
                // Proceed with renting the cottage
                DisplayAlert("Success", "Cottage rented successfully!", "OK");
            }
            else
            {
                DisplayAlert("Error", "The selected time range is not available.", "OK");
            }
        }

        private bool CheckAvailability(DateTime startDate, DateTime endDate)
        {
            // You need to implement this method to check the availability of the selected time range
            // For demonstration purposes, let's assume availability is always true
            return true;
        }
    }
}
