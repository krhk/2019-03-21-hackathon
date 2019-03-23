using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Hackathon.Data;
using Microsoft.AspNetCore.Mvc;
using Hackathon.Models;
using Microsoft.EntityFrameworkCore;

namespace Hackathon.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        private readonly ApplicationDbContext _context;

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> Mapa()
        {
            return View();
        }

        public async Task<IActionResult> Nemocnice()
        {
            return View(await _context.Nemocnice.ToListAsync());
        }
        public async Task<IActionResult> Policie()
        {
            return View(await _context.Policie.ToListAsync());
        }
        public async Task<IActionResult> Stomatologie()
        {
            return View(await _context.Stomatologie.ToListAsync());
        }
        public async Task<IActionResult> Hasici()
        {
            return View(await _context.Hasici.ToListAsync());
        }
    }
}
