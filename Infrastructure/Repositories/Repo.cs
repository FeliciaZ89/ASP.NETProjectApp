

using Infrastructure.Context;
using Infrastructure.Factories;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repositories;

public abstract class Repo<Tentity>(DataContext context) where Tentity:class
{
    private readonly DataContext _context = context;


    //CREATE
    public virtual async Task<ResponseResult> CreateOneAsync(Tentity entity)
    {
        try
        {
            _context.Set<Tentity>().Add(entity);
            await _context.SaveChangesAsync();
            return ResponseFactory.OK(entity); 
        }
        catch (Exception ex) 
        {
            return ResponseFactory.ERROR(ex.Message);
          
        }

    }

    //READ
    public virtual async Task<ResponseResult> GetAllAsync()
    {
        try
        {
            IEnumerable<Tentity> result = await _context.Set<Tentity>().ToListAsync();
            return ResponseFactory.OK(result);
        }

        catch (Exception ex)
        {
            return ResponseFactory.ERROR(ex.Message);

        }

    }
    //Get (one)
    public virtual async Task<ResponseResult> GetOneAsync(Expression<Func<Tentity, bool>> predicate)
    {
        try
        {
            var result = await _context.Set<Tentity>().FirstOrDefaultAsync(predicate);
            if (result == null)
                return ResponseFactory.NOTFOUND();

            return ResponseFactory.OK(result);
        }

        catch (Exception ex)
        {
            return ResponseFactory.ERROR(ex.Message);

        }

    }

    //public virtual async Task<ResponseResult> GetByIdAsync(int id)
    //{
    //    try
    //    {
    //        var result = await _context.Set<Tentity>().FindAsync(id);
    //        if (result == null)
    //            return ResponseFactory.NOTFOUND();

    //        return ResponseFactory.OK(result);
    //    }
    //    catch (Exception ex)
    //    {
    //        return ResponseFactory.ERROR(ex.Message);
    //    }
    //}


    //Update one
    public virtual async Task<ResponseResult> UpdateOneAsync(Expression<Func<Tentity, bool>> predicate, Tentity updatedEntity)
    {
        try
        {
            var result = await _context.Set<Tentity>().FirstOrDefaultAsync(predicate);
           
            if (result != null)
            {
                _context.Entry(result).CurrentValues.SetValues(updatedEntity);
                await _context.SaveChangesAsync();
                return ResponseFactory.OK(result);
            }
            return ResponseFactory.NOTFOUND();
           
        }

        catch (Exception ex)
        {
            return ResponseFactory.ERROR(ex.Message);

        }

    }

    //Delete
    public virtual async Task<ResponseResult> DeleteOneAsync(Expression<Func<Tentity, bool>> predicate)
    {
        try
        {
            var result = await _context.Set<Tentity>().FirstOrDefaultAsync(predicate);

            if (result != null)
            {
                _context.Set<Tentity>().Remove(result);
                await _context.SaveChangesAsync();
                return ResponseFactory.OK("Removed");
            }
            return ResponseFactory.NOTFOUND();

        }

        catch (Exception ex)
        {
            return ResponseFactory.ERROR(ex.Message);

        }

    }
    public virtual async Task<ResponseResult> AlreadyExistsAsync(Expression<Func<Tentity, bool>> predicate)
    {
        try
        {
            var result = await _context.Set<Tentity>().AnyAsync(predicate);

            if (result)
             return ResponseFactory.EXISTS();
            
            return ResponseFactory.NOTFOUND();

        }

        catch (Exception ex)
        {
            return ResponseFactory.ERROR(ex.Message);

        }

    }
}
