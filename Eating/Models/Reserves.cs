using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Eating.Models;

namespace Eating.Models
{
    public class Reserves
    {
        public int Id { get; set; }

        public string C_Id { get; set; }

        public int SeatId { get; set; }

        [Required]
        public int PeopleNum { get; set; }

        [StringLength(150)]
        public string Details { get; set; }

        [Required]
        public DateTime ReserveTime { get; set; }

        public bool IsSomke { get; set; }

        public Seat Seat { get; set; }

        public Customer Customer { get; set; }

    }
}