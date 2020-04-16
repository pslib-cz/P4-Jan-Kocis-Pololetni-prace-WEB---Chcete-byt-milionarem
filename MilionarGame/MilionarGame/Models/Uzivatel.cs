using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MilionarGame.Models
{
    public class Uzivatel : IdentityUser
    {
        //Unikátní ID uživatele
        [Key]
        public int UzivatelID { get; set; }

        //Kolo, ve kterém daný uživatel je - odvíjí se od toho složitost otázek
        public int kolo { get; set; }

        //Zjištění, zda uživatel právě hraje
        public bool StavHry { get; set; }

        //Aktuální otázka ve hře
        public int? ID_Otazka { get; set; }
        [ForeignKey("ID_Otazka")]
        public Otazka OtazkaVeHre { get; set; }

    }
}
