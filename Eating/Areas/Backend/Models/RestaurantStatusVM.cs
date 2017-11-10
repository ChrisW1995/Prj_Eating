using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Eating.Areas.Backend.Models
{
    public class RestaurantStatusVM
    {
        public string Id { get; set; }

        [Display(Name = "登入帳號")]
        public string R_Account { get; set; }

        [Required]
        [Display(Name = "餐廳名稱")]
        public string R_Name { get; set; }

        [Required]
        [Display(Name = "電話號碼")]
        public string R_PhoneNum { get; set; }

        [Required]
        [Display(Name = "縣/市")]
        public string R_County { get; set; }

        [Display(Name = "鄉鎮/市/區")]
        [Required]
        public string R_Area { get; set; }

        [Required]
        [Display(Name = "詳細路段")]
        public string R_DetailAddress { get; set; }

        [Display(Name = "註冊時間")]
        public DateTime SignUpTime { get; set; }

        [Display(Name = "啟用狀態")]
        public bool StatusFlg { get; set; }

        public bool isCheck { get; set; }

        public string FormattedDate => SignUpTime.ToString();
        public IEnumerable<SelectListItem> StatusList { get; set; }
    }
}