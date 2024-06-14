using KOL2_APBD_S27523.Context;
using KOL2_APBD_S27523.Exceptions;
using KOL2_APBD_S27523.Models.Domain;
using KOL2_APBD_S27523.Models.Requests;
using KOL2_APBD_S27523.Models.Responses;
using KOL2_APBD_S27523.Services.Abstractions;
using Microsoft.EntityFrameworkCore;


public class CharacterService : ICharacterService
{
    private readonly DatabaseContext _databaseContext;

    public CharacterService(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public async Task<GetCharacterByIdResponse?> GetCharacterByIdAsync(int characterId)
    {
        var response = await _databaseContext.Characters.Where(e => e.Pk == characterId).Select(e =>
            new GetCharacterByIdResponse
            {
                FirstName = e.FirstName,
                LastName = e.LastName,
                CurrentWeight = e.CurrentWeight,
                MaxWeight = e.MaxWeight,
                Money = e.Money,
                BackpackSlots = e.BackpackSlots.Select(b => new BackpackRes
                {
                    SlotId = b.Id,
                    ItemName = b.Item.Name,
                    ItemWeight = b.Item.Weight,
                }).ToList(),
                Titles = e.CharacterTitles.Select(c => new TitleRes
                {
                    Title = c.Title.Name,
                    AcquiredAt = c.AcquiredAt
                }).ToList()
            }).FirstOrDefaultAsync();

        if (response is null)
        {
            throw new NotFoundException("not found ");
        }

        return response;
    }

    public async Task<IEnumerable<AddItemsToCharacterByIdResponse>> AddItemsToCharacterAsync(int characterId,
        AddItemsToCharacterByIdRequest itemsIds)
    {
        //spr character
        var character = await _databaseContext.Characters.Where(e => e.Pk == characterId).FirstOrDefaultAsync();
        if (character is null)
        {
            throw new NotFoundException("character doesnt exist! id:  " + characterId);
        }

        //spr przedmiotow w bazie
        List<Item> itemsToAdd = new List<Item>();
        foreach (var itemId in itemsIds.Items)
        {
            var item = await _databaseContext.Items.Where(e => e.Pk == itemId).FirstOrDefaultAsync();
            if (item is null)
            {
                throw new NotFoundException("Item with id: " + itemId + " doesnt exist!");
            }

            itemsToAdd.Add(item);
        }

        //spr udzwigu
        int maxUdzwig = character.MaxWeight;
        int udzwig = character.CurrentWeight;
        int dodawanyUdzwig = itemsToAdd.Sum(item => item.Weight);
        int potencjalnaWaga = dodawanyUdzwig + udzwig;

        if (potencjalnaWaga > maxUdzwig)
        {
            throw new BadRequestException("Too much weight for character!");
        }

        //dodanie itemow
        ICollection<BackpackSlot> itemsDataToReturn = new List<BackpackSlot>();
        foreach (var item in itemsToAdd)
        {
            var itemToAdd = new BackpackSlot
            {
                CharacterId = characterId,
                ItemId = item.Pk,
            };

            await _databaseContext.BackpackSlots.AddAsync(itemToAdd);
            itemsDataToReturn.Add(itemToAdd);
            character.CurrentWeight += item.Weight;
        }

        //update
        await _databaseContext.SaveChangesAsync();

        //response
        ICollection<AddItemsToCharacterByIdResponse> response = new List<AddItemsToCharacterByIdResponse>();
        foreach (var item in itemsDataToReturn)
        {
            response.Add(new AddItemsToCharacterByIdResponse()
            {
                SlodId = item.Id,
                ItemId = item.ItemId,
                CharacterId = item.CharacterId
            });
        }
        return response;
    }
}