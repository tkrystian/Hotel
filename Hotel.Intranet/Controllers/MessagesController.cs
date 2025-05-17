using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hotel.Data.Data;
using Hotel.Data.Data.DTO;
using Hotel.Data.Data.Users;
using Hotel.Data.Data.Messages;

namespace Hotel.Intranet.Controllers
{
    public class MessagesController : Controller
    {
        private readonly HotelContext _context;

        public MessagesController(HotelContext context)
        {
            _context = context;
        }

        // GET: Messages
        public async Task<IActionResult> Index()
        {
            var messages = await _context.Message
                 .Include(m => m.UserMessages)
                 .ThenInclude(um => um.Sender!)
                 .Include(m => m.UserMessages)
                 .ThenInclude(um => um.Recipient!)
                 .ToListAsync();


            return View(messages);
        }

        // GET: Messages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var message = await _context.Message
                .Include(m => m.UserMessages)
                .ThenInclude(um => um.Sender)
                .Include(m => m.UserMessages)
                .ThenInclude(um => um.Recipient)
                .FirstOrDefaultAsync(m => m.IdWiadomosci == id);

            if (message == null) return NotFound();

            var userMessage = message.UserMessages.FirstOrDefault();

            var dto = new MessageDto
            {
                IdWiadomosci = message.IdWiadomosci,
                Temat = message.Temat,
                Tresc = message.Tresc,
                DataWyslania = message.DataWyslania,
                SenderName = userMessage?.Sender?.Imie,
                RecipientName = userMessage?.Recipient?.Imie
            };

            return View(dto);
        }


        // GET: Messages/Create
        public async Task<IActionResult> Create()
        {
            var users = await _context.User.ToListAsync();

            var dto = new MessageDto
            {
                DataWyslania = DateTime.Now,
                Users = users.Select(u => new SelectListItem
                {
                    Value = u.IdUzytkownika.ToString(),
                    Text = u.Imie
                }).ToList()
            };

            return View(dto);
        }


        // POST: Messages/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MessageDto dto)
        {
            if (!ModelState.IsValid)
            {
                var users = await _context.User.ToListAsync();
                dto.Users = users.Select(u => new SelectListItem
                {
                    Value = u.IdUzytkownika.ToString(),
                    Text = u.Imie
                }).ToList();
                return View(dto);
            }

            var message = new Message
            {
                Temat = dto.Temat ?? string.Empty,
                Tresc = dto.Tresc ?? string.Empty,
                DataWyslania = dto.DataWyslania
            };

            _context.Message.Add(message);
            await _context.SaveChangesAsync();

            var userMessage = new UserMessages
            {
                MessageId = message.IdWiadomosci,
                SenderId = dto.SenderId,
                RecipientId = dto.RecipientId,
                Status = MessageStatus.Wyslana
            };

            _context.UserMessages.Add(userMessage);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        // GET: Messages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var message = await _context.Message
                .Include(m => m.UserMessages)
                .FirstOrDefaultAsync(m => m.IdWiadomosci == id);

            if (message == null) return NotFound();

            var userMessage = message.UserMessages.FirstOrDefault();
            if (userMessage == null) return NotFound();

            var users = await _context.User.ToListAsync();

            var dto = new MessageDto
            {
                IdWiadomosci = message.IdWiadomosci,
                Temat = message.Temat,
                Tresc = message.Tresc,
                DataWyslania = message.DataWyslania,
                SenderId = userMessage.SenderId,
                RecipientId = userMessage.RecipientId,
                Users = users.Select(u => new SelectListItem
                {
                    Value = u.IdUzytkownika.ToString(),
                    Text = u.Imie
                }).ToList()
            };

            return View(dto);
        }


        // POST: Messages/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(MessageDto dto)
        {
            if (!ModelState.IsValid)
            {
                var users = await _context.User.ToListAsync();
                dto.Users = users.Select(u => new SelectListItem
                {
                    Value = u.IdUzytkownika.ToString(),
                    Text = u.Imie
                }).ToList();

                return View(dto);
            }

            var message = await _context.Message
                .Include(m => m.UserMessages)
                .FirstOrDefaultAsync(m => m.IdWiadomosci == dto.IdWiadomosci);

            if (message == null) return NotFound();

            message.Temat = dto.Temat ?? string.Empty;
            message.Tresc = dto.Tresc ?? string.Empty;
            message.DataWyslania = dto.DataWyslania;

            var userMessage = message.UserMessages.FirstOrDefault();
            if (userMessage != null)
            {
                userMessage.SenderId = dto.SenderId;
                userMessage.RecipientId = dto.RecipientId;
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        // GET: Messages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var message = await _context.Message
                .Include(m => m.UserMessages)
                .ThenInclude(um => um.Sender)
                .Include(m => m.UserMessages)
                .ThenInclude(um => um.Recipient)
                .FirstOrDefaultAsync(m => m.IdWiadomosci == id);

            if (message == null)
            {
                return NotFound();
            }

            return View(message);
        }

        // POST: Messages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var message = await _context.Message
                .Include(m => m.UserMessages)
                .FirstOrDefaultAsync(m => m.IdWiadomosci == id);

            if (message != null)
            {
                _context.UserMessages.RemoveRange(message.UserMessages);
                _context.Message.Remove(message);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }


        private bool UserMessagesExists(int id)
        {
            return _context.UserMessages.Any(e => e.MessageId == id);
        }
    }
}
