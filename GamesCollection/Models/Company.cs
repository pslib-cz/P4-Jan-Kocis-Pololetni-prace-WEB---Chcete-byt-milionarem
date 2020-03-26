using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GamesCollection.Models
{
    public class Company
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "název společnosti")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "webová stránka")]
        public string Website { get; set; }
        [Required]
        [Display(Name = "kód země")]
        public string CountryCode { get; set; }
        
        [ForeignKey("Parent")]
        public int? ParentId { get; set; }
        public Company Parent { get; set; }

        public ICollection<Company> Children { get; set; }

        public ICollection<Game> DevelopedGames { get; set; }
        public ICollection<Game> ReleasedGames { get; set; }
    }
}
