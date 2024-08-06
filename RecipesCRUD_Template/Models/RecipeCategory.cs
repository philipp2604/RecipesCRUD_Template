using System.ComponentModel.DataAnnotations.Schema;

namespace RecipesCRUD_Template.Core.Models;

public class RecipeCategory : NamedDbObject
{
    public RecipeCategory() : base()
    {
        SubCategories = [];
        Recipes = [];
    }

    private int? ParentId { get; set; }

    [ForeignKey(nameof(ParentId))]
    public RecipeCategory? Parent { get; set; }

    public ICollection<RecipeCategory> SubCategories { get; set; }
    public ICollection<Recipe> Recipes { get; set; }
}