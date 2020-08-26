using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace KataGildedRose.NewCategories
{
    public class Corselete5DEXTest
    {
        public static string ITEM_NAME_CORSELETE_5_DEXT => "Corselete +5 DEX";
        public static int DIAS => 30;

        public Item Item { get; set; }


        [Fact(DisplayName = "QualidadeAcimaDoPermitido")]
        [Trait("Categoria", "Corselete5DEX")]
        public void Corselete5DEX_ValidaValorMaximoDaQualidade_DeveParardeIncrementarAQualidade()
        {

            //Arrange
            var corselete5DEX = new Corselete5DEX();
            var Items = new List<Item> { new Item { Nome = ITEM_NAME_CORSELETE_5_DEXT, PrazoParaVenda = 10, Qualidade = 20 } };
            GildedRose app = new GildedRose(Items);
            //Act 
            for (int i = 0; i < DIAS; i++)
            {
                Item = corselete5DEX.ValidarItems(Items);
            }
            //Assert
            Assert.Equal(-20, Item.PrazoParaVenda);
            Assert.Equal(0, Item.Qualidade);
        }


        [Fact(DisplayName = "ValidaItems")]
        [Trait("Categoria", "Corselete5DEX")]
        public void Corselete5DEX_QualidadeNegativa_DeveSairDoCondicional()
        {
            //Arrange
            var corselete5DEX = new Corselete5DEX();
            var Items = new List<Item> { new Item { Nome = ITEM_NAME_CORSELETE_5_DEXT, PrazoParaVenda = 10, Qualidade = 20 } };
            GildedRose app = new GildedRose(Items);

            //Act  
            for (int i = 0; i < DIAS; i++)
            {
                Item = corselete5DEX.ValidarItems(Items);
            }
            //Assert 
            Assert.Equal(0, Item.Qualidade);

        }


        [Fact(DisplayName = "PrazoParaVendaPassado")]
        [Trait("Categoria", "Corselete5DEX")]
        public void Corselete5DEX_PrazoParaVendaPassado_QualidadePerdeMaisValor()
        {

            var corselete5DEX = new Corselete5DEX();
            var Items = new List<Item> { new Item { Nome = ITEM_NAME_CORSELETE_5_DEXT, PrazoParaVenda = 10, Qualidade = 20 } };
            GildedRose app = new GildedRose(Items);
            //Act   
            for (int i = 0; i < DIAS; i++)
            {
                //Assert.Equal(8, Items.Where(i => i.PrazoParaVenda == -1).Sum(q => q.Qualidade -= 2));
                Item = corselete5DEX.ValidarItems(Items);
            }

            //Assert
            Assert.Equal(0, Item.Qualidade);

        }

        [Fact(DisplayName = "PrazoParaVendaEQualidadeDecrementa")]
        [Trait("Categoria", "Corselete5DEX")]
        public void Corselete5DEX_PrazoParaVendaEqualidadeDecrementa_ValidaPrazoVendaEQualidade()
        {

            var corselete5DEX = new Corselete5DEX();
            var Items = new List<Item> { new Item { Nome = ITEM_NAME_CORSELETE_5_DEXT, PrazoParaVenda = 10, Qualidade = 20 } };
            GildedRose app = new GildedRose(Items);
            //Act   
            for (int i = 0; i < DIAS; i++)
            {
                // Assert.Equal(9, Items.Sum(q => q.PrazoParaVenda -= 1));
                // Assert.Equal(9, Items.Sum(q => q.Qualidade -= 1));
                Item = corselete5DEX.ValidarItems(Items);
            }

            //Assert
            Assert.Equal(-20, Item.PrazoParaVenda);
            Assert.Equal(0, Item.Qualidade);
        }


    }
}