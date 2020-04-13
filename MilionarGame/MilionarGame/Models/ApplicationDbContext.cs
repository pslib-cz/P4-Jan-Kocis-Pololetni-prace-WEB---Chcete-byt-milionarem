using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilionarGame.Models
{
    public class ApplicationDbContext : IdentityDbContext<Uzivatel>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Uzivatel> Uzivatele { get; set; }
        public DbSet<Otazka> Otazky { get; set; }
        public DbSet<OdpovedUzivatel> Odpovedi { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
