using System.Collections.Generic;
using System.Linq;
using ApprovalTests;
using Xunit;

namespace KataGildedRose
{
    public class GildedRoseTest
    {
        [Fact(DisplayName = "ValidaItem")]
        [Trait("Categoria", "Items")]
        public void GildedRoseTest_ValidaItem_RetornaUmBoolean()
        {
            //Arrange
           // var PREDICADO = "foo";
            IList<Item> Items = new List<Item> { new Item { Nome = "foo", PrazoParaVenda = 0, Qualidade = 0 } };
            GildedRose app = new GildedRose(Items);
            //Act
            app.AtualizarQualidade(Items);
            //Assert
             Assert.True(Items.All(a => a.Nome.Equals("foo")));
          //  Approvals.Verify(app.Items[0].Nome);
        }
    }
}