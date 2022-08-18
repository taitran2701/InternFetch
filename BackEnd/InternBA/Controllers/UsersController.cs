using InternBA.Models;
using InternBA.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InternBA.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IJWTManagerRepository jWTManager;
        private readonly IUserServiceRepository userServiceRepository;
        public UsersController(IJWTManagerRepository jWTManager, IUserServiceRepository userServiceRepository)
        {
            this.jWTManager = jWTManager;
            this.userServiceRepository = userServiceRepository;
        }
        [HttpGet]
        public List<string> Get()
        {
            return null;
        }

        public async Task<IActionResult> AuthenticateAsync(User usersdata)
        {
            var validUser = await userServiceRepository.IsValidUserAsync(usersdata);
            if (!validUser)
            {
                return Unauthorized("Incorrect username and password!");
            }
            var token = jWTManager.GenerateToken(usersdata.Username);
            if(token == null)
            {
                return Unauthorized("Invalid Attempt!");
            }

            UserRefreshTokens obj = new()
            {
                RefreshToken = token.Refresh_Token,
                UserName = usersdata.Username
            };
            userServiceRepository.AddUserRefreshTokens(obj);
            userServiceRepository.SaveCommit();
            return Ok(token);
        }
    }
}
