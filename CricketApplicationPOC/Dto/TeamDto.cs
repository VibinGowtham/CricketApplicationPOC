using System;
namespace CricketApplicationPOC.Dto
{
	public class TeamDto
	{
          public string TeamName { get; set; }
		  public int TeamId { get; set; }
          public int TotalMatchesPlayed { get; set; }
          public int TotalWin { get; set; }
          public int TotalLoss { get; set; }
    }
}

