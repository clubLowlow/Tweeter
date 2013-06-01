using System;
using System.Data.Entity;

namespace Tweeter.Models
{
    public class Tweet
    {
        public int ID { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }
        public int UserId { get; set; }

    }

    public class TweetDBContext : DbContext
    {
        public DbSet<Tweet> Tweets { get; set; }
    }

}