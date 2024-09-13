namespace Carta.Models;

public class Config
{
    public int Rows { get; set; } = 4;
    public int Columns { get; set; } = 5;
    public int TotalItems => Rows * Columns;
    public IEnumerable<Card> DisAllowedCards { get; set; } = Enumerable.Empty<Card>();
    public IEnumerable<Card> PromisedCards { get; set; } = Enumerable.Empty<Card>();
}