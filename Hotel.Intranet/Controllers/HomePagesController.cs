using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hotel.Data.Data;
using Hotel.Data.Data.DTO;

namespace Hotel.Intranet.Controllers
{
    public class HomePagesController : Controller
    {
        private readonly HotelContext _context;

        public HomePagesController(HotelContext context)
        {
            _context = context;
        }

        // GET: HomePages
        public async Task<IActionResult> Index()
        {
            var hotelIntranetContext = _context.HomePage.Include(h => h.Banner).Include(h => h.Grafika);
            return View(await hotelIntranetContext.ToListAsync());
        }

        // GET: HomePages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var homePage = await _context.HomePage
                .Include(h => h.Banner)
                .Include(h => h.Grafika)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (homePage == null)
            {
                return NotFound();
            }

            return View(homePage);
        }

        // GET: HomePages/Create
        public IActionResult Create()
        {
            var banners = _context.Media
                .Where(m => m.RelatedObjectType == "banners")
                .Select(m => new { Id = m.IdMedia, Name = m.FileName })
                .ToList();

            var misc = _context.Media
                .Where(m => m.RelatedObjectType == "misc")
                .Select(m => new { Id = m.IdMedia, Name = m.FileName })
                .ToList();

            ViewData["BannerId"] = new SelectList(banners, "Id", "Name");
            ViewData["GrafikaId"] = new SelectList(misc, "Id", "Name");
            return View();
        }

        // POST: HomePages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BannerId,GrafikaId,Naglowek,Tagi,Opis")] Data.Data.CMS.HomePage homePage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(homePage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BannerId"] = new SelectList(_context.Media, "IdMedia", "FileName", homePage.BannerId);
            ViewData["GrafikaId"] = new SelectList(_context.Media, "IdMedia", "FileName", homePage.GrafikaId);
            return View(homePage);
        }

        // GET: HomePages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var homePage = await _context.HomePage.FindAsync(id);
            if (homePage == null)
            {
                return NotFound();
            }

            var banners = _context.Media
                .Where(m => m.RelatedObjectType == "banners")
                .Select(m => new { Id = m.IdMedia, Name = m.FileName })
                .ToList();

            var misc = _context.Media
                .Where(m => m.RelatedObjectType == "misc")
                .Select(m => new { Id = m.IdMedia, Name = m.FileName })
                .ToList();


            ViewData["BannerId"] = new SelectList(banners, "Id", "Name");
            ViewData["GrafikaId"] = new SelectList(misc, "Id", "Name");
            return View(homePage);
        }

        // POST: HomePages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BannerId,GrafikaId,Naglowek,Tagi,Opis")] Data.Data.CMS.HomePage homePage)
        {
            if (id != homePage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(homePage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HomePageExists(homePage.Id))
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
            ViewData["BannerId"] = new SelectList(_context.Media, "IdMedia", "FileName", homePage.BannerId);
            ViewData["GrafikaId"] = new SelectList(_context.Media, "IdMedia", "FileName", homePage.GrafikaId);
            return View(homePage);
        }

        // GET: HomePages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var homePage = await _context.HomePage
                .Include(h => h.Banner)
                .Include(h => h.Grafika)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (homePage == null)
            {
                return NotFound();
            }

            return View(homePage);
        }

        // POST: HomePages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var homePage = await _context.HomePage.FindAsync(id);
            if (homePage != null)
            {
                _context.HomePage.Remove(homePage);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HomePageExists(int id)
        {
            return _context.HomePage.Any(e => e.Id == id);
        }

    }
}
