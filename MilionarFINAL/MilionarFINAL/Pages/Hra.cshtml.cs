using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MilionarFINAL.Models;
using MilionarFINAL.Service;

namespace MilionarFINAL.Pages
{
    public class HraModel : PageModel
    {
        [BindProperty]
        public string Odpoveduzivatel { get; set; }

        public HraService hraSR;
        public string email;
        public int score;
        public int vynuluj;
        public Otazka aktualniotazka;

        public HraModel(HraService hra)
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
            bool konec = hraSR.Konec();

            if (konec == true)
            {
                return RedirectToPage("Vyhra");
            }
            else
            {

            }

            if (vysledek == true)
            {
                return RedirectToPage("Hra");
            }
            else
            {
                return RedirectToPage("Prohra");
            }
        }
    }
}
