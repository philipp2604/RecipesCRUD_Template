using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipesCRUD_Template.Core.Models;

public class Recipe : NamedDbObject
{
    public Recipe() : base()
    {
        Materials = [];
    }

    [Required]
    public int CategoryId { get; set; }

    [ForeignKey(nameof(CategoryId)), Required]
    public RecipeCategory? Category { get; set; }

    public ICollection<MaterialValuePair> Materials { get; set; }
}