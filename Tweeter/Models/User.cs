using System;
using System.Data.Entity;

namespace Tweeter.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Avatar { get; set; }
        public string About { get; set; }
        public string Name { get; set; }
        
    }

    public class UserDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}