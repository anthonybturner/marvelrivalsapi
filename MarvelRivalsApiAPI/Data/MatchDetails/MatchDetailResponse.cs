using MarvelRivalsApiAPI.Models;

namespace MarvelRivalsApiAPI.Data.MatchDetails
{

    public class MatchDetailResponse
    {
        public string? PlayerName { get; set; }
        public int PlayerGuid { get; set; }
        public MatchDetail MatchDetail { get; set; }
        public List<MatchPlayer> MathPlayers { get; set; }

        public MatchDetailResponse()
        {
            MatchDetail = new MatchDetail();
            MathPlayers = new List<MatchPlayer>();
        }
    }
}
