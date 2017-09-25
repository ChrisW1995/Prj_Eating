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
        [StringLength(25)]
        [Display(Name = "登入帳號")]
        public string R_Account { get; set; }

        [Required]
        [StringLength(25)]
        [DataType(DataType.Password)]
        [MinLength(6), MaxLength(25)]
        [Display(Name = "舊密碼")]
        public string R_Password { get; set; }

        [Required]
        [StringLength(25)]
        [Display(Name = "新密碼")]
        [DataType(DataType.Password)]
        public string new_R_Password { get; set; }

        [Required]
        [StringLength(25)]
        [Display(Name = "確認新密碼")]
        [DataType(DataType.Password)]
        [Compare("new_R_Password", ErrorMessage = "兩次輸入的密碼不一致!")]
        public string check_new_R_Password { get; set; }
    }
}