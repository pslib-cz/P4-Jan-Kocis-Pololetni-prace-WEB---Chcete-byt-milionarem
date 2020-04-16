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
        //ID uživatelovi odpovědi
        [Key]
        public int ID_OdpovedUzivatele { get; set; }

        //Zjištění, zda uživatel odpověděl správně
        [Required]
        public bool Spravnost { get; set; }

        public int ID_Otazka { get; set; }
        [ForeignKey("ID_Otazka")]
        public Otazka Zodpovezeno { get; set; }

        public int ID_Uzivatel { get; set; }
        [ForeignKey("ID_Uzivatel")]
        public Uzivatel Zodpovedel { get; set; }
    }
}
