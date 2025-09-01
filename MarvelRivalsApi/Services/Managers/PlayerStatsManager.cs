
using MarvelRivalsApi.Data.Repositories.PlayerStats;
using MarvelRivalsApi.Services.PlayerStats;
using MarvelRivalsApi.Mappings;

namespace MarvelRivalsApi.Services.Managers
{
    public class PlayerStatsManager
    {
        private readonly IPlayerStatsService playerStatsService;
        private readonly IPlayerStatsRepository pstatsRepository;

        public PlayerStatsManager(IPlayerStatsService pstatsService, IPlayerStatsRepository pstatsRepository)
        {
            this.playerStatsService = pstatsService;
            this.pstatsRepository = pstatsRepository;
        }

 
        public async Task FetchPlayerStatsAndSaveToDatabaseAsync(long uid)
        {
            try
            {
                var response = await playerStatsService.FetchByUidAsync(uid);
                if (response == null ) return;

                var entity = PlayerStatsMapper.DtoToEntity(response);
                
                await pstatsRepository.AddAsync(entity);
            }
            catch (Exception ex)    
            {
                // Handle exceptions, log errors, etc.
                throw new Exception("Error fetching all maps", ex);
            }
        }
    }
}