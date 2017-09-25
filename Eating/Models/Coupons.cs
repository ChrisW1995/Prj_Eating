using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Eating.Models
{
    public class Coupons
    {
        [Key, Index, StringLength(100)]
        public string CouponId { get; set; }

        [Required]
        public string R_Id { get; set; }

        [Required, StringLength(25)]
        public string Title { get; set; }

        public string Desciption { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public Restaurant Restaurant { get; set; }

        public ICollection<Customer> Customers { get; set; }
    }
}