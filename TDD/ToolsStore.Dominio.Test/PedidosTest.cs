using System;
using System.Linq;
using ToolsStore.Core.DomainObjects;
using ToolsStore.Domain;
using Xunit;

namespace ToolsStore.Dominio.Test
{
    
    public class PedidosTest
    {
        [Fact(DisplayName = "NovoPedido")]
        [Trait("Categoria", "NovoPedidoTest")]
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
        [Trait("Categoria", "PedidosVerificaUnidadesTeste")]
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

        [Fact(DisplayName = "Novo item acima do permitido")]
        [Trait("Categoria", "NovoItemAcimaPermitidoTest")]
        public void AdicionarItemPedido_ItemAcima15Unidades_DeveRetornarExceptions()
        {
            //Arrange
            var produtoId = Guid.NewGuid();
            var pedido = Pedido.PedidoFactory.NovoPedidoRascunho(Guid.NewGuid());
            var pedidoItem = new PedidoItem(produtoId, "Serra", Pedido.MAX_UNIDADES_ITEM + 1 , 100);
            //Act && Assert
            Assert.Throws<DomainException>(()=>pedido.AdicionarPedido(pedidoItem));
        }

        [Fact(DisplayName = "SomaDosItemsAcimaDoPermitido")]
        [Trait("Categoria", "SomaDosItemsAcimaDoPermitidoTest")]
        public void AdicionarItemPedido_ItemsSomadosAcimaDoPermitido_DeveRetornarExceptions()
        {
            //Arrange
            var produtoId = Guid.NewGuid();
            var pedido = Pedido.PedidoFactory.NovoPedidoRascunho(Guid.NewGuid());
            var pedidoItem = new PedidoItem(produtoId, "Serra", 1 , 100);
            var pedidoItem02 = new PedidoItem(produtoId, "Serra", Pedido.MAX_UNIDADES_ITEM, 100);
            pedido.AdicionarPedido(pedidoItem);
            //Act && Assert;
            Assert.Throws<DomainException>(()=> pedido.AdicionarPedido(pedidoItem02));
        }

        [Fact(DisplayName = "AtualizarPedidoNaLista")]
        [Trait("Categoria02", "AtualizarPedidoNaListaTest")]
        public void Atualizar_AtualizarPedidoNaLista_DeveRetornarExceptions()
        {
            //Arrange
            var produtoId = Guid.NewGuid();
            var pedido = Pedido.PedidoFactory.NovoPedidoRascunho(Guid.NewGuid());
            var pedidoItem = new PedidoItem(produtoId, "Serra", 5 , 100);
            pedido.AdicionarPedido(pedidoItem);
            //Act && Assert;
            Assert.Throws<DomainException>(()=> pedido.AtualizarPedido(pedidoItem));
        }

        
    }
}