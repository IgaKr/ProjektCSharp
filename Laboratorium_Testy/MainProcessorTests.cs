using AutoFixture;
using Laboratorium3.Interfaces;
using Laboratorium3.Models;
using Laboratorium5.Processor;
using Moq;

namespace Laboratorium_Testy
{
    [TestClass]
    public class MainProcessorTests
    {
        private Mock<IGoldRateWebClient> _goldClientMock = default!;
        private Fixture _fixture = default!;

        [TestInitialize]
        public void Initialize()
        {
            _goldClientMock = new Mock<IGoldRateWebClient>();
            _fixture = new Fixture();
        }

        [TestMethod]
        public void Process_ShouldGetGoldRates()
        {
            var goldDto = _fixture.Create<GoldDTO>();
            _goldClientMock.Setup(_ => _.GetLastGoldRate())
                .Returns(goldDto);
            var processor = new MainProcessor(_goldClientMock.Object);

            processor.Process();

            _goldClientMock.Verify(_ => _.GetLastGoldRate(), Times.Once);
        }

    }
}
