using Infrastructure.Context;
using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories;


public class ToolsItemRepository(DataContext context) : Repo<ToolsItemEntity>(context)
{
    private readonly DataContext _context = context;
}
