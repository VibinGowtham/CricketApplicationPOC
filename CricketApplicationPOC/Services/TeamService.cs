using System;
using CricketApplicationPOC.Dto;
using CricketApplicationPOC.Models;
namespace CricketApplicationPOC.Services
{
	public class TeamService:ITeamService
	{
		private readonly AppDbContext _dbContext;

        public TeamService(AppDbContext dbContext) {
			_dbContext = dbContext;
		}

		public string addTeam(TeamDto teamDetails)
		{
			if (teamDetails.TeamName.Length == 0)
			{
				throw new Exception("Enter Valid team Name");
			}

			Team team = new Team();

			team.TeamName = teamDetails.TeamName;

			try
			{

				_dbContext.Add<Team>(team);

				_dbContext.SaveChanges();

				return "Successfully Added Team";
			}
			catch
			{
				throw;
			}

		}

        public async Task<string> updateTeam(TeamDto teamDetails)
        {
            if (teamDetails.TeamId == null)
            {
                throw new Exception("Enter Valid team id");
            }

            Team team;
            try
            {
                team = getTeamById(teamDetails.TeamId);
                if (team != null)
                {
                    team.TeamName = teamDetails.TeamName;
                    team.TotalLoss = teamDetails.TotalLoss;        
                    team.TotalMatchesPlayed = teamDetails.TotalMatchesPlayed;
                    team.TotalWin = teamDetails.TotalWin;
                    _dbContext.Update<Team>(team);
                    await _dbContext.SaveChangesAsync();
                    return "Updated Team Details";
                }
                else
                {
                    throw new Exception("Team doesn't exist");
                }
            }
            catch
            {
                throw;
            }

        }

        public Team getTeamById(int? teamId)
        {
            if (teamId == null)
            {
                throw new Exception("Enter Valid team id");
            }

            Team team;
            try
            {
                team = _dbContext.Find<Team>(teamId);
            }
            catch
            {
                throw;
            }
            return team;
        }

    }
}

