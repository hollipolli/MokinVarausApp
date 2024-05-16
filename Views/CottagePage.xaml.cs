using MokinVarausApp.Models;
using MokinVarausApp.Services;
using System.Collections.ObjectModel;

namespace MokinVarausApp
{
    public partial class CottagePage : ContentPage
    {
        private DataService _dataService;
        private ObservableCollection<Cottage> _cottages;

        public CottagePage()
        {
            InitializeComponent();
            _dataService = new DataService();
            _cottages = new ObservableCollection<Cottage>(_dataService.GetCottages());
            CottagesCollectionView.ItemsSource = _cottages;
        }

        private void OnAddCottageClicked(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(CottageNameEntry.Text) ||
                    string.IsNullOrWhiteSpace(CottageDescriptionEntry.Text) ||
                    string.IsNullOrWhiteSpace(CottagePriceEntry.Text) ||
                    string.IsNullOrWhiteSpace(CottageAreaIdEntry.Text))
                {
                    DisplayAlert("Error", "Please fill in all fields.", "OK");
                    return;
                }

                if (!decimal.TryParse(CottagePriceEntry.Text, out decimal price) || price <= 0)
                {
                    DisplayAlert("Error", "Please enter a valid positive price.", "OK");
                    return;
                }

                if (!int.TryParse(CottageAreaIdEntry.Text, out int areaId) || areaId <= 0)
                {
                    DisplayAlert("Error", "Please enter a valid positive area ID.", "OK");
                    return;
                }

                var newCottage = new Cottage
                {
                    Id = _cottages.Count + 1,
                    Name = CottageNameEntry.Text,
                    Description = CottageDescriptionEntry.Text,
                    Price = price,
                    AreaId = areaId
                };

                _dataService.AddCottage(newCottage);
                _cottages.Add(newCottage);
                CottageNameEntry.Text = string.Empty;
                CottageDescriptionEntry.Text = string.Empty;
                CottagePriceEntry.Text = string.Empty;
                CottageAreaIdEntry.Text = string.Empty;

                DisplayAlert("Success", "Cottage added successfully.", "OK");
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
            }
        }

        private void OnEditCottageClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var cottage = button.BindingContext as Cottage;

            // Populate the edit controls with cottage details
            EditCottageNameEntry.Text = cottage.Name;
            EditCottageDescriptionEntry.Text = cottage.Description;
            EditCottagePriceEntry.Text = cottage.Price.ToString();
            EditCottageAreaIdEntry.Text = cottage.AreaId.ToString();

            // Show the edit controls and hide the add controls
            EditCottageSection.IsVisible = true;
        }

        private void OnDeleteCottageClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var cottage = button.BindingContext as Cottage;

            _dataService.RemoveCottage(cottage.Id);
            _cottages.Remove(cottage);
        }
        private void OnSaveButtonClicked(object sender, EventArgs e)
        {
            if (CottagesCollectionView.SelectedItem != null)
            {
                // Update the cottage details
                var editedCottage = CottagesCollectionView.SelectedItem as Cottage;
                editedCottage.Name = EditCottageNameEntry.Text;
                editedCottage.Description = EditCottageDescriptionEntry.Text;
                editedCottage.Price = decimal.Parse(EditCottagePriceEntry.Text);
                editedCottage.AreaId = int.Parse(EditCottageAreaIdEntry.Text);

                

                // Hide the edit controls
                EditCottageSection.IsVisible = false;
            }
            else
            {
                // Inform the user to select a cottage before saving
                DisplayAlert("Error", "Please select a cottage to edit.", "OK");
            }
        }

        private void OnCancelButtonClicked(object sender, EventArgs e)
        {
            // Hide the edit controls
            EditCottageSection.IsVisible = false;
        }
    }
}
