namespace client_app_backend.Core.Support.Workers
{
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
                // await SendSurveyCreated();
                // await SendBoughtToken();
                // await SendSoldToken();
            }, stoppingToken);
        }

        private async Task SendSurveyCreated()
        {
            await _stompClient.SendAsync(@"{
                  'payload': {
                      'operation': 'Survey Created',
                      'data': {
                          'question': 'Will PSG win this year?',
	                      'creationDate': '2023-05-16T19:05:22.418Z',
	                      'startDate': '2022-11-13T04:00:00.000Z',
	                      'endDate': '2023-11-12T03:00:00.000Z',
	                      'optionsList': ['Yes', 'No', 'Maybe'],
	                      'optionType': 'SingleOption'
                      }
                  },
                  'from': 'BACKOFFICE',
                  'timestamp': '2023-12-22T18:43:48Z'
                }
                ", "/app/send/business");
        }

        private async Task SendBoughtToken()
        {
            await _stompClient.SendAsync(@"{
                  'payload': {
                      'operation': 'BUY_TOKEN',
                      'data': {
                          'quantity': 1.5,
	                      'balance': 1.5,
	                      'symbol': 'PSG',
	                      'price': 5,
	                      'email': 'anemail@provider.com',
	                      'dni': '333333'
                      }
                  },
                  'from': 'TRADING',
                  'timestamp': '2023-12-22T18:43:48Z'
                }
                ", "/app/send/trading");
        }

        private async Task SendSoldToken()
        {
            await _stompClient.SendAsync(@"{
                  'payload': {
                      'operation': 'SELL_TOKEN',
                      'data': {
                          'quantity': 1,
	                      'balance': 0.5,
	                      'symbol': 'PSG',
	                      'price': 5,
	                      'email': 'anemail@provider.com',
	                      'dni': '333333'
                      }
                  },
                  'from': 'TRADING',
                  'timestamp': '2023-12-22T18:43:48Z'
                }
                ", "/app/send/trading");
        }
    }
}
