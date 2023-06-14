namespace client_app_backend.Core.Support.WebSocket
{
    using Netina.Stomp.Client;
    using Netina.Stomp.Client.Interfaces;
    using Netina.Stomp.Client.Messages;
    using System.Reflection.PortableExecutable;

    public class StompConnector
    {
        private IStompClient _clientStomp;

        public StompConnector(string url)
        {
            _clientStomp = new StompClient(url);
        }

        public async Task ConnectAsync()
        {
            await _clientStomp.ConnectAsync(new Dictionary<string, string>());
        }

        public async Task DisconnectAsync()
        {
            await _clientStomp.DisconnectAsync();
        }

        public async Task ListenAsync<T>(string destination, EventHandler<T> handler)
        {
            await _clientStomp.SubscribeAsync<T>(destination, new Dictionary<string, string>(), handler);
        }

        public async Task ListenAsync(string destination, EventHandler<StompMessage> handler)
        {
            await _clientStomp.SubscribeAsync(destination, new Dictionary<string, string>(), handler);
        }

        public async Task SendAsync(object body, string destination)
        {
            await _clientStomp.SendAsync(body, destination, new Dictionary<string, string>());
        }
    }
}
