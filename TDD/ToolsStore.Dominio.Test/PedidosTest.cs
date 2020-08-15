using System;
using System.Linq;
using ToolsStore.Domain;
using Xunit;

namespace ToolsStore.Dominio.Test
{
    
    public class PedidosTest
    {
        [Fact(DisplayName = "Pedidos")]
        [Trait("Categoria", "Dominio")]
        public void AdicionarItemPedido_NovoPedido_DeveAtulizarValor()
        {
            //Arrange
            var pedido = Pedido.PedidoFactory.NovoPedidoRascunho(Guid.NewGuid());
            var pedidoItem = new PedidoItem(Guid.NewGuid(), "Serra", 2, 50);
            //Act
            pedido.AdicionarPedido(pedidoItem);
            //Assert
            Assert.Equal(100, pedido.ValorTotal);

        }

        [Fact(DisplayName = "PedidosVerificaUnidades")]
        [Trait("Categoria", "Dominio")]
        public void AdicionarItemPedido_ItemExistente_DeveIncrementarESomarValores_()
        {
            //Arrange
            var pedido = Pedido.PedidoFactory.NovoPedidoRascunho(Guid.NewGuid());
            var produtoId = Guid.NewGuid();
            var pedidoItem = new PedidoItem(produtoId, "Serra", 2, 100);
            var pedidoItem2 = new PedidoItem(produtoId, "Serra", 1, 100);
            //Act
            pedido.AdicionarPedido(pedidoItem);
            pedido.AdicionarPedido(pedidoItem2);
            //Assert

            Assert.Equal(300, pedido.ValorTotal);
            Assert.Equal(1, pedido.PedidoItems.Count());
            Assert.Equal(3, pedido.PedidoItems.FirstOrDefault(i => i.ProdutoId == produtoId).Quantidade);

        }

        [Fact(DisplayName = "LançaException")]
        [Trait("Categoria", "exception")]
        public void AdicionarItemPedido_ItemAcima15Unidades_DeveRetornarExceptions()
        {
            //Arrange
            var produtoId = Guid.NewGuid();
            var pedido = Pedido.PedidoFactory.NovoPedidoRascunho(Guid.NewGuid());
            var pedidoItem = new PedidoItem(produtoId, "Serra", 16, 100);
            //Act && Assert
            Assert.Throws<DomainException>(()=>pedido.AdicionarPedido(pedidoItem));
        }
    }
}