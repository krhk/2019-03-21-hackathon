using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hackathon.Models
{
    public class NaslednaPece
    {
        [Display(Name="Id")]
        public int Id{get;set;}
        [Display(Name="Poskytovatel")]
        public string Poskytovatel{get;set;}
        [Display(Name="Právní forma")]
        public string PravniForma{get;set;}
        [Display(Name="Kód obce")]
        public string KodObce{get;set;}
        [Display(Name="Název obce")]
        public string NazevObce{get;set;}
        [Display(Name="Ulice")]
        public string Ulice{get;set;}
        [Display(Name="Číslo popisné")]
        public string CiscloPopisne{get;set;}
        [Display(Name="PSČ")]
        public string PSC{get;set;}
        [Display(Name="Telefon")]
        public string Telefon{get;set;}
    }
}
