namespace client_app_backend.Core.Support.Workers
{
    using client_app_backend.Core.Repository.Interfaces;
    using client_app_backend.Core.Support.WebSocket;
    using Microsoft.Extensions.DependencyInjection;

    public class PSGCoreListener : BackgroundService
    {
        private readonly StompConnector _stompClient;

        private readonly ISurveyRepository _surveyRepository;

        public PSGCoreListener(IConfiguration configuration, IServiceScopeFactory serviceScopeFactory)
        {
            using (var scope = serviceScopeFactory.CreateScope())
            {
                _surveyRepository = scope.ServiceProvider.GetService<ISurveyRepository>();
                _stompClient = new StompConnector(configuration.GetValue<string>("ServicesHosts:PSGCore:Url"));
            }
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _ = Task.Run(async () => {
                await _stompClient.ConnectAsync();
                await ListenAsync();
            }, stoppingToken);
        }

        private async Task ListenAsync()
        {
            await _stompClient.ListenAsync("/topic/users", (sender, message) =>
            {
                Console.WriteLine(message.Body);
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
