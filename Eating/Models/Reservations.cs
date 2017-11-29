using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Eating.Models;

namespace Eating.Models
{
    public class Reservations
    {
        public int Id { get; set; }

        [Required]
        public int C_Id { get; set; }

        [Required, StringLength(25)]
        public string Name { get; set; }

        [Required, StringLength(15)]
        public string PhoneNum { get; set; }

        public int ReservationTimeId { get; set; }

        [Required]
        public int PeopleNum { get; set; }

        [StringLength(150)]
        public string Details { get; set; }

        [StringLength(200)]
        public string RegDeviceID { get; set; }

        [Required]
        public DateTime AddTime { get; set; }

        public bool IsSomke { get; set; }


        public Customer Customer { get; set; }

        public SetReservationDetails SetReservationDetails { get; set; }
    }
}