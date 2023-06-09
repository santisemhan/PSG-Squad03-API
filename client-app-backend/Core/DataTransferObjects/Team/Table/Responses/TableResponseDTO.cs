namespace client_app_backend.Core.DataTransferObjects.Team.Table.Responses
{
    using MongoDB.Bson.Serialization.Attributes;
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.IdGenerators;

    /// <summary>
    /// Represents a team in a football league.
    /// </summary>
    public class Team
    {
        /// <summary>
        /// The ID of the team.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of the team.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The short name of the team.
        /// </summary>
        public string ShortName { get; set; }

        /// <summary>
        /// The team's three-letter acronym.
        /// </summary>
        public string Tla { get; set; }

        /// <summary>
        /// The URL of the team's crest.
        /// </summary>
        public string Crest { get; set; }
    }

    /// <summary>
    /// Represents a table entry for a team in a football league standings.
    /// </summary>
    public class Table
    {
        /// <summary>
        /// The position of the team in the standings.
        /// </summary>
        public int Position { get; set; }

        /// <summary>
        /// The team associated with this table entry.
        /// </summary>
        public Team Team { get; set; }

        /// <summary>
        /// The number of games played by the team.
        /// </summary>
        public int PlayedGames { get; set; }

        /// <summary>
        /// The form of the team (e.g. WDWLW, representing the results of the team's last five matches).
        /// </summary>
        public string Form { get; set; }

        /// <summary>
        /// The number of games won by the team.
        /// </summary>
        public int Won { get; set; }

        /// <summary>
        /// The number of games drawn by the team.
        /// </summary>
        public int Draw { get; set; }

        /// <summary>
        /// The number of games lost by the team.
        /// </summary>
        public int Lost { get; set; }

        /// <summary>
        /// The number of points earned by the team.
        /// </summary>
        public int Points { get; set; }

        /// <summary>
        /// The number of goals scored by the team.
        /// </summary>
        public int GoalsFor { get; set; }

        /// <summary>
        /// The number of goals conceded by the team.
        /// </summary>
        public int GoalsAgainst { get; set; }

        /// <summary>
        /// The goal difference (GoalsFor minus GoalsAgainst) of the team.
        /// </summary>
        public int GoalDifference { get; set; }
    }

    /// <summary>
    /// Represents a competition (e.g. a football league or cup).
    /// </summary>
    public class Competition
    {
        /// <summary>
        /// The name of the competition.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The code of the competition.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// The type of the competition.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The URL of the competition's emblem.
        /// </summary>
        public string Emblem { get; set; }
    }

    public class Season
    {
        /// <summary>
        /// The start date of the season.
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// The end date of the season.
        /// </summary>
        public DateTime EndDate { get; set; }
    }


    public class Standing
    {
        /// <summary>
        /// Indicates the stage of the standing (e.g. REGULAR_SEASON, PLAYOFFS, etc.)
        /// </summary>
        public string Stage { get; set; }

        /// <summary>
        /// Indicates the type of the standing (e.g. TOTAL, HOME, AWAY, etc.)
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Indicates the group of the standing (e.g. A, B, C, etc.). Can be null if there is no group.
        /// </summary>
        public object Group { get; set; }

        /// <summary>
        /// Contains a list of teams with their respective statistics in the standing.
        /// </summary>
        public List<Table> Table { get; set; }
    }

    public class TableResponseDTO
    {
        [BsonId(IdGenerator = typeof(ObjectIdGenerator))]
        public ObjectId _id { get; set; }

        /// <summary>
        /// Contains information about the competition.
        /// </summary>
        public Competition Competition { get; set; }

        /// <summary>
        /// Contains information about the season.
        /// </summary>
        public Season Season { get; set; }

        /// <summary>
        /// Contains a list of standings with their respective statistics.
        /// </summary>
        public List<Standing> Standings { get; set; }
    }
}
