using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GamesCollection.Models;
using GamesCollection.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GamesCollection.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace GamesCollection
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly GameCompanyService _gs;

        public DetailsModel(GameCompanyService gs)
        {
            _gs = gs;
        }
        public Company Company { get; set; }
        public IEnumerable<CompanyGames> CGs { get; set; }

        public void OnGet(int id)
        {
            Company = _gs.GetAllDataFromSingleCompany(id);
            if (Company == default) Company = new Company();

            CGs = CompanyGames.CreateGamesList(Company.DevelopedGames, Company.ReleasedGames);
        }
    }
}