

using Infrastructure.Factories;
using Infrastructure.Models;
using Infrastructure.Repositories;

namespace Infrastructure.Services;

public class ToolsService(ToolsRepository toolsRepository, ToolsItemRepository toolsItemRepository)
{
    private readonly ToolsRepository _toolsRepository = toolsRepository;
    private readonly ToolsItemRepository _toolsItemRepository = toolsItemRepository;
    public async Task<ResponseResult> GetAllFeaturesAsync()
    {
        try
        {
            var result = await _toolsRepository.GetAllAsync();
            return result;

        }

        catch (Exception ex)
        {
            return ResponseFactory.ERROR(ex.Message);
        }
    }
}

