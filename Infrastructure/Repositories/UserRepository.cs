﻿
using Infrastructure.Context;
using Infrastructure.Entities;
using Infrastructure.Factories;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace Infrastructure.Repositories;
public class UserRepository(DataContext context) : Repo<UserEntity>(context)
{
    private readonly DataContext _context = context;

    public override async Task<ResponseResult> GetAllAsync()
    {
        try
        {
            IEnumerable<UserEntity> result = await _context.Users
                .Include (x => x.Address)
                .ToListAsync();
            return ResponseFactory.OK(result);
        }

        catch (Exception ex)
        {
            return ResponseFactory.ERROR(ex.Message);

        }
    }

    public override async Task<ResponseResult> GetOneAsync(Expression<Func<UserEntity, bool>> predicate)
    {
        try
        {
            var result = await _context.Set<UserEntity>()
                .Include(x => x.Address)
                .FirstOrDefaultAsync(predicate);
            if (result == null)
                return ResponseFactory.NOTFOUND();

            return ResponseFactory.OK(result);
        }

        catch (Exception ex)
        {
            return ResponseFactory.ERROR(ex.Message);

        }

    }
}