using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Eating.ViewModels
{
    public class MemberLoginViewModel
    {
        [Display(Name = "登入帳號")]
        [Required(ErrorMessage = "請輸入帳號")]
        public string R_Account { get; set; }

        [Display(Name = "登入密碼"), DataType(DataType.Password)]
        [Required(ErrorMessage = "請輸入密碼")]
        public string R_Password { get; set; }
    }
}