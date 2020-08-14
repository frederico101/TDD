using System;
using ToolsStore.Domain;
using Xunit;

namespace ToolsStore.Dominio.Test
{
    public class PedidosTest
    {
        [Fact(DisplayName="Pedidos")]
        [Trait("Categoria", "Dominio")]
        public void ToolsStore_Pedido_IncluirSomarOsPedidos()
        {
            //Arrange
             var pedido = new Pedido();
            //Act
            var pedidoItem = new PedidoItem(Guid.NewGuid(),"Serra",2,50);
            pedido.AdicionarPedido(pedidoItem);
            //Assert
            Assert.Equal(100, pedido.ValorTotal);

        }
    }
}
