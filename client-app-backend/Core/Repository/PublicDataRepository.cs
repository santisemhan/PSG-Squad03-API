namespace client_app_backend.Core.Repository
{
    using client_app_backend.Core.DataTransferObject.Match.Finalized;
    using client_app_backend.Core.DataTransferObject.Match.Next;
    using client_app_backend.Core.DataTransferObject.Team.Table;
    using client_app_backend.Core.DataTransferObjects.Match.Responses;
    using client_app_backend.Core.DataTransferObjects.Team.Table.Responses;
    using client_app_backend.Core.Repository.Interfaces;
    using client_app_backend.Data.Interface;
    using MongoDB.Bson;
    using MongoDB.Driver;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class PublicDataRepository : IPublicDataRepository
    {
        private readonly IConnection<IMongoDatabase> _mongoConnection;

        public PublicDataRepository(IConnection<IMongoDatabase> mongoConnection)
        {
            _mongoConnection = mongoConnection;
        }

        public async Task<List<FinalizedMatchDTO>> GetFinalizedMatches()
        {
            var collection = _mongoConnection.GetConnection().GetCollection<MatchesResponseDTO>("PSGMatches");

            var array = new BsonDocument[]
            {
                new BsonDocument("$sort",
                    new BsonDocument("_id", -1)),
                new BsonDocument("$limit", 1),
                new BsonDocument("$unwind",
                    new BsonDocument("path", "$Matches")),
                new BsonDocument("$match",
                    new BsonDocument("Matches.UtcDate",
                        new BsonDocument("$lt", DateTime.UtcNow))),
                new BsonDocument("$group",
                    new BsonDocument
                    {
                        { "_id", "$_id" },
                        { "Matches", new BsonDocument("$push", "$Matches") }
                    })
            };


            var document = await collection
                .Aggregate<MatchesResponseDTO>(array)
                .FirstOrDefaultAsync();

            return document.Matches.Select(match => new FinalizedMatchDTO
            {
                Date = match.UtcDate,
                CompetitionName = match.Competition.Name,
                HomeTeam = new FinalizedMatchTeamDTO
                {
                    Name = match.HomeTeam.ShortName,
                    Logo = match.HomeTeam.Crest,
                    GoalsScored = match.Score.FullTime.Home.GetValueOrDefault()
                },
                AwayTeam = new FinalizedMatchTeamDTO
                {
                    Name = match.AwayTeam.ShortName,
                    Logo = match.AwayTeam.Crest,
                    GoalsScored = match.Score.FullTime.Away.GetValueOrDefault()
                }
            }).ToList();
        }

        public async Task<List<TableTeamDTO>> GetLigue1PositionTable()
        {
            var collection = _mongoConnection.GetConnection()
                .GetCollection<TableResponseDTO>("Ligue1Table");

            var array = new BsonDocument[]
            {
                new BsonDocument("$sort",
                    new BsonDocument("_id", -1)),
                new BsonDocument("$limit", 1)
            };


            var document = await collection
                .Aggregate<TableResponseDTO>(array)
                .FirstOrDefaultAsync();

            return document.Standings.First().Table.Select(table => new TableTeamDTO
            {
                Position = table.Position,
                Name = table.Team.ShortName,
                MatchesWon = table.Won,
                MatchesLost = table.Lost,
                MatchesTied = table.Draw,
                GoalsScored = table.GoalsFor,
                GoalsAgainst = table.GoalsAgainst,
                Points = table.Points,
                Logo = table.Team.Crest
            }).ToList();
        }

        public async Task<List<NextMatchDTO>> GetNextMatches()
        {
            var collection = _mongoConnection.GetConnection().GetCollection<MatchesResponseDTO>("PSGMatches");

            var array = new BsonDocument[]
            {
                new BsonDocument("$sort",
                    new BsonDocument("_id", -1)),
                new BsonDocument("$limit", 1),
                new BsonDocument("$unwind",
                    new BsonDocument("path", "$Matches")),
                new BsonDocument("$match",
                    new BsonDocument("Matches.UtcDate",
                        new BsonDocument("$gte", DateTime.UtcNow))),
                new BsonDocument("$group",
                    new BsonDocument
                    {
                        { "_id", "$_id" },
                        { "Matches", new BsonDocument("$push", "$Matches") }
                    })
            };


            var document = await collection
                .Aggregate<MatchesResponseDTO>(array)
                .FirstOrDefaultAsync();

            return document.Matches.Select(match => new NextMatchDTO
            {
                Date = match.UtcDate,
                CompetitionName = match.Competition.Name,
                HomeTeam = new NextMatchTeamDTO
                {
                    Name = match.HomeTeam.ShortName,
                    Logo = match.HomeTeam.Crest
                },
                AwayTeam = new NextMatchTeamDTO
                {
                    Name = match.AwayTeam.ShortName,
                    Logo = match.AwayTeam.Crest
                }
            }).ToList();
        }

        public async Task SaveLigue1PositionTableData(TableResponseDTO response)
        {
            await _mongoConnection.GetConnection()
               .GetCollection<TableResponseDTO>("Ligue1Table")
               .InsertOneAsync(response);
        }

        public async Task SaveMatchesData(MatchesResponseDTO response)
        {
            await _mongoConnection.GetConnection()
               .GetCollection<MatchesResponseDTO>("PSGMatches")
               .InsertOneAsync(response);
        }
    }
}
