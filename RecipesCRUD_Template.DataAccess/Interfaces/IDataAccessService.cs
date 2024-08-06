using RecipesCRUD_Template.Core.Models;

namespace RecipesCRUD_Template.DataAccess.Interfaces;

public interface IDataAccessService
{
    public Task Create<T>(T entity) where T : DbObject;

    public Task Update<T>(T entity) where T : DbObject;

    public Task Delete<T>(T entity) where T : DbObject;

    public Task<ICollection<T>> GetAll<T>() where T : DbObject;

    public Task<T?> GetById<T>(int id) where T : DbObject;
}