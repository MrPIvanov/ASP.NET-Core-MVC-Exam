using System;

namespace Ehealth.ViewModels.Blog
{
    public class BlogSingleViewModel
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string SubTitle { get; set; }

        public string Content { get; set; }

        public string ImageUrl { get; set; }

        public DateTime PublishOn { get; set; }

        public string Author { get; set; }
    }
}
