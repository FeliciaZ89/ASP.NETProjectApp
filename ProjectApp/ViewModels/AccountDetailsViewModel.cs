using Infrastructure.Entities;
using ProjectApp.Models;
using ProjectApp.Models.Components;

namespace ProjectApp.ViewModels;

public class AccountDetailsViewModel
{

    public UserEntity User { get; set; } = null!;
    //public AccountDetailsBasicInfoModel BasicInfo { get; set; } = new AccountDetailsBasicInfoModel();
    //{
    //    FirstName="Felicia",
    //    LastName= "Zidaru",
    //    Email="fely@domain.com",
    //    Phone="0745123456",
    //    ProfileImage = new() { ImageUrl = "images/gmail.svg", AltText = "Profile image" },
    //    Link = new() { ControllerName = "Account", ActionName = "Details", Text = "Account details" },
    //    SignOutLink = new() { ControllerName="Auth", ActionName="SignOut", Text="Sign out"}


    //};
    //public AccountDetailsAddressInfoModel AddressInfo { get; set; } = new AccountDetailsAddressInfoModel();

   
}
