using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eating.Interface;
using Eating.Models;
using Eating.ViewModels;

namespace Eating.Service.Interface
{
    interface IWaitingListService
    {
        IResult Create(WaitingLists instance);

        IResult Update(WaitingLists instance);

        IResult CancelWaiting(int waitingId);

        void sendNotificationAsync(string r_id);
        bool IsExists(int waitingID);

        WaitingLists GetByID(int waitingID);

        IEnumerable<WaitingLists> GetAll();

        IEnumerable<WaitingLists> GetWaitingListsByRAccount(string r_id);
        IEnumerable<WaitingListViewModel> GetJoinCIdWaitingLists(IEnumerable<WaitingLists> WaitingLists);
    }
}
