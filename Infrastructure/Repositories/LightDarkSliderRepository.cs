using Infrastructure.Context;
using Infrastructure.Entities;


namespace Infrastructure.Repositories;

public class LightDarkSliderRepository(DataContext context) : Repo<LightDarkSliderEntity>(context)
{
    private readonly DataContext _context = context;

   


}
