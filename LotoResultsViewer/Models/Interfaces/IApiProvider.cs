using LotoResultsViewer.Models.Entities;

namespace LotoResultsViewer.Models.Interfaces
{
    public interface IApiProvider
    {
        string GetGameTypes();
        string GetGameArchives(GameType gameType);
    }
}