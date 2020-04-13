using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MilionarGame.Models
{
    public class Uzivatel : IdentityUser
    {
        [Key]
        public int UzivatelID { get; set; }
        public int kolo { get; set; }

        public bool jeVeHre { get; set; }
    }
}
