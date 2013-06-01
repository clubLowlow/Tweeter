using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

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
        public string Website { get; set; }
        
    }

}