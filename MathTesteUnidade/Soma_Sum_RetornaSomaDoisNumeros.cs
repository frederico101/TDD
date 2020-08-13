using System;
using Math;
using Xunit;

namespace MathTesteUnidade
{
    public class UnitTest1
    {
        [Fact(DisplayName="Soma")]
        [Trait("Categoria", "MathSoma")]
        public void Soma_Sum_RetornaSomaDoisNumeros()
        {
            //Arrange
            var teste = new Soma();
            //Act 
            var result = teste.Sum(2 , 6);
            //Asset
            Assert.Equal(8, result);
        }
    }
}
