using System;
using System.Linq;
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

        [Fact(DisplayName="PedidosVerificaUnidades")]
        [Trait("Categoria", "Dominio")]
        public void ToolsStore_Pedido_DeveIncrementarESomarValores()
        {
            //Arrange
             var pedido = new Pedido();
            //Act
            var produtoId = Guid.NewGuid();
            var pedidoItem = new PedidoItem(produtoId,"Serra",2,100);
            pedido.AdicionarPedido(pedidoItem);
            var pedidoItem2 = new PedidoItem(produtoId,"Serra",1,100);
            pedido.AdicionarPedido(pedidoItem2);
            //Assert
            
            Assert.Equal(300, pedido.ValorTotal);
            Assert.Equal(1, pedido.PedidoItems.Count());
            Assert.Equal(3, pedido.PedidoItems.FirstOrDefault(i => i.ProdutoId == produtoId).Quantidade);

        }

    }
}
