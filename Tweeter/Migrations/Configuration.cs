namespace Tweeter.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Tweeter.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Tweeter.Models.TweeterDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Tweeter.Models.TweeterDBContext context)
        {
            var users = new List<User>
            {
                new User
                {
                    Username = "@ymolina",
                    Password = "ymolina",
                    Avatar = "",
                    About = "The greatest catcher in the world",
                    Name = "Yadier Molina",
                    Website = "www.yadi.com"
                }
            };

            users.ForEach(u => context.Users.AddOrUpdate(u));


            var tweets = new List<Tweet>{
                new Tweet
                {
                    Text = "poignant",
                    CreatedAt = DateTime.Parse("2013-06-01 13:19:00"),
                    CreatedBy = users.Single(s=>s.Username=="@ymolina")
                }
            };

            tweets.ForEach(t => context.Tweets.AddOrUpdate(t));


        }
    }
}
