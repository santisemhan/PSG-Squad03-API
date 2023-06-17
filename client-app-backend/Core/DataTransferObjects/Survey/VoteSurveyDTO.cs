namespace client_app_backend.Core.DataTransferObjects
{
    public class VoteSurveyDTO
    {
        public Guid SurveyId { get; set; }

        public List<string> Answer { get; set; } = new List<string>();

        public string Email { get; set; }
    }
}
