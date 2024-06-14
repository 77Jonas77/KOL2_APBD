namespace KOL2_APBD_S27523.Models.Requests;

public record AddItemsToCharacterByIdRequest
{
    public IEnumerable<int> Items { get; set; }
}