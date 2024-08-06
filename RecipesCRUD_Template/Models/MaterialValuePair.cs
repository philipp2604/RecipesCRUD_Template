using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipesCRUD_Template.Core.Models;

public class MaterialValuePair : DbObject
{
    public MaterialValuePair() : base()
    {
    }

    [Required]
    public int? RecipeId { get; set; }

    [ForeignKey(nameof(RecipeId)), Required]
    public Recipe? Recipe { get; set; }

    [Required]
    public int? MaterialId { get; set; }

    [ForeignKey(nameof(MaterialId)), Required]
    public Material? Material { get; set; }

    [Required]
    public double Value { get; set; }
}