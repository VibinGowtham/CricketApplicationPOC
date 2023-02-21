using System;
using CricketApplicationPOC.Dto;
using CricketApplicationPOC.Models;

namespace CricketApplicationPOC.Services
{
	public interface IUserService
	{
		public string register(UserDto userDetails);

        public string login(UserDto userDetails);
    }
}

 