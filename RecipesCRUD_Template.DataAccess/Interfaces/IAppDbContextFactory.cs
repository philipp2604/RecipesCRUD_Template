namespace RecipesCRUD_Template.DataAccess.Interfaces;

public interface IAppDbContextFactory
{
    /// <summary>
    /// Creates db context.
    /// </summary>
    /// <returns>An IAppDbContext</returns>
    public IAppDbContext CreateDbContext();
}