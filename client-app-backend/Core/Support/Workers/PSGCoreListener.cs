namespace client_app_backend.Core.Support.Workers
{
    using client_app_backend.Core.DataTransferObjects;
    using client_app_backend.Core.DataTransferObjects.User;
    using client_app_backend.Core.Repository.Interfaces;
    using client_app_backend.Core.Services;
    using client_app_backend.Core.Services.Interface;
    using client_app_backend.Core.Support.WebSocket;
    using Microsoft.Extensions.DependencyInjection;
    using Newtonsoft.Json;

    public class PSGCoreListener : BackgroundService
    {
        private readonly StompConnector _stompClient;

        private readonly IServiceScopeFactory _serviceScopeFactory;

        public PSGCoreListener(IConfiguration configuration, IServiceScopeFactory serviceScopeFactory)
        { 
            _serviceScopeFactory = serviceScopeFactory;
            _stompClient = new StompConnector(configuration.GetValue<string>("ServicesHosts:PSGCore:Url"));
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _ = Task.Run(async () => {
                await _stompClient.ConnectAsync();
                await ListenBackOffice();
                await ListenTrading();
            }, stoppingToken);
        }

        private async Task ListenBackOffice()
        {
            await _stompClient.ListenAsync("/topic/business", async (sender, message) =>
            {
                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    var surveyService = scope.ServiceProvider.GetService<ISurveyService>();
                    var content = StompConnector.GetParsedContent<PSGCoreMessageDTO>(message);
                    switch (content.Payload.Operation)
                    {
                        case "Survey Created":
                            var survey = JsonConvert.DeserializeObject<SurveyDTO>(content.Payload.Data.ToString());
                            await surveyService.Add(survey);
                            break;
                        default:
                            break;
                    }
                }
            });
        }

        private async Task ListenTrading()
        {
            await _stompClient.ListenAsync("/topic/trading", async (sender, message) =>
            {
                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    var userService = scope.ServiceProvider.GetService<IUserService>();
                    var content = StompConnector.GetParsedContent<PSGCoreMessageDTO>(message);
                    switch (content.Payload.Operation)
                    {
                        case "BUY_TOKEN":
                        case "SELL_TOKEN":
                            var balance = JsonConvert.DeserializeObject<BalanceDTO>(content.Payload.Data.ToString());
                            await userService.UpdateBalance(balance.Email, balance.Balance);
                            break;
                        default:
                            break;
                    }
                }
            });
        }
    }

    public class PSGCoreMessageDTO
    {
        public PSGCoreMessagePayloadDTO Payload { get; set; }
        public string From { get; set; }
        public DateTime TimeStamp { get; set; }
    }

    public class PSGCoreMessagePayloadDTO
    {
        public string Operation { get; set; }
        public object Data { get; set; }
    }
}
