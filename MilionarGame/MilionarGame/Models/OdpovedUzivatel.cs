using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MilionarGame.Models
{
    public class OdpovedUzivatel
    {
        //Unikátní ID odpovědi
        [Key]
        public int OdpovedID { get; set; }

        //Text odpovědi
        [Required]
        public string textOdpoved { get; set; }

        //Zda je odpověď správná či ne
        [Required]
        public bool Spravnost { get; set; }


        public int Otazka_ID { get; set; }

        [ForeignKey("Otazka_ID")]
        public Otazka Otazka { get; set; }


        public int Uzivatel_ID { get; set; }

        [ForeignKey("Uzivatel_ID")]
        public Uzivatel Uzivatel { get; set; }
    }
}
