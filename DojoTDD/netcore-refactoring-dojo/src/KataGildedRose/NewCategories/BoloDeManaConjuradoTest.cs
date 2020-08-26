using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace KataGildedRose.NewCategories
{
    public class BoloDeManaConjuradoTest
    {
        public static string ITEM_NAME => "Bolo de Mana Conjurado";
        public static int DIAS => 30;
        public Item Item { get; set; }

        [Fact(DisplayName = "ValidaItemConjurado")]
        [Trait("Categoria", "Conjurados")]
        public void BoloDeManaConjuradoTest_ValidaItem_DevePararDeIncrementarQualidade()
        {
            //Assert 
            var boloDeManaConjurado = new BoloDeManaConjurado();
            var Items = new List<Item> { new Item { Nome = ITEM_NAME, PrazoParaVenda = 3, Qualidade = 6 } };
            GildedRose app = new GildedRose(Items);
            //Act
            for (int i = 0; i < DIAS; i++)
            {
                Item = boloDeManaConjurado.ValidarItems(Items);
            }
            //Assert
            Assert.Equal(0, Item.Qualidade);
        }



        [Fact(DisplayName = "DecrementaValorDeVendaEQualidadeDiario")]
        [Trait("Categoria", "Conjurados")]
        public void BoloDeManaConjuradoTest_DecrementaValorDeVendaEQualidade_ValidaPrazoParaVendaEQualidade()
        {
            //Assert 
            var boloDeManaConjurado = new BoloDeManaConjurado();
            var Items = new List<Item> { new Item { Nome = ITEM_NAME, PrazoParaVenda = 3, Qualidade = 6 } };
            GildedRose app = new GildedRose(Items);
            //Act
            for (int i = 0; i < DIAS; i++)
            {
                //Assert.Equal(2, Items.Sum(i => i.PrazoParaVenda -= 1));
                //Assert.Equal(4, Items.Sum(i => i.Qualidade -= 2));
                Item = boloDeManaConjurado.ValidarItems(Items);
            }

            //Assert
            Assert.Equal(-27, Item.PrazoParaVenda);
            Assert.Equal(0, Item.Qualidade);

        }


        [Fact(DisplayName = "ValidaPrazoDeVendaPassado")]
        [Trait("Categoria", "Conjurados")]
        public void BoloDeManaConjuradoTest_ValidaPrazoDeVendaPassado_ValidaPrazoParaVendaPassado()
        {
            //Assert 
            var boloDeManaConjurado = new BoloDeManaConjurado();
            var Items = new List<Item> { new Item { Nome = "Bolo de Mana Conjurado", PrazoParaVenda = 3, Qualidade = 6 } };
            GildedRose app = new GildedRose(Items);

            // Assert.Equal(1, Items.Where(i => i.PrazoParaVenda == -1).Sum(q => q.Qualidade -= 4 ));
            //Act
            for (int i = 0; i <= DIAS; i++)
                Item = boloDeManaConjurado.ValidarItems(Items);
            
            //Assert
            Assert.Equal(-28, Item.PrazoParaVenda);
        }


    }
}