using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Heroes.App.Databases.Entities;

public class HeroEntity
{
    [Key]
    [Column]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
 
    [Required]
    [Column]
    public string Name { get; set; }
}