using Microsoft.AspNetCore.Mvc.TagHelpers;
using PetShopApp.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetShopApp.Models
{
    public class Animal
    {
        [Display(Name ="ID: ")]
        [Required(ErrorMessage ="Please Enter An ID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AnimalId { get; set; }

        [Display(Name = "Name: ")]
        [Required(ErrorMessage ="Please enter a name")]
        public string? Name { get; set; }

        [Display(Name ="Age: ")]
        [Required(ErrorMessage = "Please enter a age")]
        [Range(1,150)]
        public int Age { get; set; }

        [Display(Name = "Description: ")]
        [Required(ErrorMessage = "Please enter a description")]
        [DataType(DataType.MultilineText)]
        [StringLength(500)]
        public string? Description { get; set; }

        [Display(Name = "image: ")]
        [ImageValid(new string[] { "png", "jpg", "jpeg", "webp", "raw", "svg" }, ErrorMessage = "This file extension is not allowed")]
        [Required(ErrorMessage = "Please enter a image")]
        public string? PictureName { get; set; }
        
        public virtual Category? Category { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Display(Name = "Comments: ")]
        public virtual ICollection<Comments>? Comments { get; set; }


    }
}
