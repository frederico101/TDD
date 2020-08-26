using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace KataGildedRose.NewCategories
{


    public class IngressoTest
    {
        public static string ITEM_NAME => "Ingressos para o concerto do Turisas";
        public static int DIAS => 10;
        public Item Item { get; set; }

        [Fact(DisplayName = "ValidaQualidade")]
        [Trait("Categoria", "IngressoTest")]
        public void Ingressos_ValidaQualidade_DependentoDoPrazoParaVendaIncrementaQualidade()
        {
            //Arrange
            var ingresso = new Ingresso();
            var Items = new List<Item> { new Item { Nome = ITEM_NAME, PrazoParaVenda = 6, Qualidade = 50 } };
            GildedRose app = new GildedRose(Items);
            //Act
            for (int i = 0; i <= DIAS; i++)
            {
                Item = ingresso.ValidarItems(Items);
            }

            //Assert
            Assert.Equal(0, Item.Qualidade);

        }

        [Fact(DisplayName = "ZeraQualidadeSePrazoDeVendaIgualAZero")]
        [Trait("Categoria", "IngressoTest")]
        public void Ingressos_ZeraQualidadeSePrazoDeVendaIgualAZero_ValidaQualidade()
        {
            //Arrange
            var ingresso = new Ingresso();
            var Items = new List<Item> { new Item { Nome = ITEM_NAME, PrazoParaVenda = 15, Qualidade = 20 } };
            GildedRose app = new GildedRose(Items);
            //Act
            for (int i = 1; i <= 16; i++)
            {
                Item = ingresso.ValidarItems(Items);
            }

            //Assert
            Assert.Equal(-1, Item.PrazoParaVenda);
            Assert.Equal(0, Item.Qualidade);


        }


        [Fact(DisplayName = "QualidadeAcimaDoValorPermitido")]
        [Trait("Categoria", "IngressoTest")]
        public void Ingressos_QualidadeAcimaDoValorPermitido_DeveParaDeIncrementarAQualidade()
        {
            //Arrange
            var ingresso = new Ingresso();
            var Items = new List<Item> { new Item { Nome = ITEM_NAME, PrazoParaVenda = 5, Qualidade = 49 } };
            GildedRose app = new GildedRose(Items);

            //Act
            for (int i = 0; i < DIAS; i++)
            {
                Item = ingresso.ValidarItems(Items);
            }
            //Assert
            Assert.Equal(0, Item.Qualidade);

        }
    }
}