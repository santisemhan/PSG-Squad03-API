namespace client_app_backend.Core.Controllers
{
    using client_app_backend.Core.DataTransferObjects;
    using client_app_backend.Core.Services.Interface;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class SurveyController : ControllerBase
    {
        private readonly ISurveyService _surveyService;

        public SurveyController(ISurveyService surveyService)
        {
            _surveyService = surveyService;
        }

        /// <summary>
        /// Gets the surveys of PSG.
        /// </summary>
        /// <returns>A list of objects representing the surveys of the PSG.</returns>
        /// <response code="200">A list of objects representing the surveys of the PSG.</response>
        /// <response code="404">No surveys of PSG was found.</response>
        /// <response code="500">An unexpected error occurred while getting the last matches of PSG.</response>
        [HttpGet]
        [Route("surveys")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<SurveyDTO>))]
        public async Task<IActionResult> GetSurveys()
        {
            var surveys = await _surveyService.GetSurveys();
            return Ok(surveys);
        }

        /// <summary>
        /// Get a survey of PSG.
        /// </summary>
        /// <returns>An object representing the survey of the PSG.</returns>
        /// <response code="200">An object representing the survey of the PSG.</response>
        /// <response code="404">No survey of PSG was found.</response>
        /// <response code="500">An unexpected error occurred while getting the last matches of PSG.</response>
        [HttpGet]
        [Route("survey/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SurveyDTO))]

        public async Task<IActionResult> GetSurvey([FromRoute] string id)
        {
            var survey = await _surveyService.GetSurvey(id);
            return Ok(survey);
        }
    }
}
