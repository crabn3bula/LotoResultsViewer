using Newtonsoft.Json;

namespace LotoResultsViewer.Models.Entities
{
    public class GameResultTirage
    {
        [JsonProperty("date")]
        public long Date { get; set; }

        [JsonProperty("isJP")]
        public bool IsJp { get; set; }

        [JsonProperty("jackpotSum")]
        public long JackpotSum { get; set; }

        [JsonProperty("nextJackpotSum")]
        public long NextJackpotSum { get; set; }
    }
}
