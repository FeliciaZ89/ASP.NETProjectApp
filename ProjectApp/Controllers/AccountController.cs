using Infrastructure.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectApp.ViewModels.Account;

[Authorize]

public class AccountController(UserManager<UserEntity> userManager, AddressManager addressManager) : Controller
{

    private readonly UserManager<UserEntity> _userManager = userManager;
    private readonly AddressManager _addressManager=addressManager;

    #region Details
    [HttpGet]
    [Route("account/details")]

    public async Task<IActionResult> Details()
    {
        var viewModel = new AccountDetailsViewModel();

        viewModel.BasicInfoForm ??= await PopulateBasicInfoAsync();
        viewModel.AddressInfoForm ??= await PopulateAddressInfoAsync();
        viewModel.ProfileInfo = await PopulateProfileInfoAsync();

        return View(viewModel);
    }
    #endregion

    #region [HttpPost] Details
    [HttpPost]
    [Route("account/details")]

    public async Task<IActionResult> Details(AccountDetailsViewModel viewModel)
    {
        if (viewModel.BasicInfoForm != null)

        {
            if (viewModel.BasicInfoForm.FirstName != null && viewModel.BasicInfoForm.LastName != null && viewModel.BasicInfoForm.Email != null)

            {
                var user = await _userManager.GetUserAsync(User);
                if (user != null)
                {
                    user.FirstName = viewModel.BasicInfoForm.FirstName;
                    user.LastName = viewModel.BasicInfoForm.LastName;
                    user.Email = viewModel.BasicInfoForm.Email;
                    user.PhoneNumber = viewModel.BasicInfoForm.PhoneNumber;
                    user.Biography = viewModel.BasicInfoForm.Biography;

                    var result = await _userManager.UpdateAsync(user);

                    if (!result.Succeeded)
                    {
                        ModelState.AddModelError("Incorrect Values", "Something went wrong!Unable to save data!");
                        ViewData["ErrorMessage"] = "Something went wrong!Unable to update basic information!";
                    }
                }

            }
        }

        if (viewModel.AddressInfoForm != null)

        {
            if (viewModel.AddressInfoForm.AddressLine1 != null && viewModel.AddressInfoForm.PostalCode != null && viewModel.AddressInfoForm.City != null)

            {
                var user = await _userManager.GetUserAsync(User);

                if (user != null)
                {
                    var address = await _addressManager.GetAddressAsync(user.Id);

                    if (address != null)
                    {
                        address.AddressLine_1 = viewModel.AddressInfoForm.AddressLine1;
                        address.AddressLine_2 = viewModel.AddressInfoForm.AddressLine2;
                        address.PostalCode = viewModel.AddressInfoForm.PostalCode;
                        address.City = viewModel.AddressInfoForm.City;

                      var result=  await _addressManager.UpdateAddressAsync(address);
                        if (!result)
                        {
                            ModelState.AddModelError("IncorrectValues", "Something went wrong! Unable to save data!");
                            ViewData["ErrorMessage"] = "Unable to update address information";
                        }
                    }

                    else
                    {
                        address = new AddressEntity
                        {
                            UserId = user.Id,
                            AddressLine_1 = viewModel.AddressInfoForm.AddressLine1,
                            AddressLine_2 = viewModel.AddressInfoForm.AddressLine2,
                            PostalCode = viewModel.AddressInfoForm.PostalCode,
                            City = viewModel.AddressInfoForm.City,
                        };
                          var result = await _addressManager.CreateAddressAsync(address);
                        if (!result)


                        {
                            ModelState.AddModelError("IncorrectValues", "Something went wrong! Unable to save data!");
                            ViewData["ErrorMessage"] = "Unable to save address information";
                        }

                    }

                }

            }
        }

        viewModel.BasicInfoForm ??= await PopulateBasicInfoAsync();
        viewModel.AddressInfoForm ??= await PopulateAddressInfoAsync();
        viewModel.ProfileInfo = await PopulateProfileInfoAsync();

        return View(viewModel);
    }
    #endregion


    private async Task<BasicInfoFormViewModel> PopulateBasicInfoAsync()
    {
        var user = await _userManager.GetUserAsync(User);

        return new BasicInfoFormViewModel
        {
            UserId = user!.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email!,
            PhoneNumber = user.PhoneNumber,
            Biography = user.Biography

        };
    }
    private async Task<ProfileInfoViewModel> PopulateProfileInfoAsync()
    {
        var user = await _userManager.GetUserAsync(User);

        return new ProfileInfoViewModel
        {

            FirstName = user!.FirstName,
            LastName = user.LastName,
            Email = user.Email!,
            //ProfileImageUrl=user.ProfileImageUrl,

        };
    }

    private async Task<AddresInfoFormViewModel> PopulateAddressInfoAsync()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user != null)
        {
            var address = await _addressManager.GetAddressAsync(user.Id);
            if (address != null)
            {
                return new AddresInfoFormViewModel()
                {

                    AddressLine1 = address.AddressLine_1,
                    AddressLine2 = address.AddressLine_2,
                    PostalCode = address.PostalCode,
                    City = address.City,
                };
            }
        }

        return new AddresInfoFormViewModel();
    }

    [HttpPost]
    public async Task<IActionResult> ProfileImageUpload(IFormFile file)

    {
        var user = await _userManager.GetUserAsync(User);

        if (user != null && file != null && file.Length != 0)
        {
            var fileName = $"p_{user.Id}_{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

            using var fs = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(fs);
            

            user.ProfileImageUrl = fileName;
            await _userManager.UpdateAsync(user);

        }
        else
        {
            TempData["ErrorMessage"] = "Failed to upload profile image";
        }

        return RedirectToAction("Details", "Account");

    }

}

