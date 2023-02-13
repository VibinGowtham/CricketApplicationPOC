using System;
using CricketApplicationPOC.Dto;
using CricketApplicationPOC.Models;
using CricketApplicationPOC.Services;
using Microsoft.AspNetCore.Mvc;
namespace CricketApplicationPOC.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;
        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;

        }

        //[Route("register")]
        [HttpPost("register")]
        public string Register(UserDto userDetails)
        {
            try
            {
                return _userService.register(userDetails);
            }
            catch(Exception e)
            { 
                return e.Message;
            }
        }


        //[Route("login")]
        [HttpPost("login")]
        public string Login(UserDto userDetails)
        {
            try
            {
                return _userService.login(userDetails).Email ;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
