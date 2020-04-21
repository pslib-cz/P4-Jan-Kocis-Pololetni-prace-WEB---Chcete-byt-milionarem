using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
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
        public HraService hraSR;
        public string email;
        public int score;
        public int vynuluj;

        public IndexModel(HraService hra)
        {
            hraSR = hra;
        }

        public void OnGet()
        {
            email = hraSR.ID_UzivatelPrvni();
            vynuluj = hraSR.Vynuluj();
        }

    }
}
