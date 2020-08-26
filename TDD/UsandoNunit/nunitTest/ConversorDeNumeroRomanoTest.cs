using MaiorEMenorTest;
using NUnit.Framework;

namespace nunitTest
{
    [TestFixture]
    public class Tests
    {
        [SetUp]
        public void Setup(){}

        [Test]
        public void ConversorDeNumeroRomanoTest_DeveRetornar_1()
        {
            var numero = new ConversorDeNumeroRomano();
            var num = numero.Converter("IX");
            Assert.AreEqual(9, num);
        }
    } 
}