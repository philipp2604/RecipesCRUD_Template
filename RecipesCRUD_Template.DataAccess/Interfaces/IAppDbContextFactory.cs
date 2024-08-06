namespace RecipesCRUD_Template.DataAccess.Interfaces;

public interface IAppDbContextFactory
{
    public IAppDbContext CreateDbContext();
}