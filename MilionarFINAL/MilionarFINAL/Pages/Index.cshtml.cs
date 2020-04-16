using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
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
        public dynamic aktualniotazka;
        public string odpoved;
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

            if (Odpoveduzivatel == aktualniotazka.odpovedOtazka)
            {
                score++;
            }
            else
            {
                score++;
            }
            return RedirectToPage();
        }
    }
}
