using Microsoft.Maui.Controls;
using MokinVarausApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace MokinVarausApp.Services
{
    public class DataService
    {
        private List<Area> _areas;
        private List<Cottage> _cottages;

        public DataService()
        {
            _areas = new List<Area>();
            _cottages = new List<Cottage>();
        }
        private async void OnEditClicked(object sender, EventArgs e)
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

            // Navigate to the edit page passing the item to edit <---- KÄYTÄ TÄTÄ TOISELLA PUOLELLA JOS EI TOIMI (EDIT PAGE)
            //await Navigation.PushAsync(new EditPage(editedItem));
        }

        // Area methods
        public void AddArea(Area area)
        {
            _areas.Add(area);
        }

        public void RemoveArea(int areaId)
        {
            var area = _areas.FirstOrDefault(a => a.alue_Id == areaId);
            if (area != null)
            {
                _areas.Remove(area);
            }
        }

        public void UpdateArea(Area updatedArea)
        {
            var area = _areas.FirstOrDefault(a => a.alue_Id == updatedArea.alue_Id);
            if (area != null)
            {
                area.nimi = updatedArea.nimi;
            }
        }

        public List<Area> GetAreas()
        {
            return _areas;
        }

        //Cottage methods
        public void AddCottage(Cottage cottage)
        {
            _cottages.Add(cottage);
        }

        public void RemoveCottage(int cottageId)
        {
            var cottage = _cottages.FirstOrDefault(c => c.Id == cottageId);
            if (cottage != null)
            {
                _cottages.Remove(cottage);
            }
        }

        public void UpdateCottage(Cottage updatedCottage)
        {
            var cottage = _cottages.FirstOrDefault(c => c.Id == updatedCottage.Id);
            if (cottage != null)
            {
                cottage.Name = updatedCottage.Name;
                cottage.Description = updatedCottage.Description;
                cottage.Price = updatedCottage.Price;
                cottage.AreaId = updatedCottage.AreaId;
            }
        }

        public List<Cottage> GetCottages()
        {
            return _cottages;
        }
    }
}
