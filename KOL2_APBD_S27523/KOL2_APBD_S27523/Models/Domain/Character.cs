using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KOL2_APBD_S27523.Models.Domain;

[Table("Characters")]
public class Character
{
    [Key] [Column("PK")] public int Pk { get; set; }

    [Required]
    [MaxLength(50)]
    [Column("first_name", TypeName = "varchar(50)")]
    public string FirstName { get; set; }

    [Required]
    [MaxLength(50)]
    [Column("last_name", TypeName = "varchar(50)")]
    public string LastName { get; set; }

    [Required] [Column("current_weig")] public int CurrentWeight { get; set; }

    [Required] [Column("max_weight")] public int MaxWeight { get; set; }

    [Required] [Column("money")] public int Money { get; set; }

    public ICollection<CharacterTitle> CharacterTitles { get; set; }

    public ICollection<BackpackSlot> BackpackSlots { get; set; }
}