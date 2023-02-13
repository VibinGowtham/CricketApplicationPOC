using System;
namespace CricketApplicationPOC.Dto
{
	public class PlayerDto
	{
        public int PlayerId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Postion { get; set; }

        public int TeamId { get; set; }
    }
}

