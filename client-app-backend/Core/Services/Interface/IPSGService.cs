namespace client_app_backend.Core.Services.Interface
{
    using client_app_backend.Core.DataTransferObject.Match.Finalized;
    using client_app_backend.Core.DataTransferObject.Match.Next;
    using client_app_backend.Core.DataTransferObject.Team.Table;

    public interface IPSGService
    {
        /// <summary>
        /// Get the next matches of PSG
        /// </summary>
        Task<List<NextMatchDTO>> GetNextMatches();

        /// <summary>
        /// Get the finalized matches played by PSG
        /// </summary>
        Task<List<FinalizedMatchDTO>> GetFinalizedMatches();

        /// <summary>
        /// Get the Ligue 1 position table
        /// </summary>
        Task<List<TableTeamDTO>> GetLigue1PositionTable();
    }
}
