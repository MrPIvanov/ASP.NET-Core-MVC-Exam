using System;
using System.ComponentModel.DataAnnotations;

namespace Ehealth.Models
{
    public class Message
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public string Text { get; set; }

        public DateTime SendOn { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }
    }
}
