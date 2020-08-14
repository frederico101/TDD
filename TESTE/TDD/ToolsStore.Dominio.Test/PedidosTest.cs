using System;
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
            var pedidoItem = new PedidoItem();
            var result = pedido.AddPedidoItem(); 
            //Assert
            Assert(150, result);

        }
    }
}
