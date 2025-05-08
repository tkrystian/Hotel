using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hotel.Intranet.Data;
using Hotel.PortalWWW.Models.Rooms;
using Hotel.PortalWWW.Models.Atractions;
using Hotel.Intranet.Models.DTO;

namespace Hotel.Intranet.Controllers
{
    public class RoomsController : Controller
    {
        private readonly HotelIntranetContext _context;

        public RoomsController(HotelIntranetContext context)
        {
            _context = context;
        }

        // GET: Rooms
        public async Task<IActionResult> Index()
        {
            return View(await _context.Room
                .Include(a => a.Media).ToListAsync());
        }

        // GET: Rooms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = await _context.Room
                .Include(a => a.Media)
                .FirstOrDefaultAsync(m => m.IdPokoju == id);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        // GET: Rooms/Create
        public IActionResult Create()
        {
            var media = _context.Media
                .Where(m => m.RelatedObjectType == "rooms")
                .ToList();

            ViewBag.MediaList = media;
            return View();
        }

        // POST: Rooms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPokoju,Typ,Numer,Opis,LiczbaOsob,Cena,Status,MediaId")] Room room)
        {
            if (ModelState.IsValid)
            {
                _context.Add(room);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.MediaList = new SelectList(_context.Media, "IdMedia", "FileName");
            return View(room);
        }

        // GET: Rooms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = await _context.Room.Include(a => a.Media).FirstOrDefaultAsync(a => a.IdPokoju == id);
            if (room == null)
            {
                return NotFound();
            }


            var mediaList = await _context.Media
                .Where(m => m.RelatedObjectType == "rooms")
                .Select(m => new MediaDto
                {
                    Id = m.IdMedia,
                    FilePath = m.FilePath
                })
                .ToListAsync();

            ViewBag.MediaListJson = mediaList;


            return View(room);
        }

        // POST: Rooms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPokoju,Typ,Numer,Opis,LiczbaOsob,Cena,Status,MediaId")] Room room)
        {
            if (id != room.IdPokoju)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(room);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomExists(room.IdPokoju))
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
            ViewBag.MediaList = new SelectList(_context.Media, "IdMedia", "FileName", room.MediaId);
            return View(room);
        }

        // GET: Rooms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = await _context.Room
                .FirstOrDefaultAsync(m => m.IdPokoju == id);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        // POST: Rooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var room = await _context.Room.FindAsync(id);
            if (room != null)
            {
                _context.Room.Remove(room);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomExists(int id)
        {
            return _context.Room.Any(e => e.IdPokoju == id);
        }
    }
}
