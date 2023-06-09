namespace client_app_backend.Core.Controllers
{
    using client_app_backend.Core.DataTransferObject.Match.Finalized;
    using client_app_backend.Core.DataTransferObject.Match.Next;
    using client_app_backend.Core.DataTransferObject.Team.Table;
    using client_app_backend.Core.Services.Interface;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/v1/[controller]")]
    [ApiController]
    [Consumes("application/json")]
    [Produces("application/json")]
    public sealed class PSGController : ControllerBase
    {
        private readonly IPSGService _psgService;
        public PSGController(IPSGService psgService)
        {
            _psgService = psgService;
        }

        /// <summary>
        /// Gets the last matches of PSG.
        /// </summary>
        /// <returns>A list of objects representing the last matches of PSG.</returns>
        /// <response code="200">A list of objects representing the last matches of PSG is returned.</response>
        /// <response code="404">No information about the last matches of PSG was found.</response>
        /// <response code="500">An unexpected error occurred while getting the last matches of PSG.</response>
        [HttpGet]
        [Route("last-matches")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<FinalizedMatchDTO>))]
        public async Task<IActionResult> LastMatches()
        {
            var result = await _psgService.GetFinalizedMatches();
            return Ok(result);
        }

        /// <summary>
        /// Gets the next matches of PSG.
        /// </summary>
        /// <returns>A list of objects representing the next matches of PSG.</returns>
        /// <response code="200">A list of objects representing the next matches of PSG is returned.</response>
        /// <response code="404">No information about the next matches of PSG was found.</response>
        /// <response code="500">An unexpected error occurred while getting the next matches of PSG.</response>
        [HttpGet]
        [Route("next-matches")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<NextMatchDTO>))]
        public async Task<IActionResult> NextMatches()
        {
            var result = await _psgService.GetNextMatches();
            return Ok(result);
        }

        /// <summary>
        /// Gets the Ligue 1 table of PSG.
        /// </summary>
        /// <returns>An object representing the Ligue 1 table of PSG.</returns>
        /// <response code="200">An object representing the Ligue 1 table of PSG is returned.</response>
        /// <response code="404">No information about the Ligue 1 table of PSG was found.</response>
        /// <response code="500">An unexpected error occurred while getting the Ligue 1 table of PSG.</response>
        [HttpGet]
        [Route("ligue1-table")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<TableTeamDTO>))]
        public async Task<IActionResult> Ligue1PositionTable()
        {
            var result = await _psgService.GetLigue1PositionTable();
            return Ok(result);
        }
    }
}
