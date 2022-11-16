using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using NZWalksAPI.Repositories;

namespace NZWalksAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private readonly IUserRepository userRepository;
        private readonly ITokenHandler tokenHandler;

        public AuthController(IUserRepository userRepository, ITokenHandler tokenHandler)
        {
            this.userRepository = userRepository;
            this.tokenHandler = tokenHandler;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginAsync(Models.DTO.LoginRequest loginRequest)
        {
            // Validate the incoming rquest
            if (!ValidateLoginAsync(loginRequest))
            {
                return BadRequest(ModelState);
            }

            // Check if user is authenticated
            // Check user and password
            var user = await userRepository.AuthenticateAsync(loginRequest.Username, loginRequest.Password);

            if (user != null)
            {
                // Generate a JWT token
                var token = await tokenHandler.CreateTokenAsync(user);

                return Ok(token);
            }

            return BadRequest("Username or Password is incorrect.");
        }

        #region Private methods
        private bool ValidateLoginAsync(Models.DTO.LoginRequest loginRequest)
        {
            if (loginRequest == null)
            {
                ModelState.AddModelError(nameof(loginRequest), "Login credentials are required");
            }

            if (string.IsNullOrWhiteSpace(loginRequest.Username))
            {
                ModelState.AddModelError(nameof(loginRequest.Username), $"{nameof(loginRequest.Username)} cannot be null or empty or white space.");
            }

            if (string.IsNullOrWhiteSpace(loginRequest.Password))
            {
                ModelState.AddModelError(nameof(loginRequest.Password), $"{nameof(loginRequest.Password)} cannot be null or empty or white space.");
            }

            if (ModelState.ErrorCount > 0)
            {
                return false;
            }

            return true;
        }
        #endregion
    }
}
