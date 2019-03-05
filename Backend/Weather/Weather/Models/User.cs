using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Weather.Models;
namespace Weather.Models
{
    public class User
    {
        public long UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public long Mobile { get; set; }
        public ICollection<UserLocation> UserLocations { get; set; }

      
    }
}
