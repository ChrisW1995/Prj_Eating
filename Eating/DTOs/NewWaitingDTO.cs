using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Eating.DTOs
{
    public class NewWaitingDTO
    {
        [StringLength(200)]
        public string Detail { get; set; }

        [Required]
        public int PeopleNum { get; set; }

        [Required]
        public int C_Id { get; set; }

        [Required]
        public string R_Id { get; set; }

    }
}