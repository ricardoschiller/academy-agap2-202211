using Agap2IT.Labs.MusicLibrary.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agap2IT.Labs.MusicLibrary.Data.Users
{
    public class UserWithSubscriptionPoco
    {
        public int UserId { get; set; }

        public string UserEmail { get; set; } = null!;

        public string UserName { get; set; } = null!;

        public DateTime UserDateBirth { get; set; }

        public int SubscriptionId { get; set; }

        public string SubscriptionName { get; set; } = null!;

        public decimal SubscriptionPrice { get; set; }

        public int SubscriptionDuration { get; set; }
    }
}
