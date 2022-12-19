using System.ComponentModel.DataAnnotations;

namespace PetShopApp.Models
{
    public class Category
    {
        [Key]
        [Required]
        public int CategoryId { get; set; }
        [Required(ErrorMessage ="Please enter a name")]
        [Display(Name ="Type: ")]
        public string? CategoryName { get; set; }
        public virtual ICollection<Animal>? Animals { get; set; }

    }
}
