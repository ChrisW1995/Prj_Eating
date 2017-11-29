using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Eating.Models
{
    public class Customer
    {
        [Key]
        public int C_Id { get; set; }

        [StringLength(25)]
        [Display(Name = "登入帳號")]
        public string C_Account { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "登入密碼")]
        public string C_Password { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "餐廳名稱")]
        public string C_Name { get; set; }

        public string C_PhoneNum { get; set; }

        [Required]
        [StringLength(100)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public DateTime SignUpTime { get; set; }

        public ICollection<WaitingLists> WaitingLists { get; set; }

        public ICollection<Reservations> Reserves { get; set; }

        public ICollection<Feedback> Feedbacks { get; set; }

        public ICollection<Coupons> Coupons { get; set; }

    }
}