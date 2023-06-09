namespace client_app_backend.Core.DataTransferObject.Match.Finalized
{
    /// <summary>
    ///  DTO for the team when the match was finalized
    /// </summary>
    public sealed class FinalizedMatchTeamDTO
    {
        /// <summary>
        /// Name of the team.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// URL of the team logo.
        /// </summary>
        public string Logo { get; set; }

        /// <summary>
        /// Number of goals scored by the team.
        /// </summary>
        public int GoalsScored { get; set; }
    }
}
