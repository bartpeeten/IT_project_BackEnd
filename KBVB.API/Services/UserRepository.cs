using System;
using System.Linq;
using KBVB.API.Entities;
using KBVB.API.Interfaces;

namespace KBVB.API.Services
{
	public class UserRepository : IUserRepository
    {
		private KbvbContext _context;

		public UserRepository(KbvbContext context)
        {
			_context = context;
        }

		public User GetUser(String email)
		{
			return _context.Users.FirstOrDefault(x => x.Email == email);
		}

		public bool UserExist(Guid userId)
		{
			return _context.Users.FirstOrDefault(x => x.Id == userId) != null;
		}

		public bool UserExist(string email)
		{
			return _context.Users.FirstOrDefault(x => x.Email == email) != null;
		}
	}
}
