﻿using System;
using CricketApplicationPOC.Dto;
using CricketApplicationPOC.Services;
using Microsoft.AspNetCore.Mvc;

namespace CricketApplicationPOC.Controllers
{
    [ApiController]
    [Route("player")]
    public class PlayerController
	{
        private readonly ILogger<UserController> _logger;
        private readonly IPlayerService _playerService;

        public PlayerController(ILogger<UserController> logger, IPlayerService playerService)
        {
            this._logger = logger;
            this._playerService = playerService;
        }

        [HttpPost("add")]
        public async Task<string> addPlayer(PlayerDto playerDto)
        {
            try
            {
                _logger.LogInformation("Entor Add Player");
                return await _playerService.addPlayer(playerDto);
            }
            catch (Exception e)
            {
                _logger.LogInformation("Error in Add Player");
                _logger.LogError(e.Message);
                return e.Message;
            }
        }

        [HttpPost("statistics/update")]
        public async Task<string> savePlayerStatistics(PlayerDto playerDto)
        {
            try
            {
                _logger.LogInformation("Entor Player Statistics");
                return await _playerService.addPlayer(playerDto);
            }
            catch (Exception e)
            {
                _logger.LogInformation("Error in Add Player");
                return e.Message;
            }
        }

    }
}

