using Microsoft.EntityFrameworkCore;
using RecipesCRUD_Template.DataAccess.Interfaces;

namespace RecipesCRUD_Template.DataAccess.SQLite;

public class AppDbContextFactorySQLite(string dbPath) : IAppDbContextFactory
{
    private readonly string _connectionString = "Data Source=" + dbPath;

    public IAppDbContext CreateDbContext()
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContextSQLite>();
        optionsBuilder.UseSqlite(_connectionString);
        return new AppDbContextSQLite(optionsBuilder.Options);
    }
}