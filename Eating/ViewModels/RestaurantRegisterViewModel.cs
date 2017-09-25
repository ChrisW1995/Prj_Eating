using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Eating.Models;
using System.ComponentModel.DataAnnotations;

namespace Eating.ViewModels
{
    public class RestaurantRegisterViewModel
    {
        [Required]
        [StringLength(25)]
        [Display(Name = "登入帳號")]
        public string R_Account { get; set; }

        [Required]
        [StringLength(25)]
        [DataType(DataType.Password)]
        [MinLength(6), MaxLength(25)]
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
        [StringLength(100)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [StringLength(25)]
        [Display(Name = "確認密碼")]
        [DataType(DataType.Password)]
        [Compare("R_Password", ErrorMessage = "兩次輸入的密碼不一致!")]
        public string checkR_Password { get; set; }

        [Required]
        [Display(Name = "縣/市")]
        public string R_County { get; set; }

        [Required]
        [Display(Name = "地區")]
        public string R_Area { get; set; }


        [Display(Name = "營業時間")]
        public TimeSpan StartTime { get; set; }

        [Display(Name = "結束時間")]
        public TimeSpan CloseTime { get; set; }

        [Required, Display(Name = "詳細地址")]
        public string DetailAddr { get; set; }


        public IEnumerable<County> Counties { get; set; }
        public IEnumerable<Area> Areas { get; set; }

    }
}