using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Eating.DTOs
{
    public class CustomerVerifyDTO
    {
        [Required]
        public int C_Id { get; set; }

        [Required]
        public int VerifyCode { get; set; }


    }
}