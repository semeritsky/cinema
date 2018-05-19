using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.Repository.Model;
using Service.Repository;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace Service.Places
{
    public interface IPlacesService
    {
        Task SavePlace(Service.Repository.Model.Place place);
        Task<List<Service.Repository.Model.Place>> GetPlaces();
        Task<Repository.Model.Place> GetPlaceByRowAndPlaceNumber(int RowNumber, int PlaceNumber);
        Task Remove(Service.Repository.Model.Place place);
    }
    public class PlacesService : IPlacesService
    {
        private readonly Context _context;
        public PlacesService(Context context)
        {
            _context = context;
        }
        public async Task<List<Repository.Model.Place>> GetPlaces()
        {
            return await _context.Places.ToListAsync();
        }
        public async Task<Repository.Model.Place> GetPlaceByRowAndPlaceNumber(int RowNumber, int PlaceNumber)
        {
            return await _context.Places.Where(w=>w.PlaceNumber == PlaceNumber && w.Row == RowNumber).SingleOrDefaultAsync();
        }
        public async Task SavePlace(Repository.Model.Place place)
        {
            _context.Places.AddOrUpdate(place);
            await _context.SaveChangesAsync();
        }

        public async Task Remove(Place place)
        {
            _context.Entry(place).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}
