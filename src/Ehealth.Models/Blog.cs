using System;
using System.ComponentModel.DataAnnotations;

namespace Ehealth.Models
{
    public class Blog
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string SubTitle { get; set; }

        public string Content { get; set; }

        public string ImageUrl { get; set; }

        public DateTime PublishOn { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public bool isDeleted { get; set; }
    }
}
