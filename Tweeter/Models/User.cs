using System;
using System.Data.Entity;

namespace Tweeter.Models
{
    public class User
    {
        public int ID { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string avatar { get; set; }
        public string about { get; set; }
        public string name { get; set; }
        
    }

    public class UserDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}