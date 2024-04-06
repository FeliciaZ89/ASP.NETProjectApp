
using Infrastructure.Entities;
using Infrastructure.Factories;
using Infrastructure.Helpers;
using Infrastructure.Models;
using Infrastructure.Repositories;

namespace Infrastructure.Services;

public class UserService(UserRepository repository, AddressService addressService)
{
    private readonly UserRepository _repository = repository;
    private readonly AddressService _addressService = addressService;

    public async Task<ResponseResult> CreateUserAsync(SignUpModel model)
    {
        try
        {
            var exists = await _repository.AlreadyExistsAsync(x => x.Email ==model.Email);
            if (exists.StatusCode == StatusCodes.EXISTS)
                return exists;
            
            var result = await _repository.CreateOneAsync(UserFactory.Create(model)); 
            if(result.StatusCode != StatusCodes.OK)
                return result;

            return ResponseFactory.OK("User succesfully created!");
        }
        catch (Exception ex)
        {
            return ResponseFactory.ERROR(ex.Message);
        }
    }


    public async Task<ResponseResult> SignInUserAsync(SignInModel model)
    {
        try
        {
            var result = await _repository.GetOneAsync(x => x.Email == model.Email);
            if (result.StatusCode == StatusCodes.OK && result.ContentResult != null)
            {
                var userEntity = (UserEntity) result.ContentResult;
                if (PasswordHasher.ValidateSecurePassword(model.Password, userEntity.Password, userEntity.SecurityKey))
                    return ResponseFactory.OK();
            }

            return ResponseFactory.ERROR("Incorrect email or password.");

        }
        catch (Exception ex)
        {
            return ResponseFactory.ERROR(ex.Message);
        }
    }
}
