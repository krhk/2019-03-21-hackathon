using Hackathon2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TinyCsvParser.Mapping;

namespace Hackathon2.Data
{
    public class Parser
    {
    }
    public class CsvPersonMapping : CsvMapping<Pharmacies>
    {
        public CsvPersonMapping()
            : base()
        {
            MapProperty(0, x => x.Name);
            MapProperty(1, x => x.PharmacyCode);
            MapProperty(2, x => x.PlaceCode);
            MapProperty(3, x => x.ICZ);
            MapProperty(4, x => x.Pharmacist);
            MapProperty(5, x => x.City);
            MapProperty(6, x => x.Address);
            MapProperty(7, x => x.PostCode);
            MapProperty(8, x => x.PhoneNumber);
            MapProperty(10, x => x.Email);
            MapProperty(11, x => x.Website);
        }
    }
    public class CsvEmergencyMapping : CsvMapping<Emergency>
    {
        public CsvEmergencyMapping()
            : base()
        {
            MapProperty(0, x => x.Type);
            MapProperty(1, x => x.Group);
            MapProperty(3, x => x.OkresCode);
            MapProperty(4, x => x.OkresName);
            MapProperty(5, x => x.ObecCode);
            MapProperty(6, x => x.ObecName);
            MapProperty(7, x => x.ProviderName);
            MapProperty(8, x => x.Address);
            MapProperty(9, x => x.AddressCode);
            MapProperty(10, x => x.OpenHours);
        }
    }
}
