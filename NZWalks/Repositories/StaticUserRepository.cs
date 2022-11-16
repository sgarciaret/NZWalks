﻿using NZWalksAPI.Models.Domain;

namespace NZWalksAPI.Repositories
{
    public class StaticUserRepository : IUserRepository
    {
        private List<User> Users= new List<User>()
        {
            //new User()
            //{
            //    FirstName = "Read Only", LastName = "User", EmailAdress = "readonly@user.com", Id= Guid.NewGuid(), Username = "readonly@user.com", Password = "Readonly@user.com",
            //    Roles = new List<string> {"reader"}
            //},
            //new User()
            //{
            //    FirstName = "Read Write", LastName = "User", EmailAdress = "readwrite@user.com", Id= Guid.NewGuid(), Username = "readwrite@user.com", Password = "Readwrite@user.com",
            //    Roles = new List<string> {"reader", "writer"}
            //}
        };

        public async Task<User> AuthenticateAsync(string username, string password)
        {
            var user = Users.Find(x => x.Username.Equals(username, StringComparison.InvariantCultureIgnoreCase) &&
            x.Password == password);

            return user;
        }
    }
}
