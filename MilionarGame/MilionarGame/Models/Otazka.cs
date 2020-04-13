using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MilionarGame.Models
{
    public class Otazka
    {
        //Unikátní ID otázky
        [Key]
        public int OtazkaID { get; set; }

        //Text otázky
        [Required]
        public string textOtazka { get; set; }

        //Náročnost otázky, podle které se budou určité otázky objevovat v určité části hry (podle obtížnosti)
        [Required]
        public int Narocnost { get; set; }
    }
}
