using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Weather.Models.Repository;

namespace Weather.Models.DataManager
{
    public class LocationManager: LocationIDataRepository<SavedLocation>
    {
        readonly dbContext _dbContext;

        public LocationManager(dbContext context)
        {
            _dbContext = context;
        }

        public IEnumerable<SavedLocation> GetAll()
        {
            return _dbContext.SavedLocations.ToList();
        }

        public SavedLocation Get(long id)
        {
            return _dbContext.SavedLocations.FirstOrDefault(e => e.SavedLocationId == id);
        }

        public void Add(SavedLocation entity)
        {
            _dbContext.SavedLocations.Add(entity);
            _dbContext.SaveChanges();
        }
        public void Delete(SavedLocation saved)
        {
            _dbContext.SavedLocations.Remove(saved);
            _dbContext.SaveChanges();
        }
    }
}
