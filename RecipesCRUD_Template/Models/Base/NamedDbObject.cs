using System.ComponentModel.DataAnnotations;

namespace RecipesCRUD_Template.Core.Models;

public class NamedDbObject : DbObject
{
    public NamedDbObject() : base()
    {
        Name = string.Empty;
    }

    [Required]
    public string Name { get; set; }
}