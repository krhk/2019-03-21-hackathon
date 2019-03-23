using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hackathon.Models
{
    public class Stomatologie
    {
        [Display(Name="Id")]
        public int Id{get;set;}
        [Display(Name="Oblast")]
        public string Oblast{get;set;}
        [Display(Name="Datum")]
        public string Datum{get;set;}
        [Display(Name="Jméno lékaře")]
        public string JmenoLekare{get;set;}
        [Display(Name="Kód obce")]
        public string KodObce{get;set;}
        [Display(Name="Název obce")]
        public string NazevObce{get;set;}
        [Display(Name="Ulice")]
        public string Ulice{get;set;}
        [Display(Name="Číslo popisné")]
        public string CiscloPopisne{get;set;}
        [Display(Name="Telefon")]
        public string Telefon{get;set;}
        [Display(Name="Ordinační hodiny")]
        public string OrdinacniHodiny{get;set;}
    }
}
