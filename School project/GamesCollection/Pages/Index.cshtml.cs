using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GamesCollection.Models;
using GamesCollection.Service;
using GamesCollection.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace GamesCollection.Pages
{
    public class IndexModel : PageModel
    {
        private readonly GameCompanyService _gs;

        [BindProperty(SupportsGet = true)]
        public string NameFilter { get; set; }

        [BindProperty(SupportsGet = true)]
        public string CountryCodeFilter { get; set; }

        [BindProperty(SupportsGet = true)]
        public OrderByState OrderBy { get; set; }

        public OrderByState OrderByName { get; set; }
        public OrderByState OrderByCC { get; set; }

        public IEnumerable<Company> Companies { get; set; }

        public IEnumerable<SelectListItem> CountriesList { get; set; }

        public IndexModel(GameCompanyService gs)
        {
            this._gs = gs;
        }

        public void OnGet()
        {
            CountriesList = _gs.GetCountryCodes().Select(item => new SelectListItem(item, item));
            Companies = _gs.GetCompanies();

            var data = this.HttpContext.User.FindFirst((ct) => ct.Type == System.Security.Claims.ClaimTypes.NameIdentifier);

        }
    }
}
