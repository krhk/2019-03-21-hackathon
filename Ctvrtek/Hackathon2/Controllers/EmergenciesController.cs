﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hackathon2.Models;
using TinyCsvParser;
using Hackathon2.Data;
using System.Text;
namespace Hackathon2.Controllers
{
    public class EmergenciesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmergenciesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Emergencies
        public async Task<IActionResult> Index()
        {
            var result = await _context.Emergency.ToListAsync();
            ViewData["Count"] = result.Count;
            return View(result);
        }

        // GET: Emergencies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emergency = await _context.Emergency
                .FirstOrDefaultAsync(m => m.Id == id);
            if (emergency == null)
            {
                return NotFound();
            }

            return View(emergency);
        }

        // GET: Emergencies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Emergencies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Type,Group,OkresCode,OkresName,ObecCode,ObecName,ProviderName,Address,AddressCode,OpenHours")] Emergency emergency)
        {
            if (ModelState.IsValid)
            {
                _context.Add(emergency);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(emergency);
        }

        // GET: Emergencies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emergency = await _context.Emergency.FindAsync(id);
            if (emergency == null)
            {
                return NotFound();
            }
            return View(emergency);
        }

        // POST: Emergencies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Type,Group,OkresCode,OkresName,ObecCode,ObecName,ProviderName,Address,AddressCode,OpenHours")] Emergency emergency)
        {
            if (id != emergency.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(emergency);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmergencyExists(emergency.Id))
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
            return View(emergency);
        }

        // GET: Emergencies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emergency = await _context.Emergency
                .FirstOrDefaultAsync(m => m.Id == id);
            if (emergency == null)
            {
                return NotFound();
            }

            return View(emergency);
        }

        // POST: Emergencies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var emergency = await _context.Emergency.FindAsync(id);
            _context.Emergency.Remove(emergency);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmergencyExists(int id)
        {
            return _context.Emergency.Any(e => e.Id == id);
        }
        public async Task<IActionResult> ParseData()
        {
            CsvParserOptions csvParserOptions = new CsvParserOptions(true, ',');
            CsvEmergencyMapping csvMapper = new CsvEmergencyMapping();
            CsvParser<Emergency> csvParser = new CsvParser<Emergency>(csvParserOptions, csvMapper);

            var result = csvParser
                .ReadFromFile(@"Data\LPS.csv", Encoding.ASCII)
                .ToList();

            foreach (var item in result)
            {
                if (item.Result.AddressCode == 0)
                {
                    item.Result.AddressCode = 0;
                }
            }
            foreach (var item in result) {
                _context.Emergency.Add(item.Result);
            }
            await _context.SaveChangesAsync();



            return RedirectToAction("Index");
        }
    }
}
