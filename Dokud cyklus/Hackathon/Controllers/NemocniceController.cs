using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hackathon.Data;
using Hackathon.Models;
using Csv;
using System.IO;
using System.Net;

namespace Hackathon
{
    [Route("api/[controller]")]
    [ApiController]
    public class NemocniceController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public NemocniceController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Update()
        {
            using (var client = new WebClient())
            {
                client.DownloadFile("http://www.kr-kralovehradecky.cz/assets/kraj-volene-organy/opendata/zdravotnictvi/LPS.csv", "LPS.csv");
            }

            List<Nemocnice> mylist = new List<Nemocnice>();

            using (StreamReader sr = new StreamReader("LPS.csv"))
            {
                foreach (var line in CsvReader.Read(sr))
                {
                    
                        Nemocnice n = new Nemocnice();
                        n.Typ=line["Typ pohotovosti"];
                        n.Urceni=line["Pro koho"];
                        n.KodOkresu=line["Kód okresu"];
                        n.NazevOkresu=line["Název okresu"];
                        n.KodObce=line["Kód obce"];
                        n.NazevObce=line["Název obce"];
                        n.NazevPoskytovatele=line["Název poskytovatele pohotovosti"];
                        n.Ulice=line["Ulice"];
                        n.CiscloPopisne=line["Číslo popisné"];
                        n.OrdinacniHodiny=line["Ordinační hodiny:"];
                        
                    mylist.Add(n);
                    await _context.AddAsync(n);
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

        // GET: api/Nemocnice
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Nemocnice>>> GetNemocnice()
        {
            //await Update();
            return await _context.Nemocnice.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Nemocnice>> PostNemocnice(Nemocnice nemocnice)
        {
            _context.Nemocnice.Add(nemocnice);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNemocnice", new { id = nemocnice.Id }, nemocnice);
        }

        // DELETE: api/Nemocnice/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Nemocnice>> DeleteNemocnice(int id)
        {
            var nemocnice = await _context.Nemocnice.FindAsync(id);
            if (nemocnice == null)
            {
                return NotFound();
            }

            _context.Nemocnice.Remove(nemocnice);
            await _context.SaveChangesAsync();

            return nemocnice;
        }

        private bool NemocniceExists(int id)
        {
            return _context.Nemocnice.Any(e => e.Id == id);
        }
    }
}
