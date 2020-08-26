using System.Collections.Generic;
using Xunit;

namespace KataGildedRose.NewCategories
{
    public class QueijoBEnvelhecidoTest
    {
        public string Name { get; set; } = "Queijo Brie Envelhecido";
        public static int DIAS => 30;
        public Item Item { get; set; }


        [Fact(DisplayName = "ItemValorAcimaDoPermitido")]
        [Trait("Categoria", "Queijos")]
        public void QueijoBEnvelhecido_ItemValorAcimaDoPermitido_DevePararDeIncrementarAQualidade()
        {
            //Arrange
            var queijo = new QueijoBEnvelhecido();
            var Items = new List<Item> { new Item { Nome = Name, PrazoParaVenda = 3, Qualidade = 6 } };
            GildedRose app = new GildedRose(Items);
            //Act
            for (int i = 0; i < 1; i++)
            {
                Item = queijo.ValidarItems(Items);
            }

            //Assert
            Assert.Equal(7, Item.Qualidade);

        }


        [Fact(DisplayName = "QualidadeVaiAZeroCasoPrazoDeVendaEstejaPassado")]
        [Trait("Categoria", "Queijos")]
        public void QueijoBEnvelhecido_QualidadeVaiAZeroCasoPrazoDeVendaEstejaPassado_ZeraQualidade()
        {
            //Arrange
            var queijo = new QueijoBEnvelhecido();
            var Items = new List<Item> { new Item { Nome = Name, PrazoParaVenda = 3, Qualidade = 6 } };
            GildedRose app = new GildedRose(Items);
            //Act
            for (int i = 0; i < DIAS; i++)
            {
                Item = queijo.ValidarItems(Items);
            }
            //Assert 
            Assert.Equal(50, Item.Qualidade);

        }

        [Fact(DisplayName = "DecrementaPrazoDeVenda")]
        [Trait("Categoria", "Queijos")]
        public void QueijoBEnvelhecido_DecrementaPrazoDeVenda_ValidaPrazoVenda()
        {
            //Arrange
            var queijo = new QueijoBEnvelhecido();
            var Items = new List<Item> { new Item { Nome = Name, PrazoParaVenda = 3, Qualidade = 6 } };
            GildedRose app = new GildedRose(Items);
            //Act
            for (int i = 0; i < DIAS; i++)
            {
                Item = queijo.ValidarItems(Items);
            }
            //Assert 
            Assert.Equal(-21, Item.PrazoParaVenda);

        }
    }
}