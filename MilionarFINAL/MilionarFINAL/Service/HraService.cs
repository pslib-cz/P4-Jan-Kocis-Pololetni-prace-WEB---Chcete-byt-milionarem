using Microsoft.AspNetCore.Http;
using MilionarFINAL.Data;
using MilionarFINAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilionarFINAL.Service
{
    public class HraService
    {
        private ApplicationDbContext kontextDB { get; set; }
        private IHttpContextAccessor kontextHTTP { get; set; }
        private string IDAktualniUzivatel { get; set; }
        public HraService(ApplicationDbContext context, IHttpContextAccessor http)
        {
            kontextDB = context;
            kontextHTTP = http;
            IDAktualniUzivatel = kontextHTTP.HttpContext.User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        }
        public string ID_UzivatelPrvni() 
        {
            return kontextDB.Uzivatele.First<Uzivatel>().Email;
        }

        public int Score()
        {
            return kontextDB.Uzivatele.First<Uzivatel>().kolo;
        }

        public class Objekt
        {
            public string textOtazka { get; set; }
            public string odpovedOtazka { get; set; }
        }

        //Otázka, která se zobrazí a následně hádá odpověď
        public dynamic AktualniOtazka()
        {
            foreach(Otazka i in kontextDB.Otazky)
            {
                if(i.Narocnost == kontextDB.Uzivatele.First<Uzivatel>().kolo)
                {
                    return new Objekt()
                    {
                        textOtazka = i.textOtazka,
                        odpovedOtazka = i.Odpoved
                    };
                }
                else
                {
                    return "";
                }
            }
            return "";
        }

        /*public bool Vyhodnoceni(string odpovedUzivatele)
        {
            if (odpovedUzivatele == Objekt) ;
        }*/
    }
}
