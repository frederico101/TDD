
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
        public Guid ClienteId { get; private set; }
        public decimal ValorTotal { get; private set; }
        public PedidoStatus PedidoStatus { get; private set; }


        public IReadOnlyCollection<PedidoItem> PedidoItems => _pedidoItems;
        public bool PedidoItemExistente(PedidoItem item)
        {
            var itemsExistentes = _pedidoItems.Any(p => p.ProdutoId == item.ProdutoId);
            return itemsExistentes;
        }


        public void ValidaeQuantidadeItemPermitido(PedidoItem item)
        {
            //  var quatidateItems = item.Quantidade;
            /*   if ( _pedidoItems.Any(p => p.ProdutoId == item.ProdutoId))
               {
                  var itemsExistentes = _pedidoItems.FirstOrDefault(p => p.ProdutoId == item.ProdutoId);
                  //quatidateItems += item.Quantidade;
                  // if (quatidateItems > MAX_UNIDADES_ITEM)
                   //    throw new DomainException($"Limite execedido {quatidateItems}");

                  itemsExistentes.AdicionarUnidades(item.Quantidade);
                   item = itemsExistentes;
                   _pedidoItems.Remove(itemsExistentes);
               }*/
        }

       public void CalcularValorPedido()
       {
         ValorTotal = _pedidoItems.Sum(i => i.Quantidade * i.ValorUnitario);
       }


        public void AdicionarPedido(PedidoItem item)
        {


            if (_pedidoItems.Any(p => p.ProdutoId == item.ProdutoId))
            {
                var itemsExistentes = _pedidoItems.FirstOrDefault(p => p.ProdutoId == item.ProdutoId);
                //quatidateItems += item.Quantidade;
                // if (quatidateItems > MAX_UNIDADES_ITEM)
                //    throw new DomainException($"Limite execedido {quatidateItems}");

                itemsExistentes.AdicionarUnidades(item.Quantidade);
                item = itemsExistentes;
                _pedidoItems.Remove(itemsExistentes);
            }
            
           /* ValidaeQuantidadeItemPermitido(pedidoItem);

            if (PedidoItemExistente(pedidoItem))
            {
                var quatidateItem = pedidoItem.Quantidade;
                var itemsExistentes = _pedidoItems.FirstOrDefault(p => p.ProdutoId == pedidoItem.ProdutoId);

                itemsExistentes.AdicionarUnidades(pedidoItem.Quantidade);
                pedidoItem = itemsExistentes;
                _pedidoItems.Remove(itemsExistentes);
            }
              */
           _pedidoItems.Add(item);
            
        }

        public void AtualizarItem(PedidoItem item)
        {
            ValidarPedidoExistente(item);
        }
        public void ValidarPedidoExistente(PedidoItem item)
        {
            if (!PedidoItemExistente(item)) throw new DomainException($"Item nao pertence ao Produto");
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
