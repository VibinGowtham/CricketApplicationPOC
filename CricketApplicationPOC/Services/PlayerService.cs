using System;
using CricketApplicationPOC.Controllers;
using CricketApplicationPOC.Dto;
using CricketApplicationPOC.Models;

namespace CricketApplicationPOC.Services
{
	public class PlayerService : IPlayerService 
	{
        private readonly ILogger<UserController> _logger;
        private readonly AppDbContext _dbContext;

        public PlayerService(AppDbContext dbContext, ILogger<UserController> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<string> addPlayer(PlayerDto playerDetails)
        {
            _logger.LogInformation("Add player Service");
            if (playerDetails.Email.Length == 0 || playerDetails.Name.Length == 0 || playerDetails.PhoneNumber.Length == 0 || playerDetails.Email.Length == 0 || playerDetails.Postion == "0")
            {
                throw new Exception("Enter Valid Details");
            }

            Player player = new Player();
            player.Email = playerDetails.Email;
            player.Name = playerDetails.Name;
            player.Postion = playerDetails.Postion;
            player.TeamId = playerDetails.TeamId;
            player.PhoneNumber = playerDetails.PhoneNumber;

            try
            {
                _logger.LogInformation("Enter Add player Service");
                _dbContext.Add<Player>(player);
                await _dbContext.SaveChangesAsync();
                return "Added Player";
            }
            catch {
                _logger.LogInformation("Error in add player Service");
                throw;
            }
        }

        public async Task<string> savePlayerStatistics(PlayerStatisticsDto playerStatisticsDto)
        {
            try
            {
                _logger.LogInformation("Enter Save player Stats Service");
                PlayerStatistics playerStatistics = getPlayerStatisticsByPlayerId(playerStatisticsDto.PlayerId);
            if (playerStatistics != null)
            {
                playerStatistics.TotalLoses = playerStatisticsDto.TotalLoses;
                playerStatistics.TotalWins = playerStatisticsDto.TotalWins;
                playerStatistics.TotalMatchesPlayed = playerStatisticsDto.TotalMatchesPlayed;
                _dbContext.Update<PlayerStatistics>(playerStatistics);
                await _dbContext.SaveChangesAsync();
                return "Updated Player Statistics";
            }
            else
            {
                playerStatistics = new PlayerStatistics();
                playerStatistics.PlayerId = playerStatisticsDto.PlayerId;
                playerStatistics.TotalLoses = playerStatisticsDto.TotalLoses;
                playerStatistics.TotalWins = playerStatisticsDto.TotalWins;
                playerStatistics.TotalMatchesPlayed = playerStatisticsDto.TotalMatchesPlayed;
                _dbContext.Add<PlayerStatistics>(playerStatistics);
                await _dbContext.SaveChangesAsync();
                return "Added Player Statistics";
            }
            }
            catch
            {
                _logger.LogInformation("Error in save player Service");
                throw;
            }
        }

        public PlayerStatistics getPlayerStatisticsByPlayerId(int playerId)
        {
            if (playerId == null)
            {
                throw new Exception("Enter Valid player id");
            }

            PlayerStatistics playerStatistics;
            try
            {
                _logger.LogInformation("Enter getPlayerStatisticsByPlayerId Service");
                playerStatistics = _dbContext.PlayerStatistics.Where(x => x.PlayerId == playerId).FirstOrDefault();
            }
            catch
            {
                _logger.LogInformation("Error in getPlayerStatisticsByPlayerId Service");
                throw;
            }
            return playerStatistics;

        }
    }
}

