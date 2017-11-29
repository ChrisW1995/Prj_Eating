using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Eating.Models
{
    public class Menu
    {
        public int Id { get; set; }

        [Required, StringLength(8)]
        public string R_Id { get; set; }

        [StringLength(50)]
        public string FoodName { get; set; }

        [StringLength(125)]
        public string ImgPath { get; set; }

        public Restaurant Restaurant { get; set; }
    }
}