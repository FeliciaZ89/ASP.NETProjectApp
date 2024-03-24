using ProjectApp.Models.Components;
using System.ComponentModel.DataAnnotations;

namespace ProjectApp.Models;

public class AccountDetailsAddressInfoModel
{
    public LinkViewModel Link { get; set; } = new LinkViewModel();

    [Display(Name = "Addres line 1", Prompt = "Enter your addresline", Order = 0)]
    [Required(ErrorMessage = "Address is required")]
    public string AddressLine1 { get; set; } = null!;


    [Display(Name = "Addres line 2", Prompt = "Enter your second address line", Order = 1)]
  
    public string? AddresLine2 { get; set; }


    [Display(Name = "Postal code", Prompt = "Enter your postal code", Order = 2)]
    [DataType(DataType.PostalCode)]
    [Required(ErrorMessage = "Postal code is required")]
    public string PostalCode { get; set; } = null!;


    [Display(Name = "City", Prompt = "Enter your city", Order = 3)]
    [Required(ErrorMessage = "City is required")]
    public string City{ get; set; } = null!;
}
