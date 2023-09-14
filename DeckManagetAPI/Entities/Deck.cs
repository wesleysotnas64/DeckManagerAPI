namespace DeckManagerAPI.Entities
{
    public class Deck
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<Card>? Cards { get; set; }
    }
}
