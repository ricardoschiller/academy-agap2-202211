// See https://aka.ms/new-console-template for more information



using Agap2IT.Labs.MusicLibrary.Dal;
using Agap2IT.Labs.MusicLibrary.Data.Models;


var dao = new GenericDao();
var usersDao = new UsersDao();

var results = await usersDao.GetAllUsersFromSubscription(Guid.Parse("7CABD5B0-D2E1-4FC0-AF7C-46B545F1259D"));
var results2 = await usersDao.GetAllUsersFromSubscription(Guid.Parse("7CABD5B0-D2E1-4FC0-AF7C-46B545F1259D"));


Console.ReadLine();






