using client_app_backend.Core.DataTransferObject.Match.Next;
using client_app_backend.Core.Services.Interface;
using client_app_backend.Core.Controllers;
using Moq;
using Microsoft.AspNetCore.Mvc;
using client_app_backend.Core.DataTransferObject.Match.Finalized;
using client_app_backend.Core.DataTransferObjects.Match.Responses;
using client_app_backend.Core.DataTransferObject.Team.Table;

namespace client_app_backend_test.Core.Controllers
{
    public class PSGControllerTest
    {
        private readonly Mock<IPSGService> _psgService;

        public PSGControllerTest()
        {
            _psgService = new Mock<IPSGService>();
        }

        [Fact]
        public async void ShouldReturnNextMatches()
        {
            _psgService
                .Setup(service => service.GetNextMatches())
                .Returns(Task.FromResult(new List<NextMatchDTO>()));

            var PSGController = new PSGController(_psgService.Object);

            var nextMatches = await PSGController.NextMatches();

            var okResult = Assert.IsType<OkObjectResult>(nextMatches);
            var returnValue = Assert.IsType<List<NextMatchDTO>>(okResult.Value);
        }

        [Fact]
        public async void ShouldReturnPlayedMatches()
        {
            _psgService
                .Setup(service => service.GetFinalizedMatches())
                .Returns(Task.FromResult(new List<FinalizedMatchDTO>()));

            var PSGController = new PSGController(_psgService.Object);

            var finalizedMatches = await PSGController.LastMatches();

            var okResult = Assert.IsType<OkObjectResult>(finalizedMatches);
            var returnValue = Assert.IsType<List<FinalizedMatchDTO>>(okResult.Value);
        }

        [Fact]
        public async void ShouldReturnLigue1TablePosition()
        {
            _psgService
               .Setup(service => service.GetLigue1PositionTable())
               .Returns(Task.FromResult(new List<TableTeamDTO>()));

            var PSGController = new PSGController(_psgService.Object);

            var ligue1PositionTable = await PSGController.Ligue1PositionTable();

            var okResult = Assert.IsType<OkObjectResult>(ligue1PositionTable);
            var returnValue = Assert.IsType<List<TableTeamDTO>>(okResult.Value);
        }
    }
}
