using Microsoft.EntityFrameworkCore;
using RecipesCRUD_Template.Core.Models;

namespace RecipesCRUD_Template.DataAccess.Interfaces;

/// <summary>
/// The AppDbContext interface.
/// </summary>
public interface IAppDbContext : IDisposable
{
    /// <summary>
    /// Gets or sets the material categories.
    /// </summary>
    public DbSet<MaterialCategory> MaterialCategories { get; set; }

    /// <summary>
    /// Gets or sets the materials.
    /// </summary>
    public DbSet<Material> Materials { get; set; }

    /// <summary>
    /// Gets or sets the material value pairs.
    /// </summary>
    public DbSet<MaterialValuePair> MaterialValues { get; set; }

    /// <summary>
    /// Gets or sets the recipes.
    /// </summary>
    public DbSet<Recipe> Recipes { get; set; }

    /// <summary>
    /// Gets or sets the recipe categories.
    /// </summary>
    public DbSet<RecipeCategory> RecipeCategories { get; set; }

    /// <summary>
    /// Returns a <![CDATA[DbSet<T>]]> for Type <![CDATA[<T>]]>
    /// </summary>
    /// <typeparam name="T"/>
    /// <returns><![CDATA[DbSet<T>]]></returns>
    public DbSet<T> Set<T>() where T : class;

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
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Ensures asynchronously the database exists, if it doesn't exist, a new one is created and the schema applied.
    /// </summary>
    /// <param name="cancellationToken">A <see cref="CancellationToken" /> to observe while waiting for the task to complete.</param>
    /// <returns><see langword="true" /> if the database is created, <see langword="false" /> if it already existed.</returns>
    public Task<bool> EnsureDbCreatedAsync(CancellationToken cancellationToken = default);
}