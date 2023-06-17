namespace client_app_backend.Core.Services
{
    using client_app_backend.Core.DataTransferObjects;
    using client_app_backend.Core.Repository.Interfaces;
    using client_app_backend.Core.Services.Interface;
    using client_app_backend.Core.Support.WebSocket;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading.Tasks;

    public class SurveyService : ISurveyService
    {
        private readonly StompConnector _stompClient;

        private readonly ISurveyRepository _surveyRepository;
        private readonly IUserRepository _userRepository;

        public SurveyService(ISurveyRepository surveyRepository, IUserRepository userRepository, IConfiguration configuration)
        {
            _stompClient = new StompConnector(configuration.GetValue<string>("ServicesHosts:PSGCore:Url"));
            _userRepository = userRepository;
            _surveyRepository = surveyRepository;
        }

        public async Task<List<SurveyDTO>> GetSurveys()
        {
            var surveys = await _surveyRepository.Get();
            return surveys
                .Select(survey => survey.ToDTO())
                .ToList();
        }

        public async Task<SurveyDTO> GetSurvey(Guid id)
        {
            var survey = await _surveyRepository.Get(id);
            return survey.ToDTO();
        }

        public async Task Add(SurveyDTO survey)
        {
            await _surveyRepository.Add(survey);
            await _surveyRepository.Save();
        }

        public async Task VoteSurvey(VoteSurveyDTO vote)
        {
            var survey = await _surveyRepository.Get(vote.SurveyId);
            var now = DateTime.UtcNow;
            if (survey == null || !(now > survey.StartDate && now < survey.EndDate))
                throw new Exception("You can't vote this survey because is expired or not exists.");

            if (vote.Answer.Count() <= 0)
                throw new Exception("The answer is empty");

            if (survey.OptionType == "SingleOption" && vote.Answer.Count() != 1)
                throw new Exception("The answer for this survey must be unique");
            
            var user = await _userRepository.Get(vote.Email);
            if (user == null)
                throw new Exception("The user has no balance.");

            if (user.VotedSurveys.Any(votedSurvey => votedSurvey.Id == survey.Id))
                throw new Exception("The user already voted the survey.");

            user.VotedSurveys.Add(survey);
            await _userRepository.Save();

            var balance = user == null ? 0 : user.Balance;
            var message = new VoteSurveyMessageDTO(vote, balance);
            var serializedMessage = JsonConvert.SerializeObject(message);
            await _stompClient.SendAsync($@"{{
                    'payload': {{
                        'operation': 'User Voted',
                        'data': {serializedMessage}
                    }},
                  }}", "/app/send/users");
        }
    }
}
