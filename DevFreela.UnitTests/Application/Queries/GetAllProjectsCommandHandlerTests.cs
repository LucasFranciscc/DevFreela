using DevFreela.Application.Queries.GetAllProjects;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.UnitTests.Application.Queries
{
    public class GetAllProjectsCommandHandlerTests
    {
        [Fact]
        public async Task ThreeProjectExists_Executed_ReturnThreeProjectViewModels()
        {
            var projects = new List<Project>
            {
                new Project("Teste 1", "Descrição teste 1", 1, 2, 10000),
                new Project("Teste 2", "Descrição teste 2", 1, 2, 10000),
                new Project("Teste 3", "Descrição teste 3", 1, 2, 10000),
            };

            var projectRespositoryMock = new Mock<IProjectRepository>();
            projectRespositoryMock.Setup(pr => pr.GetAllAsync().Result).Returns(projects);

            var getAllProjectQuery = new GetAllProjectsQuery("");
            var getAllProjectsQueryHandler = new GetAllProjectsQueryHandler(projectRespositoryMock.Object);

            var projectViewModelList = await getAllProjectsQueryHandler.Handle(getAllProjectQuery, new CancellationToken());

            Assert.NotNull(projectViewModelList);
            Assert.NotEmpty(projectViewModelList);
            Assert.Equal(projects.Count, projectViewModelList.Count);

            projectRespositoryMock.Verify(pr => pr.GetAllAsync().Result, Times.Once);
        }
    }
}
