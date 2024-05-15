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
            var newCottage = new Cottage
            {
                Id = _cottages.Count + 1,
                Name = CottageNameEntry.Text,
                Description = CottageDescriptionEntry.Text,
                Price = decimal.Parse(CottagePriceEntry.Text),
                AreaId = int.Parse(CottageAreaIdEntry.Text)
            };

            _dataService.AddCottage(newCottage);
            _cottages.Add(newCottage);
            CottageNameEntry.Text = string.Empty;
            CottageDescriptionEntry.Text = string.Empty;
            CottagePriceEntry.Text = string.Empty;
            CottageAreaIdEntry.Text = string.Empty;
        }

        private void OnEditCottageClicked(object sender, EventArgs e)
        {
            // Implement edit functionality
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
