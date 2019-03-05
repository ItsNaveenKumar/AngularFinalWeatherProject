using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Weather.Models.Repository;

namespace Weather.Models.DataManager
{
    public class UserLocationManager:UserLocationIDataRepository<UserLocation>
    {
        readonly dbContext _dbContext;

        public UserLocationManager(dbContext context)
        {
            _dbContext = context;
        }

        public IEnumerable<UserLocation> GetAll()
        {
            return _dbContext.UserLocations.ToList();
        }

        public IEnumerable<UserLocation> Get(long id)
        {

            return _dbContext.UserLocations.Where(e => e.UserId == id).ToList();
        }

        public void Add(UserLocation entity)
        {
            _dbContext.UserLocations.Add(entity);
            _dbContext.SaveChanges();
        }
        public void Delete(UserLocation id)
        {
            _dbContext.UserLocations.Remove(id);
            _dbContext.SaveChanges();
        }
    }
}
