namespace client_app_backend.Core.DataTransferObject.Team.Table
{
    /// <summary>
    /// DTO for the team that was part of a position table
    /// </summary>
    public sealed class TableTeamDTO
    {
        /// <summary>
        /// Name of the team.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Logo of the team.
        /// </summary>
        public string Logo { get; set; }

        /// <summary>
        /// Number of matches won by the team.
        /// </summary>
        public int MatchesWon { get; set; }

        /// <summary>
        /// Number of matches tied by the team.
        /// </summary>
        public int MatchesTied { get; set; }

        /// <summary>
        /// Number of matches lost by the team.
        /// </summary>
        public int MatchesLost { get; set; }

        /// <summary>
        /// Number of goals scored by the team.
        /// </summary>
        public int GoalsScored { get; set; }

        /// <summary>
        /// Number of goals conceded by the team.
        /// </summary>
        public int GoalsAgainst { get; set; }

        /// <summary>
        /// Total number of points earned by the team.
        /// </summary>
        public int Points { get; set; }

        /// <summary>
        /// Position in the table
        /// </summary>
        public int Position { get; set; }
    }
}
