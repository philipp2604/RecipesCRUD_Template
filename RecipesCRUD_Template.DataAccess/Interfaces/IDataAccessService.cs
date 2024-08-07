using RecipesCRUD_Template.Core.Models;

namespace RecipesCRUD_Template.DataAccess.Interfaces;

public interface IDataAccessService
{
    /// <summary>
    /// Stores the entity of type <typeparamref name="T" /> inside the according <see cref="DbSet{T}" /> of the IAppDbContext.
    /// </summary>
    /// <param name="entity">An instance of <typeparamref name="T" /> to store inside the <see cref="DbSet{T}" /></param>
    /// <param name="saveChanges">Specifies whether changes shall be saved to the database. /></param>
    /// <param name="cancellationToken">A <see cref="CancellationToken" /> to observe while waiting for the task to complete.</param>
    /// <typeparam name="T">The type of entity to store.</typeparam>
    /// <returns>A task that represents the asynchronous operation.</returns>
    /// <exception cref="OperationCanceledException">If the <see cref="CancellationToken" /> is canceled.</exception>
    public Task Create<T>(T entity, bool saveChanges = true, CancellationToken cancellationToken = default) where T : DbObject;

    /// <summary>
    /// Updates the entity of type <typeparamref name="T" /> inside the according <see cref="DbSet{T}" /> of the IAppDbContext.<br/>Afterwards, the context is saved asynchronously to the database.
    /// </summary>
    /// <param name="entity">An instance of <typeparamref name="T" /> to update inside the <see cref="DbSet{T}" /></param>
    /// <param name="saveChanges">Specifies whether changes shall be saved to the database. /></param>
    /// <param name="cancellationToken">A <see cref="CancellationToken" /> to observe while waiting for the task to complete.</param>
    /// <typeparam name="T">The type of entity to update.</typeparam>
    /// <returns>A task that represents the asynchronous operation.</returns>
    /// <exception cref="OperationCanceledException">If the <see cref="CancellationToken" /> is canceled.</exception>
    public Task Update<T>(T entity, bool saveChanges = true, CancellationToken cancellationToken = default) where T : DbObject;

    /// <summary>
    /// Deletes the entity of type <typeparamref name="T" /> from the according <see cref="DbSet{T}" /> of the IAppDbContext.<br/>Afterwards, the context is saved asynchronously to the database.
    /// </summary>
    /// <param name="entity">An instance of <typeparamref name="T" /> to delete from the <see cref="DbSet{T}" /></param>
    /// <param name="saveChanges">Specifies whether changes shall be saved to the database. /></param>
    /// <param name="cancellationToken">A <see cref="CancellationToken" /> to observe while waiting for the task to complete.</param>
    /// <typeparam name="T">The type of entity to delete.</typeparam>
    /// <returns>A task that represents the asynchronous operation.</returns>
    /// <exception cref="OperationCanceledException">If the <see cref="CancellationToken" /> is canceled.</exception>
    public Task Delete<T>(T entity, bool saveChanges = true, CancellationToken cancellationToken = default) where T : DbObject;

    /// <summary>
    /// Returns all instances of type <typeparamref name="T" /> from the according <see cref="DbSet{T}" />.
    /// </summary>
    /// <param name="cancellationToken">A <see cref="CancellationToken" /> to observe while waiting for the task to complete.</param>
    /// <typeparam name="T">The type of entity to return.</typeparam>
    /// <returns>A task that represents the asynchronous operation. The task result contains an <see cref="ICollection{T}" /> containing all entities from the <see cref="DbSet{T}" /></returns>
    /// <exception cref="ArgumentNullException"><paramref name="source" /> is <see langword="null" />.</exception>
    /// <exception cref="OperationCanceledException">If the <see cref="CancellationToken" /> is canceled.</exception>
    public Task<ICollection<T>> GetAll<T>(CancellationToken cancellationToken = default) where T : DbObject;

    /// <summary>
    /// Returns a single instances of type <typeparamref name="T" /> from the according <see cref="DbSet{T}" /> which contains the requested Id.
    /// </summary>
    /// <param name="cancellationToken">A <see cref="CancellationToken" /> to observe while waiting for the task to complete.</param>
    /// <typeparam name="T">The type of entity to return.</typeparam>
    /// <exception cref="OperationCanceledException">If the <see cref="CancellationToken" /> is canceled.</exception>
    /// <returns>A task that represents the asynchronous operation.<br/>
    /// The task result either contains an instance of <see cref="{T?}" /> with the requested Id, or null if no match has been found. /></returns>
    public Task<T?> GetById<T>(int id, CancellationToken cancellationToken = default) where T : DbObject;

    /// <summary>
    /// Saves all changes inside the context asynchronously to the database.
    /// </summary>
    /// <param name="cancellationToken">A <see cref="CancellationToken" /> to observe while waiting for the task to complete.</param>
    /// <returns>
    ///     A task that represents the asynchronous save operation. The task result contains the
    ///     number of state entries written to the database.
    /// </returns>
    /// <exception cref="DbUpdateException">
    ///     An error is encountered while saving to the database.
    /// </exception>
    /// <exception cref="DbUpdateConcurrencyException">
    ///     A concurrency violation is encountered while saving to the database.
    ///     A concurrency violation occurs when an unexpected number of rows are affected during save.
    ///     This is usually because the data in the database has been modified since it was loaded into memory.
    /// </exception>
    /// <exception cref="OperationCanceledException">If the <see cref="CancellationToken" /> is canceled.</exception>
    public Task SaveChanges(CancellationToken cancellationToken = default);
}