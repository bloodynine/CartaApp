namespace Carta.Models;

public record GameDto
{
    public string GameId { get; set; } = string.Empty;
    public Config Config { get; set; }
    public IEnumerable<CardDto> Cards { get; set; } = Enumerable.Empty<CardDto>();

    public GameDto(Game game)
    {
        GameId = game.ID;
        Config = game.Config;
        Cards = game.Cards.Select(x => new CardDto(x));
    }
};



public record CardDto
{
    public bool IsFlipped { get; set; }
    public Suit? Suit { get; set; }
    public Guid Id { get; set; }
    public string? Face { get; set; }

    public CardDto(Card card)
    {
        IsFlipped = card.IsFlipped;
        Id = card.Id ?? Guid.NewGuid();
        if (IsFlipped)
        {
            Suit = card.Suit;
            Face = card.Face;
        }
    }
}