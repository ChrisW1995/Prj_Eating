using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Eating.Models
{
    public class Seat
    {
        [Key]
        public int SeatId { get; set; }

        public string R_Id { get; set; }

        public string SeatName { get; set; }

        public int SeatCapacity { get; set; }

        [StringLength(100)]
        public string SeatDetail { get; set; }

        public bool SeatSmoke { get; set; }

        public float location_X { get; set; }

        public float location_Y { get; set; }

        public Restaurant Restaurant { get; set; }

        public ICollection<Reserves> Reserves { get; set; }
    }
}