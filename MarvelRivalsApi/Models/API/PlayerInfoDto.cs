namespace MarvelRivalsApi.Models.API
{
    public class PlayerInfoDto
    {
        public long? PlayerUid { get; set; }
        public string? PlayerName { get; set; }

        public string? GetPlayerUid()
        {


            return PlayerUid + "";
        }
    }
}
