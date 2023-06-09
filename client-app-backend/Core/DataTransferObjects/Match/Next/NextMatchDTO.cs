namespace client_app_backend.Core.DataTransferObject.Match.Next
{
    /// <summary>
    /// DTO for the next match
    /// </summary>
    public sealed class NextMatchDTO
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
        public NextMatchTeamDTO HomeTeam { get; set; }

        /// <summary>
        /// Away team.
        /// </summary>
        public NextMatchTeamDTO AwayTeam { get; set; }
    }
}
