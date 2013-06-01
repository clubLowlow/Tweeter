using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Tweeter.Models
{
    public class Tweet
    {
        public int ID { get; set; }

        [StringLength(140)]
        public string Text { get; set; }

        public DateTime CreatedAt { get; set; }

        public int UserId { get; set; }

    }
    
}