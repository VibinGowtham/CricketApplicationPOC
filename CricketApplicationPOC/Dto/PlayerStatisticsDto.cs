using System;
namespace CricketApplicationPOC.Dto
{
	public class PlayerStatisticsDto
	{
        public int PlayerStatisticsId { get; set; }
        public string? TotalMatchesPlayed { get; set; }
        public string? TotalWins { get; set; }
        public string? TotalLoses { get; set; }

        public int PlayerId { get; set; }
    }
}

