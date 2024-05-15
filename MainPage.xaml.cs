using Microsoft.Maui.Controls;
using MokinVarausApp.Models;
using MokinVarausApp.Services;
using MokinVarausApp.Views;
using System;
using System.Collections.ObjectModel;

namespace MokinVarausApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnAreaPageClicked(object sender, EventArgs e)
        {
            // Navigate to AreaPage
            Navigation.PushAsync(new AreaPage());
        }

        private void OnCottagePageClicked(object sender, EventArgs e)
        {
            // Navigate to CottagePage
            Navigation.PushAsync(new CottagePage());
        }

        private void OnRentPageClicked(object sender, EventArgs e)
        {
            // Navigate to RentPage
            Navigation.PushAsync(new RentPage());
        }

        private void OnCalendarPageClicked(object sender, EventArgs e)
        {
            // Navigate to CalendarPage
            Navigation.PushAsync(new CalendarPage());
        }
    }
}
