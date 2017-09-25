using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Eating.Models
{
    public class Area
    {
        [Key]
        public int AreaId { get; set; }
        [Required]
        [StringLength(5)]
        public string Name { get; set; }
        public int CountyId { get; set; }
        public County  County { get; set; }
    }
}