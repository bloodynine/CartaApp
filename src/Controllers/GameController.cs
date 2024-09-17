using Carta.Extensions;
using Carta.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Entities;

namespace Carta.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GameController : ControllerBase
{
    [HttpPost]
    public async Task<NewGame> Post([FromBody] Config config)
    {
        var game = GameExtensions.CreateGame(config);
        await DB.SaveAsync(game);
        return new(game.ID);
    }

    [HttpGet("{id}")]
    public async Task<GameDto> Get(string id)
    {
        var game = await DB.Find<Game>().OneAsync(id);
        return new(game!);
    }

    [HttpPut("{gameId}/card/{cardId}")]
    public async Task<Card> Put(string gameId, Guid cardId)
    {
        var game = await DB.Find<Game>().OneAsync(gameId);
        var index = game!.Cards.FindIndex(x => x.Id == cardId);
        game.Cards[index].IsFlipped = true;
        await DB.SaveAsync(game);
        return game.Cards[index];
    }
}