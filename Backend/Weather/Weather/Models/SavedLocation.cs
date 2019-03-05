using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Weather.Models
{
    public class SavedLocation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long SavedLocationId { get; set; }
        public string CityName { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public ICollection<UserLocation> UserLocations { get; set; }

       
    }
}
