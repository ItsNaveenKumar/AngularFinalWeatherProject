using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Weather.Models.Repository;

namespace Weather.Models.DataManager
{
    public class UserManager:IDataRepository<User>
    {
        readonly dbContext _dbContext;

        public UserManager(dbContext context)
        {
            _dbContext = context;
        }

        public IEnumerable<User> GetAll()
        {
            return _dbContext.Users.ToList();
        }

        public User Get(string email)
        {
            return _dbContext.Users.FirstOrDefault(e => e.Email == email);
        }

        public void Add(User entity)
        {
            _dbContext.Users.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Update(User user, User entity)
        {
            user.Name = entity.Name;
            user.Email = entity.Email;
            user.Password = entity.Password;
            user.Mobile = entity.Mobile;

            _dbContext.SaveChanges();
        }

      
    }
}
