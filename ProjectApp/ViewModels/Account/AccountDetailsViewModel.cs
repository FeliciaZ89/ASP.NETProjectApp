using Infrastructure.Entities;
using ProjectApp.Models;
using ProjectApp.Models.Components;

namespace ProjectApp.ViewModels.Account;

public class AccountDetailsViewModel
{

    //public UserEntity User { get; set; } = null!;

    public BasicInfoFormViewModel? BasicInfoForm { get; set; } 
    public AddresInfoFormViewModel? AddressInfoForm { get; set; } 
    public ProfileInfoViewModel? ProfileInfo { get; set; }
}
