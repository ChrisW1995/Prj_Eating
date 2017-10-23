using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Eating.DTOs
{
    public class CustomerRegisterDTO
    {
        [Required]
        [StringLength(25)]
        public string C_Account { get; set; }

        [Required]
        [StringLength(50)]
        public string C_Password { get; set; }

        [Required]
        [StringLength(50)]
        public string C_Name { get; set; }

        public string C_PhoneNum { get; set; }

        [Required]
        [StringLength(100)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }




    }
}
