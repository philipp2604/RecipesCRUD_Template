using Microsoft.EntityFrameworkCore;
using RecipesCRUD_Template.Core.Models;
using RecipesCRUD_Template.DataAccess.Interfaces;

namespace RecipesCRUD_Template.DataAccess.SQLite;

/// <summary>
/// Implementation of <see cref="IAppDbContext"/> and <see cref="DbContext"/>
/// </summary>
/// <param name="options">Options to be used.</param>
public class AppDbContextSQLite(DbContextOptions<AppDbContextSQLite> options) : DbContext(options), IAppDbContext
{
    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public DbSet<MaterialCategory> MaterialCategories { get; set; }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public DbSet<Material> Materials { get; set; }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public DbSet<MaterialValuePair> MaterialValues { get; set; }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public DbSet<Recipe> Recipes { get; set; }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public DbSet<RecipeCategory> RecipeCategories { get; set; }

    /// <inheritdoc/>
    public async Task<bool> EnsureDbCreated(CancellationToken cancellationToken = default)
    {
        return await Database.EnsureCreatedAsync(cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<bool> EnsureDbDeleted(CancellationToken cancellationToken = default)
    {
        return await Database.EnsureDeletedAsync(cancellationToken);
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Material>().Navigation(m => m.Category).AutoInclude();
        modelBuilder.Entity<Recipe>().Navigation(r => r.Materials).AutoInclude();
        modelBuilder.Entity<Recipe>().Navigation(r => r.Category).AutoInclude();
    }
}