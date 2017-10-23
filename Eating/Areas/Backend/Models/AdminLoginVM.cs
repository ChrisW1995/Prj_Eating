using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Eating.Areas.Backend.Models
{
    public class AdminLoginVM
    {
        [StringLength(25), Display(Name = "登入帳號")]
        public string Adm_Account { get; set; }

        [StringLength(25), Display(Name ="登入密碼")]
        public string Adm_Password { get; set; }
    }
}