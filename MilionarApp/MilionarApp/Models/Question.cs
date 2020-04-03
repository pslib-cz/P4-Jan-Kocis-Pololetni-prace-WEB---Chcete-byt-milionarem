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
        [Key]
        public int QuestionId { get; set; }

        [Required]
        public string TextOtazky { get; set; }

        [Required]
        public int Narocnost { get; set; }

        [ForeignKey("Parent")]
        public int? ParentId { get; set; }
        public Question Parent { get; set; }

        public ICollection<Question> Children { get; set; }

        public ICollection<Answer> OdpovediKOtazce { get; set; }

    }
}
