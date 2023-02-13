using System;
using CricketApplicationPOC.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace CricketApplicationPOC.Dto
{
	public class MatchDto
	{
        public int MatchId { get; set; }

        public int WinnerTeamId { get; set; }

        public int Team1Id { get; set; }

        public int Team2Id { get; set; }
    }
}

