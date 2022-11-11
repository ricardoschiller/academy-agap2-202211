using Agap2IT.Labs.MusicLibrary.Business.Common;
using Agap2IT.Labs.MusicLibrary.Dal;
using Agap2IT.Labs.MusicLibrary.Data.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Agap2IT.Labs.MusicLibrary.Business
{
    public class UsersBO
    {
        public async Task<OperationResult<IList<UserWithSubscriptionPoco>>> GetAllUsersFromSubscription(Guid subscriptionUuid)
        {
            try
            {
                var transactionOptions = new TransactionOptions();
                transactionOptions.IsolationLevel = IsolationLevel.ReadCommitted;
                transactionOptions.Timeout = TimeSpan.FromSeconds(30);

                using(var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions, TransactionScopeAsyncFlowOption.Enabled))
                {
                    var dao = new UsersDao();
                    var result = await dao.GetAllUsersFromSubscription(subscriptionUuid);

                    transactionScope.Complete();

                    return new OperationResult<IList<UserWithSubscriptionPoco>>(result);
                }

                
            }
            catch (Exception ex)
            {
                return new OperationResult<IList<UserWithSubscriptionPoco>>(false, ex);
            } 
        }


    }
}
