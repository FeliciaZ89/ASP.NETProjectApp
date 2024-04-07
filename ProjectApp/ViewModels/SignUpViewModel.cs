using Infrastructure.Models;
using ProjectApp.Models;

namespace ProjectApp.ViewModels;

public class SignUpViewModel
{
    public string Title { get; set; } = "Sign Up";
    public SignUpModel Form { get; set; } = new SignUpModel();
    public string? ErrorMessage { get; set; }



}
