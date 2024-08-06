using System.ComponentModel.DataAnnotations.Schema;

namespace RecipesCRUD_Template.Core.Models;

public class MaterialCategory : NamedDbObject
{
    public MaterialCategory() : base()
    {
        SubCategories = [];
        Materials = [];
    }

    public int? ParentId { get; set; }

    [ForeignKey(nameof(ParentId))]
    public MaterialCategory? Parent { get; set; }

    public ICollection<MaterialCategory> SubCategories { get; set; }

    public ICollection<Material> Materials { get; set; }
}