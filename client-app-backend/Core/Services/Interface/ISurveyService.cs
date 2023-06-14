namespace client_app_backend.Core.Services.Interface
{
    using client_app_backend.Core.DataTransferObjects;
    using Microsoft.AspNetCore.Mvc;

    public interface ISurveyService
    {
        Task<List<SurveyDTO>> GetSurveys();

        Task<SurveyDTO> GetSurvey(string id);

        Task Add(SurveyDTO survey);
    }
}
