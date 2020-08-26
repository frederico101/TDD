using System.Collections.Generic;
using Xunit;

namespace KataGildedRose.NewCategories
{
    public class DenteDoTarrasqueTest
    {
        public static string ITEM_NAME => "Dente do Tarrasque";
        public static int DIAS => 30;

        public Item Item { get; set; }

        [Fact(DisplayName = "DenteDoTarrasqueTest")]
        [Trait("Categoria", "DenteDoTarrasqueTest")]
        public void DenteDoTarrasqueTest_ValidaAQualidade_RetornaTrue()
        {

            //Arrange
            var denteDoTarrasque = new DenteDoTarrasque();
            var Items = new List<Item> { new Item { Nome = ITEM_NAME, PrazoParaVenda = 0, Qualidade = 80 } };
            GildedRose app = new GildedRose(Items);
            //Act
            for (int i = 0; i < DIAS; i++)
            {
                Item = denteDoTarrasque.ValidarItems(Items);
            }
            //Assert 
            Assert.Equal(80, Item.Qualidade);

        }

        [Fact(DisplayName = "DenteDoTarrasqueTest")]
        [Trait("Categoria", "DenteDoTarrasqueTest")]
        public void DenteDoTarrasqueTest_ValidaItemDenteTarrasque_ValidaNomeEQualidade()
        {
            //Arrange
            var denteDoTarrasque = new DenteDoTarrasque();
            var Items = new List<Item> { new Item { Nome = ITEM_NAME, PrazoParaVenda = 0, Qualidade = 80 } };
            GildedRose app = new GildedRose(Items);
            //Act
            for (int i = 0; i < DIAS; i++)
            {
                Item = denteDoTarrasque.ValidarItems(Items);
            }
            //Assert 
            Assert.Equal(80, Item.Qualidade);

        }
    }
}