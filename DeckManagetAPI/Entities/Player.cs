namespace DeckManagerAPI.Entities
{
    public class Player : User
    {
        public List<Card>? Colection { get; set; }
        public List<Deck>? Decks { get; set; }
    }
}
