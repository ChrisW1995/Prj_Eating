using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Eating.Models
{
    public class County
    {
        [Key]
        public int Id { get; set; }
        [StringLength(5)]
        [Required]
        public string CountyName { get; set; }
        public ICollection<Area> Areas { get; set; }
    }
}