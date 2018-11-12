using System;
using System.Collections.Generic;
using System.Linq;
using KBVB.API.Entities;
using KBVB.API.Interfaces;

namespace KBVB.API.Services
{
	public class PlayerRepository : IPlayerRepository
    {
		private KbvbContext _context;

		public PlayerRepository(KbvbContext context)
        {
			_context = context;
        }

		public IEnumerable<Player> GetPlayers()
		{
			return _context.Players.OrderBy(x => x.LastName).ToList();
		}
	}
}
