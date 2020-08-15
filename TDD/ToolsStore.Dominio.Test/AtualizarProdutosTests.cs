using System;
using ToolsStore.Core.DomainObjects;
using ToolsStore.Domain;
using Xunit;

namespace ToolsStore.Dominio.Test
{
    public class AtualizarProdutosTests
    {
        
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