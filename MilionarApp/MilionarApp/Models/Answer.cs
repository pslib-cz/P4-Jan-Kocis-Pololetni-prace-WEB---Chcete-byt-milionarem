using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MilionarApp.Models
{
    public class Answer
    {
        //Unikátní ID odpovědi
        [Key]
        public int AnswerId { get; set; }

        //Text odpovědi
        [Required]
        public string TextOdpovedi { get; set; }

        //
        public bool Spravnost { get; set; }

        //Napojení na propojenou otázku
        public Question OtazkaId { get; set; }
    }
}
