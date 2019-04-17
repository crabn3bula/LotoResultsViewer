using System.Collections.Generic;

namespace LotoResultsViewer.Models.Entities
{
    public class GameResultNumber
    {
        public Dictionary<long, GameResultTirage>[] GameResultTirage { get; set; }
    }
}