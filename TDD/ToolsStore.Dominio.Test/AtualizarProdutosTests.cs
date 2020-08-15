using System;
using System.Linq;
using ToolsStore.Core.DomainObjects;
using ToolsStore.Domain;
using Xunit;

namespace ToolsStore.Dominio.Test
{
    public class AtualizarProdutosTests
    {
        
        [Fact(DisplayName = "Quantidade_Atualizar")]
        [Trait("Update", "Quantidade_Atualizar_Test")]
        public void Atualizar_AtualizarQuantidadeItems_DeveAtualizarQuantidadeItems()
        {
            //Arrange
            var produtoId = Guid.NewGuid();
            var pedido = Pedido.PedidoFactory.NovoPedidoRascunho(Guid.NewGuid());
            var pedidoItem = new PedidoItem(produtoId, "Serra", 1, 100);
            pedido.AdicionarPedido(pedidoItem);
            var pedidoItemAtualizado = new PedidoItem(produtoId, "Serra", 2, 100);
            pedido.AdicionarPedido(pedidoItemAtualizado);
            var novaQuantidade = pedidoItemAtualizado.Quantidade; 
            //Act
            pedido.AtualizarItem(pedidoItemAtualizado);
            //Assert
            Assert.Equal(novaQuantidade, pedido.PedidoItems.
            FirstOrDefault(i => i.ProdutoId == produtoId)
            .Quantidade);
        }

        [Fact(DisplayName = "AtualizarPedidoNaLista")]
        [Trait("Update", "AtualizarPedidoNaListaTest")]
        public void Atualizar_AtualizarPedidoNaLista_DeveRetornarExceptions()
        {
            //Arrange
            var produtoId = Guid.NewGuid();
            var pedido = Pedido.PedidoFactory.NovoPedidoRascunho(Guid.NewGuid());
            var pedidoAtualizado = new PedidoItem(produtoId, "Serra", 5 , 100);
            //Act && Assert;
            Assert.Throws<DomainException>(()=> pedido.AtualizarItem(pedidoAtualizado));
        }

        [Fact(DisplayName = "AtualizarPedidoNaLista")]
        [Trait("Update", "AtualizarPedidoNaListaTest")]
        public void Atualizar_AtualizarPedidoNaLista_DeveAtualizarPedido()
        {
            //Arrange
            var pedido = Pedido.PedidoFactory.NovoPedidoRascunho(Guid.NewGuid());
            var pedidoItem = new PedidoItem(Guid.NewGuid(), "Serra", 1, 100);
            //Act && Assert;
            Assert.Throws<DomainException>(()=> pedido.AtualizarItem(pedidoItem));
        }
        
    }
}