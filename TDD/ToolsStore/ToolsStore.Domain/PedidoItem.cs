using System;
using ToolsStore.Core.DomainObjects;

namespace ToolsStore.Domain
{
    public class PedidoItem
    {
        public Guid ProdutoId { get; private set; }
        public string ProdutoNome { get; set; }
        public int Quantidade { get; private set; }
        public int ValorUnitario { get; private set; }

        public PedidoItem(Guid produtoId, string produtoNome, int quantidade, int valorUnitario)
        {
            if (quantidade < Pedido.MIN_UNIDADES_ITEM)
                throw new DomainException($"Limite minimo {Pedido.MIN_UNIDADES_ITEM} items");
            ProdutoId = produtoId;
            ProdutoNome = produtoNome;
            Quantidade = quantidade;
            ValorUnitario = valorUnitario; 
        }

        internal void AdicionarUnidades(int unidades)
        {
            Quantidade += unidades;
        }
        internal decimal CalcularValor()
        {
            return Quantidade * ValorUnitario;
        }
        
    }

}