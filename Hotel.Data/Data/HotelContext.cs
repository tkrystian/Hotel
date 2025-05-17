using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel.Data.Data.Atractions;
using Hotel.Data.Data.CMS;
using Hotel.Data.Data.Messages;
using Hotel.Data.Data.Reservations;
using Hotel.Data.Data.Rooms;
using Hotel.Data.Data.Users;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Data.Data
{
    public class HotelContext : DbContext
    {
        public HotelContext(DbContextOptions<HotelContext> options)
            : base(options)
        {
        }
        public DbSet<Atraction> Atraction { get; set; } = default!;
        public DbSet<Media> Media { get; set; } = default!;
        public DbSet<Message> Message { get; set; } = default!;
        public DbSet<Page> Page { get; set; } = default!;
        public DbSet<Reservation> Reservation { get; set; } = default!;
        public DbSet<Room> Room { get; set; } = default!;
        public DbSet<User> User { get; set; } = default!;
        public DbSet<HomePage> HomePage { get; set; } = default!;
        public DbSet<UserMessages> UserMessages { get; set; } = default!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relacja pomiędzy wiadomościami a użytkownikami przez UserMessages
            modelBuilder.Entity<UserMessages>()
                .HasOne(um => um.Sender) // Nadawca wiadomości
                .WithMany(u => u.SentMessages) // Użytkownik ma wiele wysłanych wiadomości
                .HasForeignKey(um => um.SenderId) // Klucz obcy do użytkownika nadawcy
                .OnDelete(DeleteBehavior.Restrict); // Zapobiega usuwaniu użytkownika przy usuwaniu wiadomości

            modelBuilder.Entity<UserMessages>()
                .HasOne(um => um.Recipient) // Odbiorca wiadomości
                .WithMany(u => u.ReceivedMessages) // Użytkownik ma wiele odebranych wiadomości
                .HasForeignKey(um => um.RecipientId) // Klucz obcy do użytkownika odbiorcy
                .OnDelete(DeleteBehavior.Restrict); // Zapobiega usuwaniu użytkownika przy usuwaniu wiadomości

            modelBuilder.Entity<UserMessages>()
                .HasOne(um => um.Message) // Wiadomość
                .WithMany(m => m.UserMessages) // Wiadomość ma wiele wpisów w tabeli UserMessages
                .HasForeignKey(um => um.MessageId) // Klucz obcy do wiadomości
                .OnDelete(DeleteBehavior.Restrict); // Zapobiega usuwaniu wiadomości przy usuwaniu wpisów UserMessages

            modelBuilder.Entity<Atraction>()
                .Property(a => a.Cena)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Room>()
                .Property(r => r.Cena)
                .HasColumnType("decimal(18,2)");
        }
    }
}
