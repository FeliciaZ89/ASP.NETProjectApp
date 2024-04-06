
using Infrastructure.Helpers;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Models;

public class SignUpModel
{
    [DataType(DataType.Text)]
    [Display(Name = "First Name", Prompt = "Enter your first name", Order = 0)]
    [Required(ErrorMessage = "First name is required")]
    [MinLength(2, ErrorMessage = "Enter a first name")]
    public string FirstName { get; set; } = null!;

    [DataType(DataType.Text)]
    [Display(Name = "Last Name", Prompt = "Enter your last name", Order = 1)]
    [Required(ErrorMessage = "Last name is required")]
    [MinLength(2, ErrorMessage = "Enter a last name")]
    public string LastName { get; set; } = null!;

    [DataType(DataType.EmailAddress)]
    [Display(Name = "Email address", Prompt = "Enter your email address", Order = 2)]
    [Required(ErrorMessage = "Email address is required")]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Please enter a valid email address.")]
    public string Email { get; set; } = null!;

    [Display(Name = "Password", Prompt = "Enter your password", Order = 3)]
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Password is required")]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$", ErrorMessage = "Enter a valid password")]
    public string Password { get; set; } = null!;


    [DataType(DataType.Password)]
    [Display(Name = "Confirm password", Prompt = "Confirm your password", Order = 4)]
    [Required(ErrorMessage = "Password must be confirmed")]
    [Compare(nameof(Password), ErrorMessage = "Fields don't match")]
    public string ConfirmPassword { get; set; } = null!;


    [Display(Name = "I agree to the Terms & Conditions.", Order = 5)]
    [Required(ErrorMessage = "You have to accept our terms and conditions")]
    [CheckBoxRequired(ErrorMessage = "You must accept the terms and conditions to proceed")]
    public bool TermsAndConditions { get; set; } = false;
}
