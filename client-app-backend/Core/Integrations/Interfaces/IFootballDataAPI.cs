using client_app_backend.Core.DataTransferObjects.Match.Responses;
using client_app_backend.Core.DataTransferObjects.Team.Table.Responses;

namespace client_app_backend.Core.Integrations.Interfaces
{
    public interface IFootballDataAPI
    {
        /// <summary>
        /// Get PSG matches
        /// </summary>
        Task<MatchesResponseDTO> GetMatches();

        /// <summary>
        /// Get Ligue 1 table
        /// </summary>
        Task<TableResponseDTO> GetLigue1PositionTable();
    }
}
