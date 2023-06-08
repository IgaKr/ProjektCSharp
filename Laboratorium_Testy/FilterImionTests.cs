using Laboratorium4;
using Laboratorium4.DataBaseRepository.Interfaces;
using Moq;

namespace Laboratorium_Testy
{
    [TestClass]
    public class FilterImionTests
    {
        private Mock<IDataBaseRepository> _repositoryMock = default!;
        private FilterImion _filterImion = default!;

        [TestInitialize]
        public void Initialize()
        {
            _repositoryMock = new Mock<IDataBaseRepository>();
            _filterImion = new FilterImion(_repositoryMock.Object);
        }

        [TestMethod]
        public void ZwrocImionaZaczynajaceSieNaPodanaLitere_ShouldReturnEmptyCollectionWhenNoMatching()
        {
            //Arrange
            _repositoryMock.Setup(_ => _.GetAllNames())
                .Returns(new List<string>
                {
                    "WOJTEK",
                    "ADAM",
                    "BŁAZEJ"
                });
            //Act
            var actual = _filterImion.ZwrocImionaZaczynajaceSieNaPodanaLitere("G");
            //Assert
            Assert.IsFalse(actual.Any());
        }

    }
}
