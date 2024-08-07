using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace RecipesCRUD_Template.DataAccess.SQLite;

/// <summary>
/// Factory class to create an instance of <see cref="AppDbContextSQLite"/> at design time.
/// </summary>
public class AppDbContextDesignTimeFactorySQLite : IDesignTimeDbContextFactory<AppDbContextSQLite>
{
    /// <summary>
    /// Creates an AppDbContextSQLite instance.
    /// </summary>
    /// <returns>A new instance of <see cref="AppDbContextSQLite" />.</returns>
    public AppDbContextSQLite CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<AppDbContextSQLite>();
        builder.UseSqlite();
        return new AppDbContextSQLite(builder.Options);
    }
}