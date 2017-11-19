using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Eating.DTOs
{
    public class CustomerLoginDTO
    {
        [Required]
        [StringLength(25)]
        public string C_Account { get; set; }

        [Required]
        [StringLength(50)]
        public string C_Password { get; set; }

      
    }
}