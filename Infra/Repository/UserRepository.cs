using System.Collections.Generic;
using System.Linq;
using ApiFantasy.Domain.Models;

namespace ApiFantasy.Infra.Repository
{
     public static class UserRepository
    {
        public static User Get(string username, string password)
        {
            var users = new List<User>();
            users.Add(new User { Id = 1, Username = "thomasgreg", Password = "sons" });
            return users.Where(x => x.Username.ToLower() == username.ToLower() && x.Password == x.Password).FirstOrDefault();
        }
    }
}