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

        // Area methods
        public void AddArea(Area area)
        {
            _areas.Add(area);
        }

        public void RemoveArea(int areaId)
        {
            var area = _areas.FirstOrDefault(a => a.Id == areaId);
            if (area != null)
            {
                _areas.Remove(area);
            }
        }

        public void UpdateArea(Area updatedArea)
        {
            var area = _areas.FirstOrDefault(a => a.Id == updatedArea.Id);
            if (area != null)
            {
                area.Name = updatedArea.Name;
                area.Description = updatedArea.Description;
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
