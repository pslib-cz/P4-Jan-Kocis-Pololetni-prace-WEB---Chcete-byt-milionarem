using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilionarApp.Models
{
    public class AppUser : IdentityUser <int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int Kolo { get; set; }
        public bool JeVeHre { get; set; }
    }
}
