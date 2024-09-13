using Carta.Models;

namespace Carta;

public class CardConstants
{
    public static IEnumerable<string> Faces = new[]
    {
        "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"
    };

    public static IEnumerable<Suit> Suits = new[]
    {
        Suit.Spades, Suit.Clubs, Suit.Diamonds, Suit.Hearts
    };

    public static IEnumerable<Card> AllCards()
    {
        var cards = (from face in Faces from suit in Suits select new Card(face, suit)).ToList();
        cards.Add(new("Joker", Suit.Hearts) );
        cards.Add(new("Joker", Suit.Spades) );
        return cards;
    }
}

public enum Suit
{
    Spades,
    Hearts,
    Diamonds,
    Clubs
}