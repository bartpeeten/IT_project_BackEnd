using System;
using System.Collections.Generic;
using KBVB.API.Entities;

namespace KBVB.API.Interfaces
{
	public interface IPlayerRepository
    {
		IEnumerable<Player> GetPlayers();
    }
}
