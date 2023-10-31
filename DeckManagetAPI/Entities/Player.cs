using Newtonsoft.Json;

namespace DeckManagerAPI.Entities
{
    public class Player : User
    {
        [JsonProperty("collection")]
        public List<Card>? Colection { get; set; }

        [JsonProperty("decks")]
        public List<Deck>? Decks { get; set; }
    }
}
