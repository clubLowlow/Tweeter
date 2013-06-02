using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections;
using System.Collections.Generic;

namespace Tweeter.Models
{
    public class User
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Username { get; set; }
        public string Avatar { get; set; }
        public string About { get; set; }
        public string Name { get; set; }
        public string Website { get; set; }
        public ICollection<Tweet> Tweets { get; set; }
    }

}