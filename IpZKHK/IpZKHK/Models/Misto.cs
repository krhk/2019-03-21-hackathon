using KHK_OpenData.Lib.Entities;
using KHK_OpenData.Lib.Interfaces;
using KHK_OpenData.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IpZKHK.Models
{
    public class Misto
    {
        public Misto(Souradnice souradnice, IEntitySet<PocetObyvatel> poctyObyvatel, IEntitySet<VekoveSlozeni> vekovaSlozeni)
        {
            Souradnice = souradnice;
            var result = Souradnice.ObecZeSouradnic(souradnice);
            Nazev = result[0];
            NazevObce = result[1];
            PocetObyvatel = poctyObyvatel.GetList().Find((p) => p.NazevObce.ToLower() == NazevObce.ToLower());
            VekoveSlozeni = vekovaSlozeni.GetList().Find((v) => v.NazevObce.ToLower() == NazevObce.ToLower());
        }
        public string Nazev { get; set; }
        public string NazevObce { get; set; }

        public Souradnice Souradnice { get; set; }
        public PocetObyvatel PocetObyvatel { get; set; }
        public VekoveSlozeni VekoveSlozeni { get; set; }

        public List<StomatologickaPohotovost> StomatologickaPohotovost { get; set; }
        public List<LekarskaPohotovost> LekarskaPohotovost { get; set; }
        public List<SocialniZarizeni> SocialniZarizeni { get; set; }

        public List<Divadlo> Divadlo { get; set; }
        public List<Kino> Kino { get; set; }
        public List<Klub> Klub { get; set; }
        public List<ZabavniCentrum> ZabavniCentrum { get; set; }
        public List<Knihovna> Knihovna { get; set; }

        public List<Lanovka> Lanovka { get; set; }

    }
}
