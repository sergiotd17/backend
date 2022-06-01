using ApiRest.Context;
using Microsoft.EntityFrameworkCore;
using RicardoCarvalho.Sample.Package;

namespace ApiRest.Repository;

public abstract class MasterRepoImpl<TEntity, Context> : IMasterRepository<TEntity>
    where TEntity : class
    where Context : MyDbContext
{
    private MyDbContext _context;
    public MasterRepoImpl(MyDbContext context)
    {
        _context = context;
    }
    public async Task<TEntity> Add(TEntity model)
    {
        var result = _context.Set<TEntity>().Add(model);
        await _context.SaveChangesAsync();
        return result.Entity;
    }

    public async Task Delete(long id)
    {
        var result = await _context.Set<TEntity>().FindAsync(id);
        if (result != null)
        {
            _context.Set<TEntity>().Remove(result);
            await _context.SaveChangesAsync();
        } 

    }

    public async Task<List<TEntity>> GetAll()
    {
        return await _context.Set<TEntity>().ToListAsync();
    }

    public async Task<TEntity?> GetById(long id)
    {
        return await _context.Set<TEntity>().FindAsync(id);
    }

    public async Task<TEntity> Update(TEntity model)
    {
        var result = _context.Update(model);
        if (result != null)
        {
            await _context.SaveChangesAsync();
            return result.Entity;
        }
        return null;
        
    }
}