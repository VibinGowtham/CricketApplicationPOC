using System;
using CricketApplicationPOC.Dto;
using CricketApplicationPOC.Services;
using Microsoft.AspNetCore.Mvc;

namespace CricketApplicationPOC.Controllers
{
    [ApiController]
    [Route("team")]
    public class TeamController
	{
        private readonly ILogger<UserController> _logger;
        private readonly ITeamService _teamService;

        public TeamController(ILogger<UserController> logger, ITeamService teamService)
        {
            _logger = logger;
            _teamService = teamService;
        }

        [HttpPost("add")]
        public string addTeam(TeamDto teamDetails)
        {
            try
            {
                return _teamService.addTeam(teamDetails);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }


        [HttpPost("update")]
        public async Task<string> updateTeam(TeamDto teamDetails)
        {
            try
            {
                return await _teamService.updateTeam(teamDetails);
            }
            catch
            {
                return "Error";
            }
        }


        [HttpPost("match/add")]
        public async Task<string> addMatch(MatchDto matchDto)
        {
            try
            {
                return await _teamService.addMatch(matchDto);
            }
            catch(Exception e)
            {
                return e.Message;
            }
        }


        [HttpPost("match/winner/update")]
        public async Task<string> updateWinner(MatchDto matchDto)
        {
            try
            {
                return await _teamService.updateWinner(matchDto);
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
    }
}

