using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilionarApp.Models
{
    public class AppUser : IdentityUser <int>
    {
        public int FirstName { get; set; }
        public int LastName { get; set; }
    }
}
