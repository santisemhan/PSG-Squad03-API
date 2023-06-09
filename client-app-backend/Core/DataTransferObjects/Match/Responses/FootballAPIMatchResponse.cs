namespace client_app_backend.Core.DataTransferObjects.Match.Responses
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    using MongoDB.Bson.Serialization.IdGenerators;

    public class MatchesResponseDTO
    {
        [BsonId(IdGenerator = typeof(ObjectIdGenerator))]
        public ObjectId _id { get; set; }

        public List<MatchDTO> Matches { get; set; }
    }

    /// <summary>
    /// Represents the DTO for a single match.
    /// </summary>
    public class MatchDTO
    {
        /// <summary>
        /// Gets or sets the AreaDTO object representing the area of the match.
        /// </summary>
        public AreaDTO Area { get; set; }

        /// <summary>
        /// Gets or sets the CompetitionDTO object representing the competition of the match.
        /// </summary>
        public CompetitionDTO Competition { get; set; }

        /// <summary>
        /// Gets or sets the ID of the match.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the UTC date and time of the match.
        /// </summary>
        public DateTime UtcDate { get; set; }

        /// <summary>
        /// Gets or sets the status of the match.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the stage of the match.
        /// </summary>
        public string Stage { get; set; }

        /// <summary>
        /// Gets or sets the group of the match.
        /// </summary>
        public string Group { get; set; }

        /// <summary>
        /// Gets or sets the TeamDTO object representing the home team of the match.
        /// </summary>
        public TeamDTO HomeTeam { get; set; }

        /// <summary>
        /// Gets or sets the TeamDTO object representing the away team of the match.
        /// </summary>
        public TeamDTO AwayTeam { get; set; }

        /// <summary>
        /// Gets or sets the ScoreDTO object representing the score of the match.
        /// </summary>
        public ScoreDTO Score { get; set; }
    }

    public class AreaDTO
    {
        /// <summary>
        /// Gets or sets the ID of the area.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the area.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the code of the area.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the flag of the area.
        /// </summary>
        public string Flag { get; set; }
    }

    public class CompetitionDTO
    {
        /// <summary>
        /// Gets or sets the ID of the competition.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the competition.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the code of the competition.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the type of the competition.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the emblem of the competition.
        /// </summary>
        public string Emblem { get; set; }
    }

    /// <summary>
    /// Represents a DTO for a team.
    /// </summary>
    public class TeamDTO
    {
        /// <summary>
        /// Gets or sets the ID of the team.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the team.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the short name of the team.
        /// </summary>
        public string ShortName { get; set; }

        /// <summary>
        /// Gets or sets the three-letter acronym of the team.
        /// </summary>
        public string Tla { get; set; }

        /// <summary>
        /// Gets or sets the URL of the team's crest.
        /// </summary>
        public string Crest { get; set; }
    }

    /// <summary>
    /// Represents a DTO for the score of a match.
    /// </summary>
    public class ScoreDTO
    {
        /// <summary>
        /// Gets or sets the winner of the match.
        /// </summary>
        public string Winner { get; set; }

        /// <summary>
        /// Gets or sets the duration of the match.
        /// </summary>
        public string Duration { get; set; }

        /// <summary>
        /// Gets or sets the result of the match at full-time.
        /// </summary>
        public ResultDTO FullTime { get; set; }

        /// <summary>
        /// Gets or sets the result of the match at half-time.
        /// </summary>
        public ResultDTO HalfTime { get; set; }
    }

    /// <summary>
    /// Represents a DTO for the result of a match.
    /// </summary>
    public class ResultDTO
    {
        /// <summary>
        /// Gets or sets the number of goals scored by the home team.
        /// </summary>
        public int? Home { get; set; }

        /// <summary>
        /// Gets or sets the number of goals scored by the away team.
        /// </summary>
        public int? Away { get; set; }
    }
}
