using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KataGildedRose.NewCategories
{
    public class ElixirDoMangusto : IValidaItens
    {
        private static int MAX_QUALIDADE_ITEM => 51;
        private static string ITEM_NAME => "Elixir do Mangusto";
        public Item Produto { get; set; }
        public int DecrementQualidade { get; set; } = 1;
        public int DECREMENT_ITEM_FASTEST => 2;
        public Item ValidarItems(IList<Item> Itens)
        {

            var itemsValidados = Itens.Where(i => i.Nome.Equals(ITEM_NAME) && i.Qualidade < MAX_QUALIDADE_ITEM);

            foreach (var item in itemsValidados)
            {
                if (item.PrazoParaVenda <= 0)
                {
                    DecrementQualidade = DECREMENT_ITEM_FASTEST;
                }
                if (item.Qualidade > 0)
                {
                    item.Qualidade -= DecrementQualidade;
                }
                item.PrazoParaVenda -= 1;
                Produto = item;
            }
            return Produto;
        }
    }
}