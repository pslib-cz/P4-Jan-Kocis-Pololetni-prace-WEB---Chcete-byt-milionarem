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

        public int Vynuluj()
        {
            int i = 0;
            kontextDB.Uzivatele.First<Uzivatel>().kolo = i;
            kontextDB.SaveChanges();
            return i;    
        }

        //Otázka, která se zobrazí a následně hádá odpověď
        public Otazka AktualniOtazka()
        {
            foreach(Otazka i in kontextDB.Otazky)
            {
                if(i.Narocnost == kontextDB.Uzivatele.First<Uzivatel>().kolo)
                {
                    return i;
                }
            }
            return null;
        }

        public bool Vyhodnoceni(string ou)
        {
            Otazka aktualni = AktualniOtazka();

            if(aktualni.Odpoved == ou)
            {
                kontextDB.Uzivatele.First<Uzivatel>().kolo++;
                kontextDB.SaveChanges();
                return true;
            }
            else
            {
                kontextDB.Uzivatele.First<Uzivatel>().kolo = 0;
                kontextDB.SaveChanges();
                return false;
            }            
        }

        public bool Konec()
        {
            int kolo = kontextDB.Uzivatele.First<Uzivatel>().kolo;
            if (kolo == 10)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
