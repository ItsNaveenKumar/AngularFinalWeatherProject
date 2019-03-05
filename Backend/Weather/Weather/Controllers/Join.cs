using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Weather.Models;
using Weather.Models.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Weather.Controllers
{

    [Route("api/[controller]")]
    public class JoinController : ControllerBase
    {
        private readonly UserLocationIDataRepository<UserLocation> _dataRepository;
        private readonly IDataRepository<User> _UserdataRepository;
        private readonly LocationIDataRepository<SavedLocation> _LocationdataRepository;
        public JoinController(UserLocationIDataRepository<UserLocation> dataRepository, IDataRepository<User> UserdataRepository, LocationIDataRepository<SavedLocation> LocationdataRepository)
        {
            _dataRepository = dataRepository;
            _UserdataRepository = UserdataRepository;
            _LocationdataRepository = LocationdataRepository;
        }
        // GET: api/<controller>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var Users = _UserdataRepository.GetAll();
            var Locations = _LocationdataRepository.GetAll();
            var SavedLocations = _dataRepository.GetAll();
            var query = from User in Users
                        join SavedLocation in SavedLocations on User.UserId equals SavedLocation.UserId
                        join UserLocation in Locations on SavedLocation.SavedLocationId equals UserLocation.SavedLocationId
                        where User.UserId == id
                        select new
                        {
                            UserLocation.CityName
                        };
            return Ok(query);
        }

        // GET api/<controller>/5

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
