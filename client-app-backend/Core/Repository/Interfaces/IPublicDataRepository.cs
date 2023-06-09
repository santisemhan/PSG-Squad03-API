namespace client_app_backend.Core.Repository.Interfaces
{
    using client_app_backend.Core.DataTransferObject.Match.Finalized;
    using client_app_backend.Core.DataTransferObject.Match.Next;
    using client_app_backend.Core.DataTransferObject.Team.Table;
    using client_app_backend.Core.DataTransferObjects.Match.Responses;
    using client_app_backend.Core.DataTransferObjects.Team.Table.Responses;

    public interface IPublicDataRepository
    {
        Task SaveMatchesData(MatchesResponseDTO response);

        Task SaveLigue1PositionTableData(TableResponseDTO response);

        Task<List<NextMatchDTO>> GetNextMatches();

        Task<List<FinalizedMatchDTO>> GetFinalizedMatches();

        Task<List<TableTeamDTO>> GetLigue1PositionTable();
    }
}
