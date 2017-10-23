using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Eating.ViewModels
{
    public class NewSeatViewModel
    {
        public int? SeatId { get; set; }

        public string R_Id { get; set; }

        [Required]
        [Display(Name = "桌號")]
        public string SeatName { get; set; }

        [Required]
        [Display(Name = "座位數量")]
        public int SeatCapacity { get; set; }

        [Display(Name = "備註")]
        [StringLength(100)]
        public string SeatDetail { get; set; }

        [Required, Display(Name = "吸菸區")]
        public bool SeatSmoke { get; set; }


    }
}