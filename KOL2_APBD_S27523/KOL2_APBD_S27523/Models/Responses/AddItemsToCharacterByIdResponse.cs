namespace KOL2_APBD_S27523.Models.Responses;

public record AddItemsToCharacterByIdResponse
{
    public int SlodId { get; set; }
    public int ItemId { get; set; }
    public int CharacterId { get; set; }
}