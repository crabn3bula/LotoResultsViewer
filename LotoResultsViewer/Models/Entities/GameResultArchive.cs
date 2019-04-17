using System.Collections.Generic;
using Newtonsoft.Json;

namespace LotoResultsViewer.Models.Entities
{
    public class GameResultArchive
    {
        [JsonProperty("2019")]
        public Dictionary<string, GameResultYear[]> GameResultYear { get; set; }
    }
}