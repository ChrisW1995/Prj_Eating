using Eating.Interface;
using Eating.Models;
using Eating.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eating.Service.Interface
{
    interface IFeedBackService
    {
        IResult Create(Feedback instance);

        IResult Update(Feedback instance);

        bool IsExists(int Id);

        Feedback GetByID(int Id);

        IEnumerable<Feedback> GetList();

        IEnumerable<Feedback> GetFeedbackByRAccount(string r_id);

        IEnumerable<FeedbacRatingkViewModel> GetRatingVM(string r_id);
    }
}
