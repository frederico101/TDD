using System;
using ToolsStore.Core.DomainObjects;
using ToolsStore.Domain;
using Xunit;

namespace ToolsStore.Dominio.Test
{
    public class PedidoItemTest
    {
        [Fact(DisplayName = "Novo item abaixo do permitido")]
        [Trait("Categoria", "NovoItemAbaixoPermitidoTeste")]
        public void AdicionarItemPedido_ItemAbaixoUmaUnidades_DeveRetornarExceptions()
        {
            //Arrange && Act && Assert
            Assert.Throws<DomainException>(() =>  new PedidoItem(Guid.NewGuid(), "Serra", Pedido.MIN_UNIDADES_ITEM - 1, 100));
        }

    }
}