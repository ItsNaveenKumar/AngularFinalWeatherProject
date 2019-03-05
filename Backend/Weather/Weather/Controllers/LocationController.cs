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
    [Produces(" application/json")]
    public class LocationController : ControllerBase
    {
        private readonly LocationIDataRepository<SavedLocation> _dataRepository;

        public LocationController(LocationIDataRepository<SavedLocation> dataRepository)
        {
            _dataRepository = dataRepository;
        }
        // GET: api/<controller>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<SavedLocation> savedLocations = _dataRepository.GetAll();
            return Ok(savedLocations);
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            SavedLocation savedLocation = _dataRepository.Get(id);

            if (savedLocation == null)
            {
                return NotFound("The Location record couldn't be found.");
            }

            return Ok(savedLocation);
        }

        // POST api/<controller>
        public IActionResult Post([FromBody] SavedLocation savedLocation)
        {
            if (savedLocation == null)
            {
                return BadRequest("Location is null.");
            }

            _dataRepository.Add(savedLocation);
            return Ok(savedLocation);

        }



        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            SavedLocation savedLocation = _dataRepository.Get(id);
            if (savedLocation == null)
            {
                return NotFound("The Employee record couldn't be found.");
            }

            _dataRepository.Delete(savedLocation);
            return NoContent();
        }
    }
}
