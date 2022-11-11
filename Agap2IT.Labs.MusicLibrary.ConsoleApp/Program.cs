// See https://aka.ms/new-console-template for more information



using Agap2IT.Labs.MusicLibrary.Dal;
using Agap2IT.Labs.MusicLibrary.Data.Models;

var dao = new SubscriptionDao();

dao.Add(new Subscription
{
    CreatedAt = DateTime.UtcNow,
    Duration = 365,
    Name = "Yearly Subscription",
    Price = 16,
    UpdatedAt = DateTime.UtcNow,
    Uuid = Guid.NewGuid()
});






