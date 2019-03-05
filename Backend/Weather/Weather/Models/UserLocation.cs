using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Weather.Models;
namespace Weather.Models
{
    public class UserLocation
    {
        public long Id { get; set; }

        [ForeignKey("User")]
        public long UserId { get; set; }
        public  User User { get; set; }
 
        public long SavedLocationId { get; set; }
        
               
    }
}
