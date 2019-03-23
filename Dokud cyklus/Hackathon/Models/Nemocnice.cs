using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hackathon.Models
{
    public class Nemocnice
    {
        [Display(Name="Id")]
        public int Id{get;set;}
        [Display(Name="Typ")]
        public string Typ{get;set;}
        [Display(Name="Určení")]
        public string Urceni{get;set;}
        [Display(Name="Kód okresu")]
        public string KodOkresu{get;set;}
        [Display(Name="Název okresu")]
        public string NazevOkresu {get;set;}
        [Display(Name="Kód obce")]
        public string KodObce{get;set;}
        [Display(Name="Název obce")]
        public string NazevObce{get;set;}
        [Display(Name="Nazev poskytovatele")]
        public string NazevPoskytovatele{get;set;}
        [Display(Name="Ulice")]
        public string Ulice{get;set;}
        [Display(Name="Číslo popisné")]
        public string CiscloPopisne{get;set;}
        [Display(Name="Ordinační hodiny")]
        public string OrdinacniHodiny{get;set;}
    }
  
}

