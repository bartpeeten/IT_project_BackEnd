using System;
using KBVB.API.Entities;

namespace KBVB.API.Interfaces
{
	public interface IUserRepository
    {
		User GetUser(string email);
		bool UserExist(Guid userId);
		bool UserExist(string email);
    }
}
