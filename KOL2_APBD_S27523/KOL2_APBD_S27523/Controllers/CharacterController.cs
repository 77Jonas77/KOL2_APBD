using KOL2_APBD_S27523.Exceptions;
using KOL2_APBD_S27523.Models.Requests;
using KOL2_APBD_S27523.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace KOL2_APBD_S27523.Controllers;

[Route("api/characters")]
[ApiController]
public class CharactersController(ICharacterService characterService) : ControllerBase
{
    [HttpGet("/{characterId:int}")]
    public async Task<IActionResult> GetCharacterByIdAsync(int characterId)
    {
        try
        {
            var response = await characterService.GetCharacterByIdAsync(characterId);
            return Ok(response);
        }
        catch (NotFoundException e)
        {
            return NotFound($"Character with id: " + characterId + "doesnt exists!");
        }
    }

    [HttpPost("/{characterId:int}/backpackslots")]
    public async Task<IActionResult> AddItemsToCharacterAsync(int characterId,
        AddItemsToCharacterByIdRequest itemsIds)
    {
        try
        {
            var res = await characterService.AddItemsToCharacterAsync(characterId, itemsIds);
            return Ok(res);
        }
        catch (BadRequestException e)
        {
            return BadRequest($"Smth wrong with your data :(");
        }
        catch (NotFoundException e)
        {
            return NotFound($"Smth wrong with your data :( not found");
        }
    }
}