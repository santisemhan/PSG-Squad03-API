namespace client_app_backend.Core.DataTransferObjects
{
    public class VoteSurveyDTO
    {
        public Guid SurveyId { get; set; }

        public string Answer { get; set; }

        public string Email { get; set; }

        public string Dni { get; set; }
    }
}
