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
    public class PolicieController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PolicieController(ApplicationDbContext context)
        {
            _context = context;
        }
         public async Task Update()
        {
            using (var client = new WebClient())
            {
                client.DownloadFile("http://www.kr-kralovehradecky.cz/assets/kraj-volene-organy/sklad/opendata/izs/Policie-CR.csv", "Policie-CR.csv");
            }

            List<Policie> mylist = new List<Policie>();

            using (StreamReader sr = new StreamReader("Policie-CR.csv"))
            {
                foreach (var line in CsvReader.Read(sr))
                {
                    
                        Policie p = new Policie();

                        p.KodOkresu = line["Kód okresu"];
                        p.NazevOkresu =line["Název okresu / Územní odbor"];
                        p.Obvod=line["Obvod"];
                        p.Ulice=line["Ulice"];
                        p.CisloPopisne=line["Číslo popisné"];
                        p.Mesto=line["Město"];
                        p.PSC=line["PSČ"];
                        p.WKT=line["WKT"];
                        p.GPS=line["GPS"];
                        p.Telefon=line["Telefon"];
                        p.Fax=line["Fax"];
                        p.Email=line["e-mail"];
                        
                    mylist.Add(p);
                    await _context.AddAsync(p);
                    await _context.SaveChangesAsync();
                }             
            }
        }

        // GET: api/Policie
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Policie>>> GetPolicie()
        {
            //await Update();
            return await _context.Policie.ToListAsync();
        }

        // GET: api/Policie/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Policie>> GetPolicie(int id)
        {
            var policie = await _context.Policie.FindAsync(id);

            if (policie == null)
            {
                return NotFound();
            }

            return policie;
        }

        // PUT: api/Policie/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPolicie(int id, Policie policie)
        {
            if (id != policie.Id)
            {
                return BadRequest();
            }

            _context.Entry(policie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PolicieExists(id))
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

        // POST: api/Policie
        [HttpPost]
        public async Task<ActionResult<Policie>> PostPolicie(Policie policie)
        {
            _context.Policie.Add(policie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPolicie", new { id = policie.Id }, policie);
        }

        // DELETE: api/Policie/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Policie>> DeletePolicie(int id)
        {
            var policie = await _context.Policie.FindAsync(id);
            if (policie == null)
            {
                return NotFound();
            }

            _context.Policie.Remove(policie);
            await _context.SaveChangesAsync();

            return policie;
        }

        private bool PolicieExists(int id)
        {
            return _context.Policie.Any(e => e.Id == id);
        }
    }
}
