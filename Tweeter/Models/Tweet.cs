using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tweeter.Models
{
    public class Tweet
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [StringLength(140)]
        public string Text { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; }

        public int UserId { get; set; }
        
        [ForeignKey("UserId")]
        public User CreatedBy { get; set; }

    }
    
}