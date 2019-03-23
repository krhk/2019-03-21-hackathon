using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Hackathon.Models
{
    public class Update
    {
        [Key]
        public string Nazev { get; set; }
        public DateTime DatumCas { get; set; }
    }
}
