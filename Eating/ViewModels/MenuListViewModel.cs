using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Eating.ViewModels
{
    public class MenuListViewModel
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public string ImgPath { get; set; }

    }
}