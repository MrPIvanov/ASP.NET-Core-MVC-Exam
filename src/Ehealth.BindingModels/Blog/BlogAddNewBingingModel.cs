using System.ComponentModel.DataAnnotations;

namespace Ehealth.BindingModels.Blog
{
    public class BlogAddNewBingingModel
    {
        [Required]
        public string Id { get; set; }

        [Required(ErrorMessage = "Enter title!")]
        [StringLength(50, ErrorMessage = "Blog title length must be between {2} and {1} characters.", MinimumLength = 3)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Enter subtitle!")]
        [StringLength(200, ErrorMessage = "Blog subtitle length must be between {2} and {1} characters.", MinimumLength = 20)]
        public string SubTitle { get; set; }

        [Required(ErrorMessage = "Enter content!")]
        [StringLength(3000, ErrorMessage = "Blog content length must be between {2} and {1} characters.", MinimumLength = 30)]
        public string Content { get; set; }

        [Required(ErrorMessage = "Enter imageURL!")]
        [StringLength(255, ErrorMessage = "Blog inageURL length must be between {2} and {1} characters.", MinimumLength = 5)]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "Enter author!")]
        [StringLength(50, ErrorMessage = "Blog author length must be between {2} and {1} characters.", MinimumLength = 3)]
        public string Author { get; set; }
    }
}
