using Carta.Models;

namespace Carta.Extensions;

public static class GameExtensions
{
    static readonly Random Random = new();

    public static Game CreateGame(Config config)
    {
        var game = new Game()
        {
            Config = config
        };
        var allCards = CardConstants.AllCards().OrderBy(x => Guid.NewGuid()).ToList();
        var filteredCards = allCards
            .RemoveDisAllowedCards(config)
            .Take(config.TotalItems)
            .EnsurePromisedCards(config);
        game.Cards = filteredCards.OrderBy(x => Guid.NewGuid()).ToList();

        return game;
    }

    public static IEnumerable<Card> RemoveDisAllowedCards(this IEnumerable<Card> cards, Config config)
        => cards.Except(config.DisAllowedCards);

    public static IEnumerable<Card> EnsurePromisedCards(this IEnumerable<Card> cards, Config config)
    {
        foreach (var card in config.PromisedCards)
        {
            if (!cards.Any(x => card == x))
            {
                cards = cards.Append(card);
            }
        }

        var c = cards.ToList();

        var toRemove = c[Random.Next(cards.Count() -1 )];
        while (c.Count > config.TotalItems)
        {
            if(config.PromisedCards.Any(x => x == toRemove)){
                toRemove = c[Random.Next(cards.Count())];
            } else {
                var index = c.FindIndex(y => y == toRemove);
                c.RemoveAt(index);
                toRemove = c[Random.Next(cards.Count() -1 )];
            }
        }

        return c;
    }
}