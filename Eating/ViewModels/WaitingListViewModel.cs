using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Eating.ViewModels
{
    public class WaitingListViewModel
    {
        public int Id { get; set; }

        [Required, Display(Name = "候位號碼")]
        public int CurrentNo { get; set; }

        [StringLength(200), Display(Name = "備註")]
        public string Detail { get; set; }

        [Display(Name = "加入時間")]
        public DateTime AddTime { get; set; }

        public int C_Id { get; set; }

        [Display(Name = "用戶姓名")]
        public string C_Name { get; set; }

        public string FormattedDate => AddTime.ToString();
    }
}