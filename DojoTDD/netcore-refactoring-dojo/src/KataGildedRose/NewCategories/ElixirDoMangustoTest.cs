using System.Collections.Generic;
using Xunit;

namespace KataGildedRose.NewCategories
{
    public class ElixirDoMangustoTest
    {
        public static string ITEM_NAME => "Elixir do Mangusto";
        public static int DIAS => 30;
        public Item Item { get; set; }

        [Fact(DisplayName = "QualidadeLimitesPermitido")]
        [Trait("Categoria", "ElixirDoMongusto")]
        public void ElixirDoMongusto_ValidaValorMaximoEMinimoDaQualidade_DeveParardeIncrementarAQualidade()
        {
            //Arrange
            var elixirDoMongusto = new ElixirDoMangusto();
            var Items = new List<Item> { new Item { Nome = ITEM_NAME, PrazoParaVenda = 5, Qualidade = 7 } };
            GildedRose app = new GildedRose(Items);
            //Act 
            for (int i = 0; i < DIAS; i++)
            {
                Item = elixirDoMongusto.ValidarItems(Items);
            }

            //Assert
            Assert.Equal(-25, Item.PrazoParaVenda);
            Assert.Equal(0, Item.Qualidade);
        }


        [Fact(DisplayName = "QualidadeLimitePermitido")]
        [Trait("Categoria", "ElixirDoMongusto")]
        public void ElixirDoMongusto_QualidadeEPrazoDeVEnda_DeveDecrementarAQualidadeEOPrazoDeVenda()
        {
            //Arrange

            var elixirDoMongusto = new ElixirDoMangusto();
            var Items = new List<Item> { new Item { Nome = ITEM_NAME, PrazoParaVenda = 5, Qualidade = 7 } };
            GildedRose app = new GildedRose(Items);
            //Act
            for (int i = 0; i < DIAS; i++)
            {
                Item = elixirDoMongusto.ValidarItems(Items);
            }
            //Assert 
            Assert.Equal(-25, Item.Qualidade);
            Assert.Equal(0, Item.PrazoParaVenda);
        }
        [Fact(DisplayName = "QualidadeLimitePermitido")]
        [Trait("Categoria", "ElixirDoMongusto")]
        public void ElixirDoMongusto_ValidaPrazoDeVEndaPassado_DeveDecrementarQualidadeMaisRapidos()
        {
            //Arrange
            var elixirDoMongusto = new ElixirDoMangusto();
            var Items = new List<Item> { new Item { Nome = ITEM_NAME, PrazoParaVenda = -1, Qualidade = 12 } };
            GildedRose app = new GildedRose(Items);
            //Act
            for (int i = 0; i < DIAS; i++)
            {
                Item = elixirDoMongusto.ValidarItems(Items);
            }
            //Assert 
            Assert.Equal(0, Item.Qualidade);
        }
    }
}