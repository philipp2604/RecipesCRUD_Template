using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace RecipesCRUD_Template.DataAccess.SQLite;

public class AppDbContextDesignTimeFactorySQLite : IDesignTimeDbContextFactory<AppDbContextSQLite>
{
    public AppDbContextSQLite CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<AppDbContextSQLite>();
        builder.UseSqlite();
        return new AppDbContextSQLite(builder.Options);
    }
}