using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Eating.Models
{
    public class WaitingLists
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CurrentNo { get; set; }

        [StringLength(200)]
        public string Detail { get; set; }

        public DateTime AddTime { get; set; }

        [Required]
        public int C_Id{ get; set; }

        public string R_Id { get; set; }

        public bool CheckStatus { get; set; }
        public Restaurant Restaurant { get; set; }

        public Customer Customer { get; set; }

    }
}