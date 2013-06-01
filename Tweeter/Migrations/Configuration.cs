namespace Tweeter.Migrations
{
    using System;
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
            context.Tweets.AddOrUpdate(i => i.Text,
                new Tweet
                {
                    Text = "poignant",
                    CreatedAt = DateTime.Parse("2013-06-01 13:19:00"),
                    UserId = 21
                }
            );

            context.Users.AddOrUpdate(u => u.Username,
                new User
                {
                    Username = "@ymolina",
                    Password = "ymolina",
                    Avatar = "",
                    About = "The greatest catcher in the world",
                    Name = "Yadier Molina",
                    Website = "www.yadi.com"
                }
            );
        }
    }
}
