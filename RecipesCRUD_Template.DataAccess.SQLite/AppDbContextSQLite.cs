using Microsoft.EntityFrameworkCore;
using RecipesCRUD_Template.Core.Models;
using RecipesCRUD_Template.DataAccess.Interfaces;

namespace RecipesCRUD_Template.DataAccess.SQLite;

public class AppDbContextSQLite(DbContextOptions<AppDbContextSQLite> options) : DbContext(options), IAppDbContext
{
    public DbSet<MaterialCategory> MaterialCategories { get; set; }
    public DbSet<Material> Materials { get; set; }
    public DbSet<MaterialValuePair> MaterialValues { get; set; }
    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<RecipeCategory> RecipeCategories { get; set; }

    public bool EnsureDbCreated()
    {
        return Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Material>().Navigation(m => m.Category).AutoInclude();
        modelBuilder.Entity<Recipe>().Navigation(r => r.Materials).AutoInclude();
        modelBuilder.Entity<Recipe>().Navigation(r => r.Category).AutoInclude();
    }
}