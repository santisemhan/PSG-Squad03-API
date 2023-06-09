namespace client_app_backend.Core.DataTransferObject.Match.Finalized
{
    /// <summary>
    /// DTO for the match when was finalized
    /// </summary>
    public sealed class FinalizedMatchDTO
    {
        /// <summary>
        /// Date of the match.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Name of the competition.
        /// </summary>
        public string CompetitionName { get; set; }

        /// <summary>
        /// Home team.
        /// </summary>
        public FinalizedMatchTeamDTO HomeTeam { get; set; }

        /// <summary>
        /// Away team.
        /// </summary>
        public FinalizedMatchTeamDTO AwayTeam { get; set; }
    }
}
