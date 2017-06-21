using System;
using System.Web.Http.Results;
using Interview.Green.Web.Scrapper.Controllers;
using Interview.Green.Web.Scrapper.Interfaces;
using Interview.Green.Web.Scrapper.Models;
using Moq;
using NUnit.Framework;

namespace Interview.Green.Web.Scrapper.Tests
{
    [TestFixture]
    public class JobControllerTests
    {
        private Mock<IWebScrapService> _webScrapServiceMock;
        private Mock<IDataRepo> _dataRepoMock;
        private JobController _controllerMock;

        [SetUp]
        public void Init()
        {
            _webScrapServiceMock = new Mock<IWebScrapService>();
            _dataRepoMock = new Mock<IDataRepo>();
            _controllerMock = new JobController(_webScrapServiceMock.Object, _dataRepoMock.Object);
        }

        [Test]
        public void GetInvalidIdException()
        {
            _dataRepoMock
                .Setup(s => s.GetContent(It.IsAny<Guid>()))
                .Throws<IdNotFoundException>();
            
            var response = _controllerMock.Get(It.IsAny<Guid>()).Result;

            Assert.IsInstanceOf(typeof(NotFoundResult), response);
        }

        [Test]
        public void GetGeneralException()
        {
            _dataRepoMock
                .Setup(s => s.GetContent(It.IsAny<Guid>()))
                .Throws<Exception>();

            var response = _controllerMock.Get(It.IsAny<Guid>()).Result;

            Assert.IsInstanceOf(typeof(ExceptionResult), response);
        }

        [Test]
        public void GetOk()
        {
            _dataRepoMock
                .Setup(s => s.GetContent(It.IsAny<Guid>()))
                .ReturnsAsync(It.IsAny<string>);
      
            var response = _controllerMock.Get(It.IsAny<Guid>()).Result;

            Assert.IsInstanceOf(typeof(OkNegotiatedContentResult<JobResult>), response);
        }

        [Test]
        public void PostOk()
        {
            _webScrapServiceMock.Setup(s => s.Scrape(It.IsAny<string>()))
                .ReturnsAsync(It.IsAny<string>());
            _dataRepoMock.Setup(s => s.Save(It.IsAny<string>()))
                .ReturnsAsync(It.IsAny<Guid>());

            var jobRequest = new JobRequest
            {
                JobType = JobType.WebScrape,
                RequestedAt = DateTime.Now,
                RequestId = Guid.NewGuid(),
                RequestValue = "https://www.eaze.com/"
            };
            var response = _controllerMock.Post(jobRequest).Result;
            Assert.IsInstanceOf(typeof(OkNegotiatedContentResult<JobResult>), response);
        }
    }
}
