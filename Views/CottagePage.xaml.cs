using MokinVarausApp.Models;
using MySqlConnector;
using System;
using System.Collections.ObjectModel;

namespace MokinVarausApp
{
    public partial class CottagePage : ContentPage
    {
        private DatabaseConnector _dbConnector;
        private ObservableCollection<Cottage> _cottages;

        public CottagePage()
        {
            InitializeComponent();
            _dbConnector = new DatabaseConnector();
            LoadCottagesFromDatabase();
        }
        private async void OnDatabaseClicked(object sender, EventArgs e)
        {
            DatabaseConnector dbc = new DatabaseConnector();
            try
            {
                var conn = dbc._getConnection();
                conn.Open();
                await DisplayAlert("Onnistui", "Tietokanta yhteys aukesi", "OK");
            }
            catch (MySqlException ex)
            {
                await DisplayAlert("Failure", ex.Message, "OK");
            }
        }

        private void LoadCottagesFromDatabase()
        {
            _cottages = new ObservableCollection<Cottage>();
            using (var connection = _dbConnector._getConnection())
            {
                connection.Open();
                var query = "SELECT * FROM mokki";
                using (var cmd = new MySqlCommand(query, connection))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        _cottages.Add(new Cottage
                        {
                            Id = reader.GetInt32("mokki_id"),
                            Name = reader.GetString("mokkinimi"),
                            Description = reader.GetString("kuvaus"),
                            Price = reader.GetDecimal("hinta"),
                            AreaId = reader.GetInt32("alue_id")
                        });
                    }
                }
            }
            CottagesCollectionView.ItemsSource = _cottages;
        }

        private void OnAddCottageClicked(object sender, EventArgs e)
        {
            try
            {
                // Add your code to insert a new cottage into the database
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
            }
        }

        private void OnEditCottageClicked(object sender, EventArgs e)
        {
            // Add your code to handle editing a cottage
        }

        private void OnDeleteCottageClicked(object sender, EventArgs e)
        {
            // Add your code to delete a cottage from the database
        }
    }
}
