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
    [Route("api/player")]
    public class PlayerController : Controller
    {
		private IPlayerRepository _playerRepo;

		public PlayerController(IPlayerRepository repo)
		{
			_playerRepo = repo;
		}

        // GET: api/values
        [HttpGet]
		public IActionResult Get()
        {
			var playersFromRepo = _playerRepo.GetPlayers();

			if(playersFromRepo.Count() == 0)
			{
				return NotFound();
			}

			var players = Mapper.Map<IEnumerable<PlayerDto>>(playersFromRepo);

			return Ok(players);
        }

        // GET api/values/5
        [HttpGet("{id}")]
		public IActionResult Get(int id)
        {
			return NotFound();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
			/* Not needed to implement for the moment */
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
			/* Not needed to implement for the moment */
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
			/* Not needed to implement for the moment */
        }
    }
}
