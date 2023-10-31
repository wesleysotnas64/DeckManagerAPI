using Newtonsoft.Json;

namespace DeckManagerAPI.Entities
{
    public class Card
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("power")]
        public int Power { get; set; }

        [JsonProperty("toughness")]
        public int Toughness { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }
    }

}
