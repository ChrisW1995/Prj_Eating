using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Eating.DTOs
{
    public class RestaurantDetailDTO
    {
        [Key]
        [StringLength(32)]
        public string Id { get; set; }

        [Required]
        [StringLength(50)]
        public string R_Name { get; set; }

        [Required]
        [StringLength(15)]
        public string R_PhoneNum { get; set; }

        [Required]
        [StringLength(5)]

        public string R_County { get; set; }

        [Required]
        [StringLength(5)]

        public string R_Area { get; set; }

        [Required]
        [StringLength(100)]
        public string R_DetailAddress { get; set; }

        [Required]
        [StringLength(100)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public TimeSpan StartTime { get; set; }

        public TimeSpan CloseTime { get; set; }

        public int ReserveTimeSpan { get; set; }
    }
}