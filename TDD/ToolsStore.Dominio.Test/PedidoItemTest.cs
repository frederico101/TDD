using System;
using ToolsStore.Core.DomainObjects;
using ToolsStore.Domain;
using Xunit;

namespace ToolsStore.Dominio.Test
{
    public class PedidoItemTest
    {
        [Fact(DisplayName = "Novo item abaixo do permitido")]
        [Trait("Categoria", "LançaException")]
        public void AdicionarItemPedido_ItemAbaixo15Unidades_DeveRetornarExceptions()
        {
            //Arrange && Act && Assert
            Assert.Throws<DomainException>(() =>  new PedidoItem(Guid.NewGuid(), "Serra", Pedido.MIN_UNIDADES_ITEM - 1, 100));
        }

    }
}