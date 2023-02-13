using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CricketApplicationPOC.Models
{
	public class PlayerStatistics
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PlayerStatisticsId { get; set; }
        public string? TotalMatchesPlayed { get; set; }
        public string? TotalWins { get; set; }
        public string? TotalLoses { get; set; }

        public int PlayerId { get; set; }
        public Player Player { get; set; }
    }
}

