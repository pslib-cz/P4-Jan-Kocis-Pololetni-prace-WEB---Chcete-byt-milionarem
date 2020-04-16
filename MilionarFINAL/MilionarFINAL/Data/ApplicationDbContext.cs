using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MilionarFINAL.Models;

namespace MilionarFINAL.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Otazka> Otazky { get; set; }
        public DbSet<Uzivatel> Uzivatele { get; set; }
        public DbSet<OdpovedUzivatel> OdpovediUzivatelu { get; set; }

    }
}
