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
    public class SavedLocationController : ControllerBase

    {
        private readonly UserLocationIDataRepository<UserLocation> _dataRepository;

        public SavedLocationController(UserLocationIDataRepository<UserLocation> dataRepository)
        {
            _dataRepository = dataRepository;
        }
        // GET: api/<controller>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<UserLocation> users = _dataRepository.GetAll();
            return Ok(users);
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            IEnumerable<UserLocation> user = _dataRepository.Get(id);

            if (user.Count()==0)
            {
                return NotFound("No location found");
            }

            return Ok(user);
        }




        [HttpPost]
        public IActionResult Post([FromBody] UserLocation user)
        {

            if (user == null)
            {
                return BadRequest("Location is null.");
            }

            _dataRepository.Add(user);
            return Ok(user);

        }




    }
}
