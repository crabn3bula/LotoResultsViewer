using LotoResultsViewer.Models.Entities;
using LotoResultsViewer.Models.Interfaces;

namespace LotoResultsViewer.Models.Data
{
    public class ApiProvider : IApiProvider
    {
        public string Name { get; set; }
        public string Domain { get; set; }
        public string Prefix { get; set; }
        public string GameTypes { get; set; }
        public string GameArchive { get; set; }

        public string GetGameTypes()
        {
            return string.Concat(Domain, "/", Prefix, "/", GameTypes);
        }

        public string GetGameArchives(GameType gameType)
        {
            return string.Concat(Domain, "/", Prefix, "/", GameArchive , gameType.Game);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
