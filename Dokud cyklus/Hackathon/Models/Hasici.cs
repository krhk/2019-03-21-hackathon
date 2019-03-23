using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hackathon.Models
{
    public class Hasici
    {
        [Display(Name="Id")]
        public int Id{get;set;}
        [Display(Name="Kód okresu")]
        public string KodOkresu{get;set;}
        [Display(Name="Název okresu")]
        public string NazevOkresu {get;set;}
        [Display(Name="Druh pracoviště")]
        public string DruhPracoviste{get;set;}
        [Display(Name="Typ stanice")]
        public string TypStanice{get;set;}
        [Display(Name="Ulice")]
        public string Ulice{get;set;}
        [Display(Name="Číslo popisné")]
        public string CisloPopisne{get;set;}
        [Display(Name="Město")]
        public string Mesto{get;set;}
        [Display(Name="PSČ")]
        public string PSC{get;set;}
        [Display(Name="WKT")]
        public string WKT{get;set;}
        [Display(Name="GPS")]
        public string GPS{get;set;}
        [Display(Name="Telefon")]
        public string Telefon{get;set;}
        [Display(Name="Email")]
        public string Email{get;set;}
    }
}
