using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hotel.Intranet.Data;

namespace Hotel.Intranet.Controllers
{
    public class MediaController : Controller
    {
        private readonly HotelIntranetContext _context;

        public MediaController(HotelIntranetContext context)
        {
            _context = context;
        }

        // GET: Media
        public async Task<IActionResult> Index()
        {
            return View(await _context.Media.ToListAsync());
        }

        // GET: Media/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var media = await _context.Media
                .FirstOrDefaultAsync(m => m.IdMedia == id);
            if (media == null)
            {
                return NotFound();
            }

            return View(media);
        }

        // GET: Media/Create
        public IActionResult Create()
        {
            var contentDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/content/media");
            var files = Directory.Exists(contentDirectory)
                ? Directory.GetFiles(contentDirectory).Select(file => Path.GetFileName(file) ?? string.Empty).ToList()
                : new List<string>();


            ViewBag.ContentFiles = files;
            return View();
        }

        // POST: Media/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMedia,FileName,FilePath,FileType,RelatedObjectType,CreatedAt")] Media media)
        {

            if (ModelState.IsValid)
            {
                media.CreatedAt = DateTime.Now;
                _context.Add(media);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(media);
        }

        // GET: Media/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var media = await _context.Media.FindAsync(id);
            if (media == null)
            {
                return NotFound();
            }

            var contentDirectory = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/content/media/{media.RelatedObjectType}");
            var files = Directory.Exists(contentDirectory)
                ? Directory.GetFiles(contentDirectory).Select(file => Path.GetFileName(file) ?? string.Empty).ToList()
                : new List<string>();

            ViewBag.ContentFiles = files;
            ViewBag.SelectedFilePath = media.FilePath;
            return View(media);
        }

        // POST: Media/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMedia,FileName,FilePath,FileType,RelatedObjectType")] Media media)
        {
            if (id != media.IdMedia)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var existingMedia = await _context.Media.AsNoTracking().FirstOrDefaultAsync(m => m.IdMedia == id);
                    if (existingMedia == null)
                    {
                        return NotFound();
                    }

                    media.CreatedAt = existingMedia.CreatedAt;
                    _context.Update(media);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MediaExists(media.IdMedia))
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
            return View(media);
        }

        // GET: Media/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var media = await _context.Media
                .FirstOrDefaultAsync(m => m.IdMedia == id);
            if (media == null)
            {
                return NotFound();
            }

            return View(media);
        }

        // POST: Media/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var media = await _context.Media.FindAsync(id);
            if (media != null)
            {
                _context.Media.Remove(media);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MediaExists(int id)
        {
            return _context.Media.Any(e => e.IdMedia == id);
        }

        [HttpGet]
        public IActionResult GetFilesByType(string type)
        {
            if (string.IsNullOrEmpty(type))
            {
                return BadRequest("Type is required.");
            }

            var contentDirectory = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/content/media/{type}");
            var files = Directory.Exists(contentDirectory)
                ? Directory.GetFiles(contentDirectory).Select(file => Path.GetFileName(file) ?? string.Empty).ToList()
                : new List<string>();


            return Json(files);
        }

    }
}
