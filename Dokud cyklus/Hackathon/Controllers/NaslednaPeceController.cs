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
    public class NaslednaPeceController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public NaslednaPeceController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Update()
        {
            using (var client = new WebClient())
            {
                client.DownloadFile(
                    "http://www.kr-kralovehradecky.cz/assets/kraj-volene-organy/opendata/zdravotnictvi/Nasledna-pece.csv",
                    "Nasledna-pece.csv");
            }

            List<NaslednaPece> mylist = new List<NaslednaPece>();

            using (StreamReader sr = new StreamReader("Nasledna-pece.csv"))
            {
                foreach (var line in CsvReader.Read(sr))
                {
                    NaslednaPece n = new NaslednaPece();

                    n.Poskytovatel = line["Poskytovatel"];
                    n.PravniForma = line["Právní forma"];
                    n.KodObce = line["Kód obce"];
                    n.NazevObce = line["Název obce"];
                    n.Ulice = line["Ulice"];
                    n.CiscloPopisne = line["Číslo popisné"];
                    n.PSC = line["PSČ"];
                    n.Telefon = line["Telefon"];

                    mylist.Add(n);
                    await _context.AddAsync(n);
                    await _context.SaveChangesAsync();
                }
            }
        }

        // GET: api/NaslednaPece
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NaslednaPece>>> GetNaslednaPece()
        {
            //await Update();
            return await _context.NaslednaPece.ToListAsync();
        }

        // GET: api/NaslednaPece/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NaslednaPece>> GetNaslednaPece(int id)
        {
            var naslednaPece = await _context.NaslednaPece.FindAsync(id);

            if (naslednaPece == null)
            {
                return NotFound();
            }

            return naslednaPece;
        }

        // PUT: api/NaslednaPece/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNaslednaPece(int id, NaslednaPece naslednaPece)
        {
            if (id != naslednaPece.Id)
            {
                return BadRequest();
            }

            _context.Entry(naslednaPece).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NaslednaPeceExists(id))
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

        // POST: api/NaslednaPece
        [HttpPost]
        public async Task<ActionResult<NaslednaPece>> PostNaslednaPece(NaslednaPece naslednaPece)
        {
            _context.NaslednaPece.Add(naslednaPece);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNaslednaPece", new { id = naslednaPece.Id }, naslednaPece);
        }

        // DELETE: api/NaslednaPece/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<NaslednaPece>> DeleteNaslednaPece(int id)
        {
            var naslednaPece = await _context.NaslednaPece.FindAsync(id);
            if (naslednaPece == null)
            {
                return NotFound();
            }

            _context.NaslednaPece.Remove(naslednaPece);
            await _context.SaveChangesAsync();

            return naslednaPece;
        }

        private bool NaslednaPeceExists(int id)
        {
            return _context.NaslednaPece.Any(e => e.Id == id);
        }
    }
}
