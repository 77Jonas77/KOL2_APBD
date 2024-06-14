using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KOL2_APBD_S27523.Models.Domain;

[Table("Items")]
public class Item
{
    [Key] [Column("PK")] public int Pk { get; set; }

    [Required]
    [MaxLength(50)]
    [Column("name", TypeName = "varchar(50)")]
    public string Name { get; set; }

    [Required] [Column("weig")] public int Weight { get; set; }

    public ICollection<BackpackSlot> BackpackSlots { get; set; }
}