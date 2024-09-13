namespace Carta.Models;

public class History
{
    public Point Type { get; set; }
    public Card Card { get; set; }
    
    public History(Point type, Card card)
    {
        Type = type;
        Card = card;
    }
}