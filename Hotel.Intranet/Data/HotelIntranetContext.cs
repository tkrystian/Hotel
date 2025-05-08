using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Hotel.PortalWWW.Models.Atractions;
using Hotel.PortalWWW.Models.CMS;
using Hotel.PortalWWW.Models.Rooms;
using Hotel.Intranet.Models.Intranet;

namespace Hotel.Intranet.Data
{
    public class HotelIntranetContext : DbContext
    {
        public HotelIntranetContext (DbContextOptions<HotelIntranetContext> options)
            : base(options)
        {
        }
        public DbSet<Media> Media { get; set; } = default!;
        public DbSet<Atraction> Atraction { get; set; } = default!;
        public DbSet<Messages> Messages { get; set; } = default!;
        public DbSet<Page> Page { get; set; } = default!;
        public DbSet<Reservation> Reservation { get; set; } = default!;
        public DbSet<Room> Room { get; set; } = default!;
        public DbSet<User> User { get; set; } = default!;
        public DbSet<HomePage> HomePage { get; set; } = default!;

    }
}
