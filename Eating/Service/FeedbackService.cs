using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Eating.Models;
using Eating.ViewModels;
using Eating.Interface;
using Eating.Repository;
using Eating.Service.Interface;
using AutoMapper;

namespace Eating.Service
{
    public class FeedbackService : IFeedBackService
    {
        private IRepository<Feedback> repository = new GenericRepository<Feedback>(new ApplicationDbContext());

        public IResult Create(Feedback instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException();
            }

            IResult result = new Result(false);

            try
            {
                repository.Create(instance);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Exception = ex;
            }
            return result;
        }

        public IEnumerable<Feedback> GetList()
        {
            throw new NotImplementedException();
        }

        public Feedback GetByID(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Feedback> GetFeedbackByRAccount(string r_id)
        {

            return repository.GetList(x => x.R_Id == r_id).ToList();
        }

        public IEnumerable<FeedbacRatingkViewModel> GetRatingVM(string r_id)
        {
            var feedbackList = GetFeedbackByRAccount(r_id).OrderBy(o=>o.Rating).Select(Mapper.Map<Feedback, FeedbacRatingkViewModel>);
            return feedbackList;
        }

        public bool IsExists(int Id)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Feedback instance)
        {
            throw new NotImplementedException();
        }
    }
}