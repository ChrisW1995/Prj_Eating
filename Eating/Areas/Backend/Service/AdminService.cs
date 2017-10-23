using Eating.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eating.Areas.Backend.Service
{
    public class AdminService
    {
        private ApplicationDbContext db = new ApplicationDbContext();

       public bool IsExist(string account,string password)
        {
            var result = db.Admins.Where(a => a.Adm_Account == account && a.Adm_Password == password).SingleOrDefault();
            return (result == null ? false : true);
        }
    }
}