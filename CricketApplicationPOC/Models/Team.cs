using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CricketApplicationPOC.Models
{
	public class Team
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public int TotalMatchesPlayed { get; set; }
        public int TotalWin { get; set; }
        public int TotalLoss { get; set; }
    }
}

