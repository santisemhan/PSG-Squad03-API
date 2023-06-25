namespace client_app_backend.Core.DataTransferObjects
{
    public class VoteSurveyMessageDTO
    {
        public int SurveyId { get; set; }

        public string Question { get; set; }

        public List<string> Answer { get; set; }

        public string Email { get; set; }

        public decimal VoteQuantity { get; set; }

        public VoteSurveyMessageDTO() { }

        public VoteSurveyMessageDTO(VoteSurveyDTO vote, string question, decimal balance) 
        {
            SurveyId = vote.SurveyId;
            Question = question;
            Answer = vote.Answer;
            Email = vote.Email;
            VoteQuantity = balance;
        }
    }
}
