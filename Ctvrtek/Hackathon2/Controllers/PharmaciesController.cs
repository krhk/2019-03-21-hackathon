using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hackathon2.Models;
using Hackathon2.Data;
using TinyCsvParser;
using System.Text;

namespace Hackathon2.Controllers
{
    public class PharmaciesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PharmaciesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Pharmacies
        public async Task<IActionResult> Index()
        {
            var result = await _context.Pharmacies.ToListAsync();
            ViewData["Count"] = result.Count;
            return View(result);
        }
        [HttpGet]
        public IEnumerable<Pharmacies> GetShows()
        {
            /*var data = new List<APIViewModel>();
            var shows = new List<Show>();
            foreach (var item in _context.TVs.Include(x => x.Timelines).ThenInclude(x => x.Shows))
            {

            }*/
            //var data = _context.Pharmacies.Include(x => x.Timelines).ThenInclude(x => x.Shows);
            return _context.Pharmacies.ToList();
        }
        [HttpGet]
        public JsonResult GetPharmacy(int id)
        {
            //var pharmacies = _context.Pharmacies
            //    .FirstOrDefaultAsync(m => m.Id == id);
            var result = _context.Pharmacies.ToList().FirstOrDefault(m => m.Id == id);
            /*var data = new List<APIViewModel>();
            var shows = new List<Show>();
            foreach (var item in _context.TVs.Include(x => x.Timelines).ThenInclude(x => x.Shows))
            {

            }*/
            //var data = _context.Pharmacies.Include(x => x.Timelines).ThenInclude(x => x.Shows);
            return new JsonResult(result);
        }
        // GET: Pharmacies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pharmacies = await _context.Pharmacies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pharmacies == null)
            {
                return NotFound();
            }

            return View(pharmacies);
        }

        // GET: Pharmacies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pharmacies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Address,Pharmacist,PharmacyCode,ICZ,PlaceCode,City,PostCode,Email,Website,Phone,PhoneNumber")] Pharmacies pharmacies)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pharmacies);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pharmacies);
        }

        // GET: Pharmacies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pharmacies = await _context.Pharmacies.FindAsync(id);
            if (pharmacies == null)
            {
                return NotFound();
            }
            return View(pharmacies);
        }

        // POST: Pharmacies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Address,Pharmacist,PharmacyCode,ICZ,PlaceCode,City,PostCode,Email,Website,Phone,PhoneNumber")] Pharmacies pharmacies)
        {
            if (id != pharmacies.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pharmacies);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PharmaciesExists(pharmacies.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(pharmacies);
        }

        // GET: Pharmacies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pharmacies = await _context.Pharmacies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pharmacies == null)
            {
                return NotFound();
            }

            return View(pharmacies);
        }

        // POST: Pharmacies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pharmacies = await _context.Pharmacies.FindAsync(id);
            _context.Pharmacies.Remove(pharmacies);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PharmaciesExists(int id)
        {
            return _context.Pharmacies.Any(e => e.Id == id);
        }
        public async Task<IActionResult> ParseData()
        {
            CsvParserOptions csvParserOptions = new CsvParserOptions(true, ',');
            CsvPersonMapping csvMapper = new CsvPersonMapping();
            CsvParser<Pharmacies> csvParser = new CsvParser<Pharmacies>(csvParserOptions, csvMapper);


            var result = csvParser
                .ReadFromFile(@"Data\lekarny.csv", Encoding.ASCII)
                .ToList();
            foreach (var item in result)
            {
                _context.Pharmacies.Add(item.Result);
            }
            await _context.SaveChangesAsync();



            return RedirectToAction("Index");
        }
    }
}
