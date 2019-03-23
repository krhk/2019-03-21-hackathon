using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hackathon.Data;
using Hackathon.Models;
using System.IO;
using System.Net;
using Csv;

namespace Hackathon
{
    [Route("api/[controller]")]
    [ApiController]
    public class HasiciController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public HasiciController(ApplicationDbContext context)
        {
            
            _context = context;
        }
        public async Task Update()
        {
            using (var client = new WebClient())
            {
                client.DownloadFile("http://www.kr-kralovehradecky.cz/assets/kraj-volene-organy/sklad/opendata/izs/Stanice-a-pracoviste-HZS.csv", "Stanice-a-pracoviste-HZS.csv");
            }

            List<Hasici> mylist = new List<Hasici>();

            using (StreamReader sr = new StreamReader("Stanice-a-pracoviste-HZS.csv"))
            {
                foreach (var line in CsvReader.Read(sr))
                {
                    
                        Hasici h = new Hasici();
                        h.KodOkresu = line["Kód okresu"];
                        h.NazevOkresu =line["Název okresu / Územní odbor"];
                        h.DruhPracoviste = line["Druh pracoviště"];
                        h.TypStanice= line["Typ stanice"];
                        h.Ulice =line["Ulice"];
                        h.CisloPopisne= line["Číslo popisné"];
                        h.Mesto= line["Město"];
                        h.PSC= line["PSČ"];
                        h.WKT= line["WKT"];
                        h.GPS= line["GPS"];
                        h.Telefon= line["Telefon"];
                        
                    //public string Email{get;set;}
                    mylist.Add(h);
                    await _context.AddAsync(h);
                    await _context.SaveChangesAsync();
                }

                
            }
            
           /*  foreach (var line in CsvReader.Read(sr))
            {
                if (line.Index == 2)
                {
                    mylist.Add(line.Headers);
                }
                mylist.Add(line.Values);
            }*/
        }

        // GET: api/Hasici
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hasici>>> GetHasici()
        {
            //await Update();
            return await _context.Hasici.ToListAsync();
        }

        // GET: api/Hasici/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Hasici>> GetHasici(int id)
        {
            var hasici = await _context.Hasici.FindAsync(id);

            if (hasici == null)
            {
                return NotFound();
            }

            return hasici;
        }

        // PUT: api/Hasici/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHasici(int id, Hasici hasici)
        {
            if (id != hasici.Id)
            {
                return BadRequest();
            }

            _context.Entry(hasici).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HasiciExists(id))
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

        // POST: api/Hasici
        [HttpPost]
        public async Task<ActionResult<Hasici>> PostHasici(Hasici hasici)
        {
            _context.Hasici.Add(hasici);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHasici", new { id = hasici.Id }, hasici);
        }

        // DELETE: api/Hasici/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Hasici>> DeleteHasici(int id)
        {
            var hasici = await _context.Hasici.FindAsync(id);
            if (hasici == null)
            {
                return NotFound();
            }

            _context.Hasici.Remove(hasici);
            await _context.SaveChangesAsync();

            return hasici;
        }

        private bool HasiciExists(int id)
        {
            return _context.Hasici.Any(e => e.Id == id);
        }
    }
}
