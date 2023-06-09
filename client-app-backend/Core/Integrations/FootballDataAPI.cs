namespace client_app_backend.Core.Integrations
{
    using client_app_backend.Configuration;
    using client_app_backend.Core.DataTransferObjects.Match.Responses;
    using client_app_backend.Core.Integrations.Interfaces;
    using System.Threading.Tasks;
    using System.Text.Json;
    using client_app_backend.Core.DataTransferObjects.Team.Table.Responses;

    public class FootballDataAPI : IFootballDataAPI
    {
        private readonly HttpClient _httpClient;
        private const int PSG_ID = 524;
        private const string PSG_LEAGUE_CODE = "FL1";

        public FootballDataAPI(IHttpClientFactory clientFactory)
        {
            _httpClient = clientFactory.CreateClient(IntegrationConfiguration.FootballConnectionName);
        }

        public async Task<MatchesResponseDTO> GetMatches()
        {
            var request = await _httpClient.GetAsync($"teams/{PSG_ID}/matches");
            request.EnsureSuccessStatusCode();

            var response = await request.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var deserializedResponse = JsonSerializer.Deserialize<MatchesResponseDTO>(response, options);

            if (deserializedResponse == null || deserializedResponse.Matches == null)
                throw new Exception();

            return deserializedResponse;
        }

        public async Task<TableResponseDTO> GetLigue1PositionTable()
        {
            var request = await _httpClient.GetAsync($"competitions/{PSG_LEAGUE_CODE}/standings");
            request.EnsureSuccessStatusCode();

            var response = await request.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var deserializedResponse = JsonSerializer.Deserialize<TableResponseDTO>(response, options);

            if (deserializedResponse == null || deserializedResponse.Standings == null)
                throw new Exception();

            return deserializedResponse;
        }
    }
}
