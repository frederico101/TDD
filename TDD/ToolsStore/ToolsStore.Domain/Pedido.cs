
using System;
using System.Collections.Generic;
using System.Linq;

namespace ToolsStore.Domain
{
    public class Pedido
    {
         public int MAX_UNIDADES_ITEM => 15;

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
            if(pedidoItem.Quantidade > MAX_UNIDADES_ITEM) throw new DomainException("O maximo de item é 15 items");
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

    public class DomainException : Exception 
    { 
        public DomainException()
        {
            
        }
        public DomainException(string msg) : base(msg)
        {
            
        }
        public DomainException(string msg, Exception innerException) : base(msg, innerException)
        {
            
        }
        

    }

}
