namespace client_app_backend.Core.Repository.Interfaces
{
    using client_app_backend.Core.DataTransferObjects;
    using client_app_backend.Core.Models;

    public interface ISurveyRepository
    {
        Task<List<Survey>> Get();

        Task<Survey> Get(int id);

        Task Add(SurveyDTO survey);

        Task<int> Save();
    }
}
