

using Infrastructure.Entities;
using Infrastructure.Factories;
using Infrastructure.Models;
using Infrastructure.Repositories;

namespace Infrastructure.Services;

public class LightDarkSliderService (LightDarkSliderRepository lightDarkSliderRepository)
{

    private readonly LightDarkSliderRepository _lightDarkSliderRepository = lightDarkSliderRepository;

    public async Task<ResponseResult> GetAllSliderAsync()
    {
        try
        {
            var result = await _lightDarkSliderRepository.GetAllAsync();
            return result;
        }
        catch (Exception ex) { return ResponseFactory.ERROR(ex.Message); }
    }


}

