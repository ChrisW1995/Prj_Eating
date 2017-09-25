using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Eating.ViewModels
{
    public class CouponListViewModel
    {
        public string CouponId { get; set; }

        [Required, StringLength(25), Display(Name = "標題")]
        public string Title { get; set; }

        [Display(Name = "敘述")]
        public string Desciption { get; set; }

        [Required, Display(Name = "起始時間")]
        public DateTime StartTime { get; set; }

        [Display(Name = "結束時間")]
        public DateTime EndTime { get; set; }
    }
}