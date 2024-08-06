using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipesCRUD_Template.Core.Models;

public class Material : NamedDbObject
{
    public Material() : base()
    {
    }

    [Required]
    public int CategoryId { get; set; }

    [ForeignKey(nameof(CategoryId)), Required]
    public MaterialCategory? Category { get; set; }
}