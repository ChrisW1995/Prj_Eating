using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Eating.Models;
using System.ComponentModel.DataAnnotations;

namespace Eating.ViewModels
{
    public class RestaurantAccountViewModel
    {
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