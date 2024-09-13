using MongoDB.Entities;

namespace Carta.Models;

public class Game : Entity
{
    public Config Config { get; set; }
    public List<Card> Cards { get; set; } = new();
}