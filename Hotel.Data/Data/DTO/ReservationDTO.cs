using Hotel.Data.Data.Atractions;
using Hotel.Data.Data.CMS;
using Hotel.Data.Data.Reservations;
using Hotel.Data.Data.Rooms;
using Hotel.Data.Data.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Data.Data.DTO
{
    public class ReservationDTO
    {
        public Reservation? Reservation { get; set; }
        public User? User { get; set; }
        public Room? Room { get; set; }
        public Atraction? Atraction { get; set; }
    }
}
