using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Hackathon2.Models
{
    public class Pharmacies
    {
        public int Id { get; set; }
        [DisplayName("Název")]
        public string Name { get; set; }
        [DisplayName("Adresa")]
        public string Address { get; set; }
        [DisplayName("Provozovatel")]
        public string Pharmacist { get; set; }
        [DisplayName("Kód lékárny")]
        public string PharmacyCode { get; set; }
        [DisplayName("IČZ")]
        public string ICZ { get; set; }
        [DisplayName("Kód pracoviště")]
        public string PlaceCode { get; set; }
        [DisplayName("Město")]
        public string City { get; set; }
        [DisplayName("PSČ")]
        public string PostCode { get; set; }

        [DisplayName("Email")]
        public string Email { get; set; }
        [DisplayName("www stránky")]
        public string Website { get; set; }

        public string Phone { get; set; }
        [DisplayName("Telefonní číslo")]
        public long PhoneNumber { get; set; }
    }
}
