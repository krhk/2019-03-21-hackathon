using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Csv;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hackathon.Data;
using Hackathon.Models;

namespace Hackathon
{
    [Route("api/[controller]")]
    [ApiController]
    public class StomatologieController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StomatologieController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Update()
        {
            using (var client = new WebClient())
            {
                client.DownloadFile(
                    "http://www.kr-kralovehradecky.cz/assets/kraj-volene-organy/opendata/zdravotnictvi/LSSP.csv",
                    "LSSP.csv");
            }

            List<Stomatologie> mylist = new List<Stomatologie>();

            using (StreamReader sr = new StreamReader("LSSP.csv"))
            {
                foreach (var line in CsvReader.Read(sr))
                {
                    Stomatologie s = new Stomatologie();
                    s.Oblast = line["Oblast"];
                    s.Datum = line["Datum"];
                    s.JmenoLekare = line["Jméno lékaře"];
                    s.KodObce = line["Kód obce"];
                    s.NazevObce = line["Název obce"];
                    s.Ulice = line["Ulice"];
                    s.CiscloPopisne = line["Číslo popisné"];
                    s.Telefon = line["Telefon"];
                    s.OrdinacniHodiny = line["Ordinační hodiny"];

                    mylist.Add(s);
                    await _context.AddAsync(s);
                    await _context.SaveChangesAsync();
                }

                {
                    //return NotFound();
                }

                //return stomatologie;
            }
        }

        // GET: api/Stomatologie
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Stomatologie>>> GetStomatologie()
        {
            //await Update();
            return await _context.Stomatologie.ToListAsync();
        }

        // GET: api/Stomatologie/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Stomatologie>> GetStomatologie(int id)
        {
            var stomatologie = await _context.Stomatologie.FindAsync(id);

            if (stomatologie == null)
            {
                return NotFound();
            }

            return stomatologie;
        }

        // PUT: api/Stomatologie/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStomatologie(int id, Stomatologie stomatologie)
        {
            if (id != stomatologie.Id)
            {
                return BadRequest();
            }

            _context.Entry(stomatologie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StomatologieExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Stomatologie
        [HttpPost]
        public async Task<ActionResult<Stomatologie>> PostStomatologie(Stomatologie stomatologie)
        {
            _context.Stomatologie.Add(stomatologie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStomatologie", new { id = stomatologie.Id }, stomatologie);
        }

        // DELETE: api/Stomatologie/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Stomatologie>> DeleteStomatologie(int id)
        {
            var stomatologie = await _context.Stomatologie.FindAsync(id);
            if (stomatologie == null)
            {
                return NotFound();
            }

            _context.Stomatologie.Remove(stomatologie);
            await _context.SaveChangesAsync();

            return stomatologie;
        }

        private bool StomatologieExists(int id)
        {
            return _context.Stomatologie.Any(e => e.Id == id);
        }
    }
}
