using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Eating.Models
{
    public class Admins
    {
        [Key]
        public int Id { get; set; }

        [StringLength(25)]
        public string Adm_Account { get; set; }

        [StringLength(25)]
        public string Adm_Password { get; set; }
    }
}