namespace Tweeter.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.Security;
    using Tweeter.Models;
    using WebMatrix.WebData;

    internal sealed class Configuration : DbMigrationsConfiguration<Tweeter.Models.TweeterDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Tweeter.Models.TweeterDBContext context)
        {
            WebSecurity.InitializeDatabaseConnection("TweeterDBContext", "Users", "ID", "Username", autoCreateTables: true);

            var db = new TweeterDBContext();

            if (!Roles.RoleExists("Administrator"))
                Roles.CreateRole("Administrator");

            if (!WebSecurity.UserExists("@ymolina"))
                WebSecurity.CreateUserAndAccount(
                    "@ymolina",
                    "ymolina",
                    new
                    {
                        Avatar = "",
                        About = "The greatest catcher in the world",
                        Name = "Yadier Molina",
                        Website = "www.yadi.com"
                    });

            if (!WebSecurity.UserExists("@awainwright"))
                WebSecurity.CreateUserAndAccount(
                    "@awainwright",
                    "awainwright",
                    new
                    {
                        Avatar = "",
                        About = "The staff ace",
                        Name = "Adam Wainwright",
                        Website = "www.waino.com"
                    });

            var tweets = new List<Tweet>{
                new Tweet
                {
                    Text = "poignant",
                    CreatedAt = DateTime.Parse("2013-06-01 13:19:00"),
                    UserId = db.Users.First(u => u.Username.Equals("@ymolina")).ID
                
                },
                new Tweet
                {
                    Text = "waino tweet",
                    CreatedAt = DateTime.Parse("2013-06-01 13:19:00"),
                    UserId = db.Users.First(u => u.Username.Equals("@awainwright")).ID
                
                }
            };

            tweets.ForEach(t => context.Tweets.AddOrUpdate(t));


        }
    }
}
