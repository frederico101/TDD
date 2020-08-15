
using System;
using System.Collections.Generic;
using System.Linq;
using ToolsStore.Core.DomainObjects;

namespace ToolsStore.Domain
{
    public class Pedido
    {
        public static int MAX_UNIDADES_ITEM => 15;
        public static int MIN_UNIDADES_ITEM => 1;

        private readonly List<PedidoItem> _pedidoItems;
        protected Pedido()
        {
            _pedidoItems = new List<PedidoItem>();
        }
        public Guid ClienteId { get; set; }
        public decimal ValorTotal { get; private set; }
        public PedidoStatus PedidoStatus { get; private set; }


        public IReadOnlyCollection<PedidoItem> PedidoItems => _pedidoItems;
        public void AdicionarPedido(PedidoItem pedidoItem)
        {
            if (pedidoItem.Quantidade > MAX_UNIDADES_ITEM)
                throw new DomainException($"O maximo {MAX_UNIDADES_ITEM} items");
           

            if (_pedidoItems.Any(p => p.ProdutoId == pedidoItem.ProdutoId))
            {
                var itemsExistentes = _pedidoItems.FirstOrDefault(p => p.ProdutoId == pedidoItem.ProdutoId);
                itemsExistentes.AdicionarUnidades(pedidoItem.Quantidade);
                pedidoItem = itemsExistentes;
                _pedidoItems.Remove(itemsExistentes);
            }

            _pedidoItems.Add(pedidoItem);



            ValorTotal = _pedidoItems.Sum(i => i.Quantidade * i.ValorUnitario);

        }

        public void TornarRascunho()
        {
            PedidoStatus = PedidoStatus.Rascunho;

        }

        public static class PedidoFactory
        {
            public static Pedido NovoPedidoRascunho(Guid clienteId)
            {
                var pedido = new Pedido
                {
                    ClienteId = clienteId,
                };
                pedido.TornarRascunho();
                return pedido;
            }

        }

    }

    public enum PedidoStatus
    {
        Rascunho = 0,
        Iniciado = 1,
        Pago = 4,
        Entregue = 5,
        Cancelado = 6
    }

}
