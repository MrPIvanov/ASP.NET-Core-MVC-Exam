using System;
using System.ComponentModel.DataAnnotations;

namespace Ehealth.BindingModels.Blog
{
    public class BlogAddNewBingingModel
    {
        public string Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string SubTitle { get; set; }

        public string Content { get; set; }

        public string ImageUrl { get; set; }

        [Required]
        public string Author { get; set; }
    }
}
