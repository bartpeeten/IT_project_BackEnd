using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KBVB.API.Entities
{
    public class Player
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string CurrentTeam { get; set; }
        public string DidYouKnow { get; set; }
        public string ImageURL { get; set; }
    }
}
