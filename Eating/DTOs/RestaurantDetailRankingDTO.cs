using Eating.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Eating.DTOs
{
    public class RestaurantDetailRankingDTO
    {
        public int Id { get; set; }

        [Required]
        public string R_Id { get; set; }

        [Required]
        public int C_Id { get; set; }

        [Required]
        public byte Rating { get; set; }

        [StringLength(200)]
        public string Comment { get; set; }

        public DateTime CommentTime { get; set; }

        

    }
}