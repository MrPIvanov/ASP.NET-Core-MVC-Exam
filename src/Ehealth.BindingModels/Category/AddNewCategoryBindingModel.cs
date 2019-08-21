using System.ComponentModel.DataAnnotations;

namespace Ehealth.BindingModels.Category
{
    public class AddNewCategoryBindingModel
    {
        [Required(ErrorMessage = "Enter category name!")]
        [StringLength(50, ErrorMessage = "Category name length must be between {2} and {1} characters.", MinimumLength = 3)]
        public string Name { get; set; }
    }
}
