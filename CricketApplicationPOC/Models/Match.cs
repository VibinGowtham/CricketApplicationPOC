using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace CricketApplicationPOC.Models
{
	public class Match
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MatchId { get; set; }

        [ForeignKey("WinnerTeamId")]
        public int? WinnerTeamId { get; set; }
        public Team Winner { get; set; }

        [ForeignKey("Team1")]
        public int Team1Id { get; set; }
        public Team Team1 { get; set; }

        [ForeignKey("Team2")]
        public int Team2Id { get; set; }
        public Team Team2 { get; set; }
    }
}

