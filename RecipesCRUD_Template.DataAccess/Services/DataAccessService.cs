using Microsoft.EntityFrameworkCore;
using RecipesCRUD_Template.Core.Models;
using RecipesCRUD_Template.DataAccess.Interfaces;

namespace RecipesCRUD_Template.DataAccess.Services;

public class DataAccessService(IAppDbContextFactory factory) : IDataAccessService
{
    private readonly IAppDbContext _appDbContext = factory.CreateDbContext();

    /// <inheritdoc/>
    public async Task Create<T>(T entity) where T : DbObject
    {
        if (GetById<T>(entity.Id).Result != null)
            return;

        await _appDbContext.Set<T>().AddAsync(entity);
        await _appDbContext.SaveChangesAsync();
    }

    /// <inheritdoc/>
    public async Task Update<T>(T entity) where T : DbObject
    {
        _appDbContext.Set<T>().Update(entity);
        await _appDbContext.SaveChangesAsync();
    }

    /// <inheritdoc/>
    public async Task Delete<T>(T entity) where T : DbObject
    {
        _appDbContext.Set<T>().Remove(entity);
        await _appDbContext.SaveChangesAsync();
    }

    /// <inheritdoc/>
    public async Task<ICollection<T>> GetAll<T>() where T : DbObject
    {
        return await _appDbContext.Set<T>().ToListAsync();
    }

    /// <inheritdoc/>
    public async Task<T?> GetById<T>(int id) where T : DbObject
    {
        return await _appDbContext.Set<T>().FindAsync(id);
    }
}