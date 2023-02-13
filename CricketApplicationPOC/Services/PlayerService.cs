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
                _logger.LogInformation("Add player Service try block");
                _dbContext.Add<Player>(player);
                await _dbContext.SaveChangesAsync();
                return "Added Player";
            }
            catch {
                _logger.LogInformation("Add player Service catch block");
                throw;
            }
        }
    }
}

