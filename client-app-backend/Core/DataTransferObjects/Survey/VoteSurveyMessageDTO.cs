namespace client_app_backend.Core.DataTransferObjects
{
    public class VoteSurveyMessageDTO
    {
        public Guid SurveyId { get; set; }

        public List<string> Answer { get; set; }

        public string Email { get; set; }

        public decimal VoteQuantity { get; set; }

        public VoteSurveyMessageDTO() { }

        public VoteSurveyMessageDTO(VoteSurveyDTO vote, decimal balance) 
        {
            SurveyId = vote.SurveyId;
            Answer = vote.Answer;
            Email = vote.Email;
            VoteQuantity = balance;
        }
    }
}
