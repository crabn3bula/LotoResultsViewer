using System.Collections.Generic;

namespace LotoResultsViewer.Models.Entities
{
    public class GameResultYear
    {
        public Dictionary<string, GameResultNumber[]> GameResultNumber { get; set; }
    }
}
