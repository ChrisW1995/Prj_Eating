using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Eating.Models;

namespace Eating.Models
{
    public class Feedback
    {
        public int Id { get; set; }

        [Required]
        public string R_Id { get; set; }

        [Required]
        public int C_Id { get; set; }

        [Required]
        public byte  Rating { get; set; }

        [StringLength(200)]
        public string Comment { get; set; }

        public DateTime CommentTime { get; set; }

        [StringLength(200)]
        public string Reply { get; set; }

        public DateTime ReplyTime { get; set; }

        public Restaurant Restaurant { get; set; }


        public Customer Customer { get; set; }
    }
}