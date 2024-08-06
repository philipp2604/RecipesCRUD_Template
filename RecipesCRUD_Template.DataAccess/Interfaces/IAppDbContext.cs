using Microsoft.EntityFrameworkCore;
using RecipesCRUD_Template.Core.Models;

namespace RecipesCRUD_Template.DataAccess.Interfaces;

public interface IAppDbContext : IDisposable
{
    public DbSet<MaterialCategory> MaterialCategories { get; set; }
    public DbSet<Material> Materials { get; set; }
    public DbSet<MaterialValuePair> MaterialValues { get; set; }
    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<RecipeCategory> RecipeCategories { get; set; }

    public DbSet<T> Set<T>() where T : class;

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    public bool EnsureDbCreated();
}