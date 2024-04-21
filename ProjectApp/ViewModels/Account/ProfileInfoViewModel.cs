using System.ComponentModel.DataAnnotations;

namespace ProjectApp.ViewModels.Account;

public class ProfileInfoViewModel
{
    [Display(Name = "First Name", Prompt = "Enter your first name", Order = 0)]
    [Required(ErrorMessage = "First name is required")]
    [DataType(DataType.Text)]
    public string FirstName { get; set; } = null!;


    [Display(Name = "Last Name", Prompt = "Enter your last name", Order = 1)]
    [Required(ErrorMessage = "Last name is required")]
    [DataType(DataType.Text)]
    public string LastName { get; set; } = null!;


    [Display(Name = "Email address", Prompt = "Enter your email address", Order = 2)]
    [DataType(DataType.EmailAddress)]
    [Required(ErrorMessage = "Email address is required")]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Please enter a valid email address.")]
    public string Email { get; set; } = null!;
    public string ProfileImageUrl { get; set; } = "avatar.jpg";
}
