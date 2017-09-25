using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Eating.Models;

namespace Eating.Service
{
    public class AddressService
    {
        private ApplicationDbContext db;
        public AddressService()
        {
            db = new ApplicationDbContext();
        }

        /// <summary>
        /// Get countries list of address.
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, string> GetAllCountries()
        {
            var query = db.Counties.OrderBy(x => x.Id);
            return query.ToDictionary(x => x.Id.ToString(), x => x.CountyName);
        }

        public IEnumerable<Area> GetAllAreas(int _countryId)
        {
            var query = db.Areas.Where(x => x.CountyId == _countryId).ToList();

            return query;
        }
    }
}