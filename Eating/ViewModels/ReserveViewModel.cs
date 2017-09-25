using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Eating.Models;
using System.ComponentModel.DataAnnotations;

namespace Eating.ViewModels
{
    public class ReserveViewModel
    {
        public int Id { get; set; }

        [Required]
        public int PeopleNum { get; set; }

        [StringLength(150)]
        public string Details { get; set; }

        [Required]
        public DateTime ReserveTime { get; set; }

        public int SeatId { get; set; }
        [StringLength(10)]
        public string R_Id { get; set; }

        public string C_Name { get; set; }

        public string C_PhoneNum { get; set; }

        public string SeatName { get; set; }

        public int SeatCapacity { get; set; }

        public bool SeatSmoke { get; set; }

        public IEnumerable<Seat> Seats { get; set; }

        public string FormattedDate => ReserveTime.ToString("yyyy/MM/dd");
    }
}