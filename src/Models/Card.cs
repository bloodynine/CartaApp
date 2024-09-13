namespace Carta.Models;

public record Card
{
    public Guid? Id { get; set; } = Guid.NewGuid();
    public string Face { get; set; }
    public Suit Suit { get; set; }
    public bool IsFlipped { get; set; }

    public Card(string face, Suit suit)
    {
        Id = Guid.NewGuid();
        Face = face;
        Suit = suit;
        IsFlipped = false;
    }
}