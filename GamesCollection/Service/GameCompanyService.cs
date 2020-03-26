using GamesCollection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace GamesCollection.Service
{
    public class GameCompanyService
    {
        readonly ApplicationDbContext _db;
        readonly HttpContext _httpContext;

        public GameCompanyService(ApplicationDbContext db, IHttpContextAccessor contextAccessor)
        {
            _db = db;
            _httpContext = contextAccessor.HttpContext;
        }

        public IEnumerable<string> GetCountryCodes()
        {
            return new List<string> {
                "CZ", "FR", "GE", "PL", "SE", "US"
            };
        }

        public IEnumerable<Company> GetCompanies()
        {
            return _db.Companies.AsNoTracking().AsEnumerable();
        }

        public Company GetAllDataFromSingleCompany(int id)
        {
            return _db.Companies
                .Where(comp => comp.Id == id)
                .Include(comp => comp.DevelopedGames)
                .Include(comp => comp.ReleasedGames)
                .Include(comp => comp.Children)
                .AsNoTracking()
                .SingleOrDefault();
        }
    }
}
