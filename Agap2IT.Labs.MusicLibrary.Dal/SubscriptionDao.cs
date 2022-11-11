using Agap2IT.Labs.MusicLibrary.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agap2IT.Labs.MusicLibrary.Dal
{
    public class SubscriptionDao
    {
        public void Add(Subscription subscription)
        {
            using (var context = new AcademyAgap2202211Context())
            {
                context.Entry(subscription).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Update(Subscription subscription)
        {
            using (var context = new AcademyAgap2202211Context())
            {
                context.Entry(subscription).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
        }
        public void Delete(Subscription subscription)
        {
            using (var context = new AcademyAgap2202211Context())
            {
                context.Entry(subscription).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Subscription Get(int id)
        {
            using (var context = new AcademyAgap2202211Context())
            {
                return context.Subscriptions.Where(s => s.Id == id).SingleOrDefault();
            }
        }
    }
}
