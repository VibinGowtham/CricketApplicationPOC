using System;
using CricketApplicationPOC.Dto;

namespace CricketApplicationPOC.Services
{
	public interface IPlayerService
	{
        public Task<string> addPlayer(PlayerDto playerDto);

        //public Task<string> savePlayerStatistics(PlayerDto playerDto);
    }
}

