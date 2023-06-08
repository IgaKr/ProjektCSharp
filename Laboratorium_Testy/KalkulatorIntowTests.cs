using Laboratorium4.SamplesForUnits;

namespace Laboratorium_Testy
{
    [TestClass]
    public class KalkulatorIntowTests
    {
        private KalkulatorIntow _kalkulatorIntow = default!;

        [TestInitialize]
        public void Initialize()
        {
            _kalkulatorIntow = new KalkulatorIntow();
        }

        [TestMethod]
        [DataRow(2,3,5)]
        [DataRow(-2,-3,-5)]
        [DataRow(2,-3,-1)]
        public void Dodaj_Should_ReturnExpectedResult(int x1, int x2, int expected)
        {
            //Act 
            var actual = _kalkulatorIntow.Dodaj(x1, x2);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(2,3,-1)]
        [DataRow(-2,3,-5)]
        public void Odejmij_Should_ReturnExpectedResult(int x1, int x2, int expected)
        {
            //Act 
            var actual = _kalkulatorIntow.Odejmij(x1, x2);
            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
