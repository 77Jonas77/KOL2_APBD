namespace KOL2_APBD_S27523.Models.Responses;

public record GetCharacterByIdResponse
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int CurrentWeight { get; set; }
    public int MaxWeight { get; set; }
    public int Money { get; set; }
    public IEnumerable<BackpackRes> BackpackSlots { get; set; }
    public IEnumerable<TitleRes> Titles { get; set; }
}

public record TitleRes
{
    public string Title { get; set; }
    public DateTime AcquiredAt { get; set; }
}

public record BackpackRes
{
    public int SlotId { get; set; }
    public string ItemName { get; set; }
    public int ItemWeight { get; set; }
}