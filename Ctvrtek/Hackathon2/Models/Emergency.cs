using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Hackathon2.Models
{
    public class Emergency
    {
        public int Id { get; set; }

        [DisplayName("Typ pohotovosti")]
        public string Type { get; set; }

        [DisplayName("Pro koho")]
        public string Group { get; set; }

        [DisplayName("Kód okresu")]
        public string OkresCode { get; set; }
        [DisplayName("Název okresu")]
        public string OkresName { get; set; }
        [DisplayName("Kód obce")]
        public string ObecCode { get; set; }
        [DisplayName("Název obce")]
        public string ObecName { get; set; }
        [DisplayName("Poskytovatel pohotovosti")]
        public string ProviderName { get; set; }
        [DisplayName("Ulice")]
        public string Address { get; set; }
        [DisplayName("Číslo popisné")]
        public int AddressCode { get; set; }
        [DisplayName("Ordinační hodiny")]
        public string OpenHours { get; set; }
    }
}
