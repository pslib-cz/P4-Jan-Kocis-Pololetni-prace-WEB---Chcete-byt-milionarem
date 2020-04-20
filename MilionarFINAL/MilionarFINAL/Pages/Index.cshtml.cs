using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MilionarFINAL.Models;
using MilionarFINAL.Service;

namespace MilionarFINAL.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public string Odpoveduzivatel { get; set; }

        public HraService hraSR;
        public string email;
        public int score;
        public Otazka aktualniotazka;

        public IndexModel(HraService hra)
        {
            hraSR = hra;
        }

        public void OnGet()
        {
            email = hraSR.ID_UzivatelPrvni();
            score = hraSR.Score();
            aktualniotazka = hraSR.AktualniOtazka();
        }

        public IActionResult OnPost()
        {

            bool vysledek = hraSR.Vyhodnoceni(Odpoveduzivatel);

            if(vysledek == true)
            {
                return RedirectToPage("Hra");
            }
            else
            {
                return RedirectToPage("Hra");
            }        
        }
    }
}
