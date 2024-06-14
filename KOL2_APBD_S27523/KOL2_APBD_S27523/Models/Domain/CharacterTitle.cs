using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

[Table("Character_Titles")]
[PrimaryKey(nameof(CharacterId), nameof(TitleId))]
public class CharacterTitle
{
    [Required]
    [ForeignKey(nameof(Character))]
    [Column("FK_charact", Order = 1)]
    public int CharacterId { get; set; }

    public Character Character { get; set; }

    [Required]
    [ForeignKey(nameof(Title))]
    [Column("FK_title", Order = 2)]
    public int TitleId { get; set; }

    public Title Title { get; set; }

    [Required]
    [Column("aquire_at", TypeName = "datetime")]
    public DateTime AcquiredAt { get; set; }
}