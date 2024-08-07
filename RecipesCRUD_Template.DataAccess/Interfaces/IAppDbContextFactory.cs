namespace RecipesCRUD_Template.DataAccess.Interfaces;

public interface IAppDbContextFactory
{
    /// <summary>
    /// Creates an IAppDbContext instance.
    /// </summary>
    /// <returns>A new instance of <see cref="IAppDbContext" />.</returns>
    public IAppDbContext CreateDbContext();
}