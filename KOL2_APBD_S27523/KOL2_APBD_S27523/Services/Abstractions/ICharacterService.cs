using KOL2_APBD_S27523.Models.Requests;
using KOL2_APBD_S27523.Models.Responses;

namespace KOL2_APBD_S27523.Services.Abstractions;

public interface ICharacterService
{
    Task<GetCharacterByIdResponse?> GetCharacterByIdAsync(int characterId);

    Task<IEnumerable<AddItemsToCharacterByIdResponse>> AddItemsToCharacterAsync(int characterId,
        AddItemsToCharacterByIdRequest itemsIds);
}