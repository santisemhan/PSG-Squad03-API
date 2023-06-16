namespace client_app_backend.Core.Services
{
    using client_app_backend.Core.DataTransferObjects;
    using client_app_backend.Core.Repository.Interfaces;
    using client_app_backend.Core.Services.Interface;
    using client_app_backend.Core.Support.WebSocket;
    using System.Collections.Generic;
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
            var user = await _userRepository.Get(vote.Email);
            var balance = user == null ? 0 : user.Balance;
            var message = new VoteSurveyMessageDTO(vote, balance);
            await _stompClient.SendAsync($@"{{
                    'payload': {{
                        'operation': 'User Voted',
                        'data': {message}
                    }},
                    'from': 'Users',
                    'timestamp': {DateTime.UtcNow}
                  }}", "/app/send/users");
        }
    }
}
