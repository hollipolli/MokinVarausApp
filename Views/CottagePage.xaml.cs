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
            var item = button.BindingContext as Cottage;

            // Create a copy of the item to edit
            var editedItem = new Cottage
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description,
                Price = item.Price,
                AreaId = item.AreaId
            };

            // Navigate to the edit page passing the item to edit
            //await Navigation.PushAsync(new EditPage(editedItem));
        }

        private void OnDeleteCottageClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var cottage = button.BindingContext as Cottage;

            _dataService.RemoveCottage(cottage.Id);
            _cottages.Remove(cottage);
        }
    }
}
