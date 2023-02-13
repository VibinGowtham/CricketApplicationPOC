using System;
using CricketApplicationPOC.Dto;
using CricketApplicationPOC.Models;

namespace CricketApplicationPOC.Services
{
	public interface ITeamService
	{
		public string addTeam(TeamDto teamDto);

		public Task<string> updateTeam(TeamDto teamDto);

		public Team getTeamById(int? teamId);

    }
}

