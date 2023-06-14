namespace client_app_backend.Core.Support.Workers
{
    using client_app_backend.Core.Repository.Interfaces;
    using client_app_backend.Core.Support.WebSocket;

    public class MockMessage : BackgroundService
    {
        private readonly StompConnector _stompClient;

        public MockMessage(IConfiguration configuration)
        {
            _stompClient = new StompConnector(configuration.GetValue<string>("ServicesHosts:PSGCore:Url"));
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _ = Task.Run(async () =>
            {
                await Task.Delay(5000);
                await _stompClient.ConnectAsync();
                await SendAsync();
            }, stoppingToken);
        }

        private async Task SendAsync()
        {
            await Task.Delay(5000);
            await _stompClient.SendAsync("hola", "/app/send/users");
        }
    }
}
