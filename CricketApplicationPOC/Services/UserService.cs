using System;
using CricketApplicationPOC.Dto;
using CricketApplicationPOC.Models;
namespace CricketApplicationPOC.Services
{
	public class UserService:IUserService
	{
		private readonly AppDbContext _dbContext;

        public UserService(AppDbContext dbContext) {
			_dbContext = dbContext;
		}

		public string register(UserDto userDetails)
		{
			if(userDetails.Email.Length == 0 || userDetails.Name.Length == 0 || userDetails.Password.Length == 0)
			{
				throw new Exception("Enter Valid Details");
			}

			User user = new User();
			user.Name = userDetails.Name;

			var passwordHash = BCrypt.Net.BCrypt.HashPassword(userDetails.Password);
			user.Password = passwordHash;
			user.Email = userDetails.Email;

			try
			{
				_dbContext.Add<User>(user);

                _dbContext.SaveChanges();

                return "Successfully Registered";
            }
			catch
			{
				throw;
			}

		}


		public string login(UserDto userDetails)
		{
			if (userDetails.Email.Length == 0 || userDetails.Password.Length == 0)
			{
				throw new Exception("Enter Email and Password");
			}
			User user = _dbContext.Users.Where(user => user.Email == userDetails.Email).FirstOrDefault();
			if (user!=null)
			{
				var decryptedPassword = BCrypt.Net.BCrypt.Verify(userDetails.Password, user.Password);

				if (decryptedPassword) return "Login Successfull";
				else return "Invalid password";
			}
			return "User Not found.please register";
        }

	}
}

