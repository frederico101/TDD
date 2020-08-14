
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
        
        public  IReadOnlyCollection<PedidoItem> PedidoItems => _pedidoItems;
        public void AdicionarPedido(PedidoItem pedidoItem)
        {
            _pedidoItems.Add(pedidoItem);
            ValorTotal = _pedidoItems.Sum(i => i.Quantidade * i.ValorUnitario);
        }
    }
}
