using System.ComponentModel.DataAnnotations;

namespace PetShopApp.Models
{
    public class Login
    {
        [Display(Name = "UserName: ")]
        [Required(ErrorMessage = "Please Enter a valid username")]
        public string? Name { get; set; }

        [Display(Name = "Password: ")]
        [Required(ErrorMessage = "Please Enter a valid password")]
        public string? Password { get; set; }
    }
}
