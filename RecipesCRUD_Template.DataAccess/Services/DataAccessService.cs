using Microsoft.EntityFrameworkCore;
using RecipesCRUD_Template.Core.Models;
using RecipesCRUD_Template.DataAccess.Interfaces;

namespace RecipesCRUD_Template.DataAccess.Services;

/// <summary>
/// Data access service for interfacing <see cref="IAppDbContext"/>.
/// </summary>
/// <param name="factory">The <see cref="IAppDbContextFactory"/> for creating a new instance of <see cref="IAppDbContext"/>.</param>
public class DataAccessService(IAppDbContextFactory factory) : IDataAccessService
{
    private readonly IAppDbContext _appDbContext = factory.CreateDbContext();

    /// <inheritdoc/>
    public async Task Create<T>(T entity, bool saveChanges = true) where T : DbObject
    {
        if (GetById<T>(entity.Id).Result != null)
            return;

        await _appDbContext.Set<T>().AddAsync(entity);
        
        if(saveChanges)
            await _appDbContext.SaveChangesAsync();
    }

    /// <inheritdoc/>
    public async Task Update<T>(T entity, bool saveChanges = true) where T : DbObject
    {
        _appDbContext.Set<T>().Update(entity);

        if (saveChanges)
            await _appDbContext.SaveChangesAsync();
    }

    /// <inheritdoc/>
    public async Task Delete<T>(T entity, bool saveChanges = true) where T : DbObject
    {
        _appDbContext.Set<T>().Remove(entity);

        if (saveChanges)
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

    /// <inheritdoc/>
    public async Task SaveChanges()
    {
        await _appDbContext.SaveChangesAsync();
    }
}