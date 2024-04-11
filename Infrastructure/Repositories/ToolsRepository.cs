using Infrastructure.Context;
using Infrastructure.Entities;
using Infrastructure.Factories;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Repositories;

public class ToolsRepository(DataContext context) : Repo<ToolsEntity>(context)
{
    private readonly DataContext _context = context;

    public override async Task<ResponseResult> GetAllAsync()
    {
        try
        {
            IEnumerable<ToolsEntity> result = await _context.Tool
                .Include(i => i.ToolItems)
                .ToListAsync();
            return ResponseFactory.OK(result);
        }

        catch (Exception ex)
        {
            return ResponseFactory.ERROR(ex.Message);
        }
    }
}
