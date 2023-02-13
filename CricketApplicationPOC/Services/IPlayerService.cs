using System;
using CricketApplicationPOC.Dto;
using CricketApplicationPOC.Models;

namespace CricketApplicationPOC.Services
{
	public interface IPlayerService
	{
        public Task<string> addPlayer(PlayerDto playerDto);

        public Task<string> savePlayerStatistics(PlayerStatisticsDto playerStatisticsDto);

        public PlayerStatistics getPlayerStatisticsByPlayerId(int playerId);
    }
}

