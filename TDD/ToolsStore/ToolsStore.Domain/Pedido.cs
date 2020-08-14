
using System.Collections.Generic;
using System.Linq;

namespace ToolsStore.Domain
{
    public class Pedido
    {
        private readonly List<PedidoItem> _pedidoItems;
        public Pedido()
        {
            _pedidoItems = new List<PedidoItem>();
        }
        public int ValorTotal { get; private set; }


        public void CalcularValorPedido()
        {
            ValorTotal = _pedidoItems.Sum(i => i.CalcularValorPedido());
        }
        
        public  IReadOnlyCollection<PedidoItem> PedidoItems => _pedidoItems;
        public void AdicionarPedido(PedidoItem pedidoItem)
        {
              if(_pedidoItems.Any(p => p.ProdutoId == pedidoItem.ProdutoId))
              {
                  var itemsExistentes = _pedidoItems.FirstOrDefault(p => p.ProdutoId == pedidoItem.ProdutoId); 
                  itemsExistentes.AdicionarUnidades(pedidoItem.Quantidade);
                  pedidoItem = itemsExistentes;
                  _pedidoItems.Remove(itemsExistentes);
              }

            _pedidoItems.Add(pedidoItem);
            
        }
    }
}
