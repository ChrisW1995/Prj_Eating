using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Eating.ViewModels
{
    public class SetReservationTimeViewModel
    {
        public string r_id { get; set; }

        [Required]
        [Display(Name ="開放時間")]
        public TimeSpan ReservationTime { get; set; }

    }
}