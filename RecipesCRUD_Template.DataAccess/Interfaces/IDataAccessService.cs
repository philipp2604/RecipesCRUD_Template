using RecipesCRUD_Template.Core.Models;

namespace RecipesCRUD_Template.DataAccess.Interfaces;

public interface IDataAccessService
{
    /// <summary>
    /// Stores the entity of type <typeparamref name="T" /> inside the according <see cref="DbSet{T}" /> of the IAppDbContext.
    /// </summary>
    /// <param name="entity">An instance of <typeparamref name="T" /> to store inside the <see cref="DbSet{T}" /></param>
    /// <typeparam name="T">The type of entity to store.</typeparam>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public Task Create<T>(T entity) where T : DbObject;

    /// <summary>
    /// Updates the entity of type <typeparamref name="T" /> inside the according <see cref="DbSet{T}" /> of the IAppDbContext.<br/>Afterwards, the context is saved asynchronously to the database.
    /// </summary>
    /// <param name="entity">An instance of <typeparamref name="T" /> to update inside the <see cref="DbSet{T}" /></param>
    /// <typeparam name="T">The type of entity to update.</typeparam>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public Task Update<T>(T entity) where T : DbObject;

    /// <summary>
    /// Deletes the entity of type <typeparamref name="T" /> from the according <see cref="DbSet{T}" /> of the IAppDbContext.<br/>Afterwards, the context is saved asynchronously to the database.
    /// </summary>
    /// <param name="entity">An instance of <typeparamref name="T" /> to delete from the <see cref="DbSet{T}" /></param>
    /// <typeparam name="T">The type of entity to delete.</typeparam>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public Task Delete<T>(T entity) where T : DbObject;

    /// <summary>
    /// Returns all instances of type <typeparamref name="T" /> from the according <see cref="DbSet{T}" />.
    /// </summary>
    /// <typeparam name="T">The type of entity to return.</typeparam>
    /// <returns>A task that represents the asynchronous operation. The task result contains an <see cref="ICollection{T}" /> containing all entities from the <see cref="DbSet{T}" /></returns>
    public Task<ICollection<T>> GetAll<T>() where T : DbObject;

    /// <summary>
    /// Returns a single instances of type <typeparamref name="T" /> from the according <see cref="DbSet{T}" /> which contains the requested Id.
    /// </summary>
    /// <typeparam name="T">The type of entity to return.</typeparam>
    /// <returns>A task that represents the asynchronous operation.<br/>
    /// The task result either contains an instance of <see cref="{T?}" /> with the requested Id, or null if no match has been found. /></returns>
    public Task<T?> GetById<T>(int id) where T : DbObject;
}