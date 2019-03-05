using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Weather.Models;
using Weather.Models.Repository;

namespace UnitTestApi
{
    class UserTest: IDataRepository<User>
    {
        private readonly List<User> _UserList;
       

        public UserTest()
        {
            _UserList = new List<User>()
            {
                new User() { UserId =1,
                    Name = "Naveen", Email="naveen@gmail.com", Password = "asdfghjkl",Mobile=7053207025 },
              new User() { UserId =2,
                    Name = "Giri", Email="giri@gmail.com", Password = "qwerty",Mobile=7894561230 },
               new User() { UserId =3,
                    Name = "Babu", Email="babu@gmail.com", Password = "zxcvbn",Mobile=9874563210 },
            };
        }

        public IEnumerable<User> GetAll()
        {
            return _UserList;
        }

        public User Get(string email)
        {
            return _UserList.Where(a => a.Email == email)
            .FirstOrDefault();
        }

        public void Add(User userItem)
        {
            _UserList.Add(userItem);
            
        }

        public void Update(User user, User entity)
        {
            user.Name = entity.Name;
            user.Email = entity.Email;
            user.Password = entity.Password;
            user.Mobile = entity.Mobile;

          
        }


    }
}
