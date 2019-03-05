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
    public class UserController : ControllerBase

    { 
        private readonly IDataRepository<User> _dataRepository;

       public UserController(IDataRepository<User> dataRepository)
       {
        _dataRepository = dataRepository;
       }
    // GET: api/<controller>
    [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<User> users = _dataRepository.GetAll();
            return Ok(users);
        }

        // GET api/<controller>/5
        [HttpGet("{email}")]
        public IActionResult Get(string email)
        {
            User user = _dataRepository.Get(email);

            if (user == null)
            {
                return NotFound("Invalid Credentials");
            }

            return Ok(user);
        }



       
        [HttpPost("signup")]
        public IActionResult Post([FromBody] User user)
        {
            var Users = _dataRepository.GetAll();
            var email = Users.FirstOrDefault(e => e.Email == user.Email);


            if (email != null)
            {
                return BadRequest("Email Already in use.");
            }

            _dataRepository.Add(user);
            return Ok(user);

        }
        [HttpPut("{id}")]
        public IActionResult Put(string email, [FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("Employee is null.");
            }

            User userToUpdate = _dataRepository.Get(email);
            if (userToUpdate == null)
            {
                return NotFound("The Employee record couldn't be found.");
            }

            _dataRepository.Update(userToUpdate, user);
            return NoContent();
        }



    }
}
