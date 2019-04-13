
namespace LotoResultsViewer.Models.Entities
{
    public class GameType
    {
        public string Game { get; set; }
        public string Cost { get; set; }
        public long NextDrawDate { get; set; }

        public override string ToString()
        {
            return Game;
        }
    }
}
