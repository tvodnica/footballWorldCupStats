using Newtonsoft.Json;

namespace Data
{
    public partial class Player
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("captain")]
        public bool Captain { get; set; }

        [JsonProperty("shirt_number")]
        public int ShirtNumber { get; set; }

        [JsonProperty("position")]

        public string Position { get; set; }
        public string Image { get; set; }
        public int Goals { get; set; }
        public int YellowCards { get; set; }
        public int GoalsInThisMatch { get; set; }
        public int YellowCardsInThisMatch { get; set; }

    }

}


