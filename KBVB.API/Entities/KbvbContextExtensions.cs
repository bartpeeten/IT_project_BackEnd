using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KBVB.API.Entities
{
    public static class KbvbContextExtensions
    {
        public static void EnsureSeeded(this KbvbContext context)
        {
            context.Users.RemoveRange(context.Users);
            context.Players.RemoveRange(context.Players);
            context.SaveChanges();

            var users = new List<User>()
            {
                new User()
                {
                    Id = new Guid("62de9389-4696-4d29-95b2-386c1692ce36"),
                    FirstName = "Test",
                    LastName = "User",
                    DateOfBirth = new DateTime(1980, 10, 10),
                    Email = "dummy@test.com",
                    Password = "B5A2C96250612366EA272FFAC6D9744AAF4B45AACD96AA7CFCB931EE3B558259"
                }
            };
            context.Users.AddRange(users);

            var players = new List<Player>()
            {
                new Player()
                {
                    Id = new Guid("f34df6b5-3723-4a77-be8d-d39d78dacc4b"),
                    FirstName = "Kevin",
                    LastName = "De Bruyne",
                    CurrentTeam = "Manchester City",
                    DateOfBirth = new DateTime(1991, 6, 28),
                    DidYouKnow = "Kevin De Bruyne Fun Facts!",
                    ImageURL = "http://via.placeholder.com/175x275"
                }
            };
            context.Players.AddRange(players);
            context.SaveChanges();
        }
    }
}
