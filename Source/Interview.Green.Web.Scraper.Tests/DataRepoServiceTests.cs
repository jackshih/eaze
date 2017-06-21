using System;
using System.Threading.Tasks;
using Interview.Green.Web.Scrapper.Interfaces;
using Interview.Green.Web.Scrapper.Service;
using Moq;
using NUnit.Framework;

namespace Interview.Green.Web.Scrapper.Tests
{
    [TestFixture]
    public class DataRepoServiceTests
    {
        private Mock<IFileSystem> _mockFileSystem;
        private DataRepoService _mockDataRepoService;

        [SetUp]
        public void Init()
        {
            _mockFileSystem = new Mock<IFileSystem>();
            _mockDataRepoService = new DataRepoService(_mockFileSystem.Object, It.IsAny<string>(), It.IsAny<string>());
        }

        [Test]
        public void TestSave()
        {
            _mockFileSystem.Setup(s => s.WriteLineAsync(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(It.IsAny<bool>());

            var result = _mockDataRepoService.Save(It.IsAny<string>()).Result;

            _mockFileSystem.Verify(v => v.WriteLineAsync(It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(2));
            
            Assert.IsInstanceOf(typeof(Guid), result);
        }

        [Test]
        public void TestGetContent()
        {
            _mockFileSystem.Setup(s => s.ReadToEndAsync(It.IsAny<string>()))
                .ReturnsAsync(It.IsAny<string>());

            var result = _mockDataRepoService.GetContent(It.IsAny<Guid>()).Result;

            _mockFileSystem.Verify(v => v.ReadToEndAsync(It.IsAny<string>()));            
        }


    }
}
