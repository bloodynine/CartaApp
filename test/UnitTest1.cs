using Carta;
using Carta.Extensions;
using Carta.Models;
using FluentAssertions;

namespace test;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void ShouldDisallowCards()
    {
        var cards = new List<Card>()
        {
            new Card("a", Suit.Clubs),
            new Card("a", Suit.Spades)
        };
        var config = new Config()
        {
            Rows = 1,
            Columns = 3,
            DisAllowedCards = new[]
            {
                new Card("a", Suit.Clubs)
            }
        };

        var results = cards.RemoveDisAllowedCards(config);
        results.All(x => x != new Card("a", Suit.Clubs)).Should().BeTrue();
        results.Count().Should().Be(1);
    }

    [Test]
    public void ShouldPromiseCardsWhenItExistsAlready()
    {
        var cards = new List<Card>()
        {
            new Card("a", Suit.Clubs),
            new Card("a", Suit.Spades),
            new Card("a", Suit.Diamonds)
        };
        var config = new Config()
        {
            Rows = 3,
            Columns = 1,
            PromisedCards = new[]
            {
                new Card("a", Suit.Clubs)
            }
        };
        
        var results = cards.EnsurePromisedCards(config);
        results.Should().Contain(x => x == new Card("a", Suit.Clubs));
    }
    
    [Test]
    public void ShouldPromiseCardsWhenItDoesntExistsAlready()
    {
        var cards = new List<Card>()
        {
            new Card("2", Suit.Clubs),
            new Card("a", Suit.Spades),
            new Card("a", Suit.Diamonds)
        };
        var config = new Config()
        {
            Rows = 3,
            Columns = 1,
            PromisedCards = new[]
            {
                new Card("a", Suit.Clubs)
            }
        };

        for (int i = 0; i < 10; i++)
        {
             var results = cards.EnsurePromisedCards(config);
             results.Should().Contain(x => x == new Card("a", Suit.Clubs));
             results.Count().Should().Be(config.Rows * config.Columns);           
        }
    }

    [Test]
    public void GameConfigTest()
    {
         var config = new Config()
         {
             Rows = 3,
             Columns = 1,
             PromisedCards = new[]
             {
                 new Card("a", Suit.Clubs)
             }
         };

         var game = GameExtensions.CreateGame(config);
         game.Cards.Should().Contain(x => x == new Card("a", Suit.Clubs));
         game.Cards.Count().Should().Be(config.Rows * config.Columns);           
    }
}