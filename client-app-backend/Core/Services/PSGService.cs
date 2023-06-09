namespace client_app_backend.Core.Services
{
    using client_app_backend.Core.DataTransferObject.Match.Finalized;
    using client_app_backend.Core.DataTransferObject.Match.Next;
    using client_app_backend.Core.DataTransferObject.Team.Table;
    using client_app_backend.Core.Exceptions;
    using client_app_backend.Core.Integrations.Interfaces;
    using client_app_backend.Core.Repository.Interfaces;
    using client_app_backend.Core.Services.Interface;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;

    public class PSGService : IPSGService
    {
        private readonly IFootballDataAPI _footballDataAPI;
        private readonly IPublicDataRepository _publicDataRepository;

        public PSGService(IFootballDataAPI footballDataAPI, IPublicDataRepository publicDataRepository)
        {
            _footballDataAPI = footballDataAPI;
            _publicDataRepository = publicDataRepository;
        }

        public async Task<List<FinalizedMatchDTO>> GetFinalizedMatches()
        {
            try
            {
                var lastRefreshedData = await _footballDataAPI.GetMatches();
                await _publicDataRepository.SaveMatchesData(lastRefreshedData);
            }
            catch { }

            try
            {
                return await _publicDataRepository.GetFinalizedMatches();
            }
            catch(Exception ex)
            {
                throw new PSGClientException("No information about the last matches of PSG was found.", HttpStatusCode.NotFound);
            }
        }

        public async Task<List<NextMatchDTO>> GetNextMatches()
        {
            try
            {
                var lastRefreshedData = await _footballDataAPI.GetMatches();
                await _publicDataRepository.SaveMatchesData(lastRefreshedData);
            }
            catch { }

            try
            {
                return await _publicDataRepository.GetNextMatches();
            }
            catch
            {
                throw new PSGClientException("No information about the next matches of PSG was found.", HttpStatusCode.NotFound);
            }
        }

        public async Task<List<TableTeamDTO>> GetLigue1PositionTable()
        {
            try
            {
                var lastRefreshedData = await _footballDataAPI.GetLigue1PositionTable();
                await _publicDataRepository.SaveLigue1PositionTableData(lastRefreshedData);
            }
            catch { }

            try
            {
                return await _publicDataRepository.GetLigue1PositionTable();
            }
            catch
            {
                throw new PSGClientException("No information about the Ligue 1 table of PSG was found.", HttpStatusCode.NotFound);
            }
        }
    }
}
