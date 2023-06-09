namespace client_app_backend.Core.DataTransferObject.Match.Next
{
    /// <summary>
    /// DTO for the team on the next match
    /// </summary>
    public sealed class NextMatchTeamDTO
    {
        /// <summary>
        /// Name of the team.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// URL of the team logo.
        /// </summary>
        public string Logo { get; set; }
    }
}
