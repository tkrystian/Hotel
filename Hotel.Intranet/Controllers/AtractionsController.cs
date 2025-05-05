using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hotel.Intranet.Data;
using Hotel.PortalWWW.Models.Atractions;

namespace Hotel.Intranet.Controllers
{
    public class AtractionsController : Controller
    {
        private readonly HotelIntranetContext _context;

        public AtractionsController(HotelIntranetContext context)
        {
            _context = context;
        }

        // GET: Atractions
        public async Task<IActionResult> Index()
        {
            return View(await _context.Atraction.ToListAsync());
        }

        // GET: Atractions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atraction = await _context.Atraction
                .FirstOrDefaultAsync(m => m.IdAtrakcji == id);
            if (atraction == null)
            {
                return NotFound();
            }

            return View(atraction);
        }

        // GET: Atractions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Atractions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAtrakcji,Nazwa,Opis,Cena,Status")] Atraction atraction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(atraction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(atraction);
        }

        // GET: Atractions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atraction = await _context.Atraction.FindAsync(id);
            if (atraction == null)
            {
                return NotFound();
            }
            return View(atraction);
        }

        // POST: Atractions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAtrakcji,Nazwa,Opis,Cena,Status")] Atraction atraction)
        {
            if (id != atraction.IdAtrakcji)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(atraction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AtractionExists(atraction.IdAtrakcji))
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
            return View(atraction);
        }

        // GET: Atractions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atraction = await _context.Atraction
                .FirstOrDefaultAsync(m => m.IdAtrakcji == id);
            if (atraction == null)
            {
                return NotFound();
            }

            return View(atraction);
        }

        // POST: Atractions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var atraction = await _context.Atraction.FindAsync(id);
            if (atraction != null)
            {
                _context.Atraction.Remove(atraction);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AtractionExists(int id)
        {
            return _context.Atraction.Any(e => e.IdAtrakcji == id);
        }
    }
}
