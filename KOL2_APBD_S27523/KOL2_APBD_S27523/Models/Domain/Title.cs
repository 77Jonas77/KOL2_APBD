using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Titles")]
public class Title
{
    [Key] [Required] [Column("PK")] public int Pk { get; set; }

    [Required]
    [MaxLength(100)]
    [Column("nam", TypeName = "varchar(100)")]
    public string Name { get; set; }

    public IEnumerable<CharacterTitle> CharacterTitles { get; set; }
}