using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KBVB.API.Interfaces;
using KBVB.API.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KBVB.API.Controllers
{
    [Route("api/user")]
    public class UserController : Controller
    {
		private IUserRepository _repository;

		public UserController(IUserRepository repository)
		{
			_repository = repository;
		}

        // GET: api/values
        [HttpGet]
		public IActionResult Get()
        {
			return NotFound();
        }

        // GET api/values/5
        [HttpGet("{email}")]
		public IActionResult Get(string email)
        {
			var userFromRepo = _repository.GetUser(email);
			if (userFromRepo == null)
			{
				return NotFound();
			}

			var userDto = Mapper.Map<UserDto>(userFromRepo);

			return Ok(userDto);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
			/* No need to implement for the moment */
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
			/* No need to implement for the moment */
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
			/* No need to implement for the moment */
        }
    }
}
