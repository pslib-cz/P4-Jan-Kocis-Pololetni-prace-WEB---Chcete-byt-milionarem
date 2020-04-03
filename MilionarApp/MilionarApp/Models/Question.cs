using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MilionarApp.Models
{
    public class Question
    {
        //Unikátní ID otázky
        [Key]
        public int QuestionId { get; set; }

        //Text otázky
        [Required]
        public string TextOtazky { get; set; }

        //Náročnost otázky, podle které se budou určité otázky objevovat v určité části hry (podle obtížnosti)
        [Required]
        public int Narocnost { get; set; }

        public ICollection<Answer> OdpovediKOtazce { get; set; }

    }
}
