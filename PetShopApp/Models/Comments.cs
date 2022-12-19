using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetShopApp.Models
{
    public class Comments
    {
        [Key]
        [Required]
        public int CommentsId { get; set; }
        [ForeignKey("AnimalId")]
        public virtual Animal? Animal { get; set; }
        [Required]
        public int AnimalId { get; set; }
        [Display(Name = "comment")]
        [Required(ErrorMessage = "please write a valid comment")]
        [DataType(DataType.MultilineText)]
        [StringLength(100)]
        public string? comment { get; set; }
    }
}
