using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MilionarFINAL.Models
{
    public class OdpovedUzivatel
    {
        //ID uživatelovi odpovědi
        [Key]
        public int ID_OdpovedUzivatele { get; set; }

        //Text uživatelovi odpovědi
        [Required]
        public string TextOdpoved { get; set; }

        //Zjištění, zda uživatel odpověděl správně
        [Required]
        public bool Spravnost { get; set; }

        public int ID_Otazka { get; set; }
        [ForeignKey("ID_Otazka")]
        public Otazka Zodpovezeno { get; set; }

        public string ID_Uzivatel { get; set; }
        [ForeignKey("ID_Uzivatel")]
        public Uzivatel Zodpovedel { get; set; }
    }
}
