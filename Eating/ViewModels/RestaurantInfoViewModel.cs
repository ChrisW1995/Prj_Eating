using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Eating.ViewModels
{
    public class RestaurantInfoViewModel
    {
        [Required]
        [StringLength(50)]
        [Display(Name = "餐廳名稱")]
        public string R_Name { get; set; }

        [Required]
        [StringLength(15)]
        [Display(Name = "電話號碼")]
        public string R_PhoneNum { get; set; }

        [StringLength(100)]
        [Display(Name = "地址")]
        public string R_DetailAddress { get; set; }

        [Required]
        [Display(Name = "縣/市")]
        public string R_County { get; set; }

        [Required]
        [Display(Name = "地區")]
        public string R_Area { get; set; }


        [Required]
        [StringLength(100)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "營業時間")]
        public TimeSpan StartTime { get; set; }

        [Required]
        [Display(Name = "結束時間")]
        public TimeSpan CloseTime { get; set; }
    }
    
}