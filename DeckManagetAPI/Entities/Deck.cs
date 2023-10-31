using Newtonsoft.Json;

namespace DeckManagerAPI.Entities
{
    public class Deck
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("cards")]
        public List<Card>? Cards { get; set; }

        [JsonProperty("image")]
        public string? Image { get; set; }

    }
}
