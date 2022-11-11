using System;
using System.Collections.Generic;

namespace Agap2IT.Labs.MusicLibrary.Data.Models;

public partial class Subscription
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public int Duration { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public bool IsDeleted { get; set; }

    public Guid Uuid { get; set; }

    public virtual ICollection<SubscriptionLog> SubscriptionLogs { get; } = new List<SubscriptionLog>();
}
