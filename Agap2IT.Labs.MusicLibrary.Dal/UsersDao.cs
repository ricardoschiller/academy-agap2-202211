using Agap2IT.Labs.MusicLibrary.Data.Models;
using Agap2IT.Labs.MusicLibrary.Data.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agap2IT.Labs.MusicLibrary.Dal
{
    public class UsersDao
    {
        public async Task<IList<UserWithSubscriptionPoco>> GetAllUsersFromSubscription(Guid subscriptionUuid)
        {

            MemoryCache cache = new MemoryCache(new MemoryCacheOptions());

            var cachedResult = cache.Get<IList<UserWithSubscriptionPoco>>("GetAllUsersFromSubscription_" + subscriptionUuid.ToString());

            if (cachedResult != null) return cachedResult;

            using(var context = new AcademyAgap2202211Context())
            {
                var query = (from subscription in context.Subscriptions
                               join subscriptionLog in context.SubscriptionLogs
                               on subscription.Id equals subscriptionLog.SubscriptionId
                               join user in context.Users
                               on subscriptionLog.UserId equals user.Id

                               where subscription.Uuid == subscriptionUuid

                               select new UserWithSubscriptionPoco
                               {
                                   SubscriptionDuration = subscription.Duration,
                                   SubscriptionId = subscription.Id,
                                   SubscriptionName = subscription.Name,
                                   SubscriptionPrice = subscription.Price,
                                   UserDateBirth = user.DateBirth,
                                   UserEmail = user.Email,
                                   UserId = user.Id,
                                   UserName = user.Name
                               });

                query = (from i in query
                         orderby i.UserDateBirth
                         select i);

                var result = await query.ToListAsync();

                cache.Set(result, "GetAllUsersFromSubscription_" + subscriptionUuid.ToString(), TimeSpan.FromMinutes(1));

                return result;
            }
            
        }
    }
}
