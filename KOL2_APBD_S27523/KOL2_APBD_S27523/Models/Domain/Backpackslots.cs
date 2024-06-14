using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KOL2_APBD_S27523.Models.Domain;

[Table("Backpack_Slots")]
public class BackpackSlot
{
    [Key] [Column("PK")] public int Id { get; set; }

    [Required]
    [Column("FK_item")]
    [ForeignKey(nameof(Item))]
    public int ItemId { get; set; }

    [Required]
    [Column("FK_character")]
    [ForeignKey(nameof(Character))]
    public int CharacterId { get; set; }

    public Item Item { get; set; }

    public Character Character { get; set; }
}