using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Eating.Models
{
    public partial class Restaurant
    {
        
        [Key]
        [StringLength(25)]
        [Display(Name = "登入帳號")]
        public string R_Account { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "登入密碼")]
        public string R_Password { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "餐廳名稱")]
        public string R_Name { get; set; }

        [Required]
        [StringLength(15)]
        [Display(Name = "電話號碼")]
        public string R_PhoneNum { get; set; }

        [Required]
        [StringLength(5)]

        public string R_County { get; set; }

        [Required]
        [StringLength(5)]

        public string R_Area { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "地址")]
        public string R_DetailAddress { get; set; }

        [Required]
        [StringLength(100)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [StringLength(20)]
        public string AuthCode { get; set; }

        [Display(Name ="營業時間")]
        public TimeSpan StartTime { get; set; }
        [Display(Name = "結束時間")]
        public TimeSpan CloseTime { get; set; }
        public DateTime SignUpTime { get; set; }

        public ICollection<Coupons> Coupons { get; set; }

        public ICollection<Seat> Seats { get; set; }

        public ICollection<WaitingLists> WaitingLists { get; set; }

        public ICollection<Feedback> Feedbacks { get; set; }

    }
}