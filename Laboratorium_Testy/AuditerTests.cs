using AutoFixture;
using Laboratorium3.Models;
using Laboratorium4.DataBaseRepository.Interfaces;
using Laboratorium5;
using Moq;

namespace Laboratorium_Testy;

[TestClass]
public class AuditerTests
{
    private Mock<IDataBaseRepository> _repositoryMock = default!;
    private Fixture _fixture = default!;

    [TestInitialize]
    public void Initialize()
    {
        _repositoryMock = new Mock<IDataBaseRepository>();
        _fixture = new Fixture();
    }

    [TestMethod] 
    public void SaveGoldRate_ShouldSaveRateWithZeroPriceToDb()
    {
        _repositoryMock.Setup(_ => _.SaveGoldRate(It.IsAny<GoldDTO>()));
        var goldRate = _fixture.Create<GoldDTO>();
        var auditer = new Auditer(_repositoryMock.Object);

        auditer.SaveGoldRate(goldRate);

        _repositoryMock.Verify(_ => _.SaveGoldRate(It.Is<GoldDTO>(gold => gold.Price == 0.0m)), 
            Times.Once);
    }
}
