using Microsoft.Maui.Controls;
using MokinVarausApp.Models;
using MokinVarausApp.Services;
using System;
using System.Collections.ObjectModel;

namespace MokinVarausApp
{
    public partial class AreaPage : ContentPage
    {
        private DataService _dataService;
        private ObservableCollection<Area> _areas;

        public AreaPage()
        {
            InitializeComponent();
            _dataService = new DataService();
            _areas = new ObservableCollection<Area>(_dataService.GetAreas());
            AreasCollectionView.ItemsSource = _areas;
        }

        private void OnAddAreaClicked(object sender, EventArgs e)
        {
            var newArea = new Area
            {
                alue_Id = _areas.Count + 1,
                nimi = AreaNameEntry.Text,
            };

            _dataService.AddArea(newArea);
            _areas.Add(newArea);
            AreaNameEntry.Text = string.Empty;
            AreaDescriptionEntry.Text = string.Empty;
        }

        private void OnEditAreaClicked(object sender, EventArgs e)
        {
            // Implement edit functionality
        }

        private void OnDeleteAreaClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var area = button.BindingContext as Area;

            _dataService.RemoveArea(area.alue_Id);
            _areas.Remove(area);
        }
    }
}