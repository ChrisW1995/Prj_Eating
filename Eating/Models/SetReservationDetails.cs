using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Eating.Models
{
    public class SetReservationDetails
    {
        public int Id { get; set; }

        [Required, StringLength(8)]
        public string R_id { get; set; }

        public int SeatId { get; set; }

        public TimeSpan ReservationTime { get; set; }

        public ICollection<Reservations> Reservations { get; set; }

        public Seat Seat { get; set; }

        public Restaurant Restaurant { get; set; }
    }
}