namespace client_app_backend.Core.Services
{
    using client_app_backend.Core.DataTransferObjects;
    using client_app_backend.Core.Repository.Interfaces;
    using client_app_backend.Core.Services.Interface;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class SurveyService : ISurveyService
    {
        private readonly ISurveyRepository _surveyRepository;

        public SurveyService(ISurveyRepository surveyRepository)
        {
            _surveyRepository = surveyRepository;
        }

        public async Task<List<SurveyDTO>> GetSurveys()
        {
            var surveys = await _surveyRepository.Get();
            return surveys
                .Select(survey => survey.ToDTO())
                .ToList();
        }

        public async Task<SurveyDTO> GetSurvey(string id)
        {
            var survey = await _surveyRepository.Get(id);
            return survey.ToDTO();
        }

        public async Task Add(SurveyDTO survey)
        {
            await _surveyRepository.Add(survey);
        }
    }
}
