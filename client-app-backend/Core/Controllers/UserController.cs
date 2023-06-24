namespace client_app_backend.Core.Controllers
{
    using client_app_backend.Core.DataTransferObjects.User;
    using client_app_backend.Core.Services.Interface;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Get a user balance.
        /// </summary>
        /// <returns>An object representing the balance of the user.</returns>
        /// <response code="200">An object representing the balance of the user.</response>
        /// <response code="404">User balance was not found.</response>
        /// <response code="500">An unexpected error occurred while getting the last matches of PSG.</response>
        [HttpGet]
        [Route("balance")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BalanceDTO))]
        public async Task<IActionResult> GetBalance([FromQuery] string email)
        {
            var balance = await _userService.GetBalance(email);
            return Ok(balance);
        }
    }
}
