using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Hotel.PortalWWW.Models;
using Hotel.Data.Data;
using Microsoft.EntityFrameworkCore;
using Hotel.SharedUI;
using Hotel.Data.Data.DTO;

namespace Hotel.PortalWWW.Controllers;

public class HomeController : Controller
{
    private readonly HotelContext _context;

    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, HotelContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<IActionResult> Index(int? id)
    {
        ViewBag.ModelStrony = await _context.Page
                                .OrderBy(p => p.Pozycja)
                                .ToListAsync();

        ViewBag.Atrakcje = await _context.Atraction
                                .Include(a => a.Media)
                                .ToListAsync();

        ViewBag.Pokoje = await _context.Room
                                .Include(a => a.Media)
                                .ToListAsync();

        ViewBag.StronaGlowna = await _context.HomePage
                                .Select(h => new HomePageMediaDTO
                                {
                                    HomePage = h,
                                    Banner = _context.Media.FirstOrDefault(m => m.IdMedia == h.BannerId),
                                    Grafika = _context.Media.FirstOrDefault(m => m.IdMedia == h.GrafikaId)
                                }).ToListAsync();

        //ViewBag.Rezerwacje = await _context.Reservation
        //                        .Select(h => new ReservationDTO
        //                        {
        //                            Reservation = h,
        //                            User = _context.User.FirstOrDefault(u => u.IdUzytkownika == h.UzytkownikId),
        //                            Room = _context.Room.FirstOrDefault(r => r.IdPokoju == h.Room)
        //                        }).ToListAsync();



        id ??= 1;


        var item = await _context.Page
            .FirstOrDefaultAsync(p => p.IdStrony == id);

        return View(item);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
