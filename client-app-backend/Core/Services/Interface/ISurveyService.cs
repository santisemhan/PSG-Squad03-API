namespace client_app_backend.Core.Services.Interface
{
    using client_app_backend.Core.DataTransferObjects;

    public interface ISurveyService
    {
        Task<List<SurveyDTO>> GetSurveys();

        Task<SurveyDTO> GetSurvey(Guid id);

        Task Add(SurveyDTO survey);

        Task VoteSurvey(VoteSurveyDTO vote);
    }
}
