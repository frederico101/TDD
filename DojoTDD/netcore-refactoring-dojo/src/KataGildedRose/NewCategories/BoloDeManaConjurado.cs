using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KataGildedRose.NewCategories
{
    public class BoloDeManaConjurado : IValidaItens
    {
        public static int MAX_QUALIDADE_ITEM => 50;
        public static string NAME_ITEM => "Bolo de Mana Conjurado";
        public Item Produto { get; set; }
        public int DecrementaPrazoParaVenda { get; set; } = 1;
        public int DecrementaQualidade { get; set; } = 2;

        public Item ValidarItems(IList<Item> Itens)
        {
            var itemValidado = Itens.Where(i => i.Nome.Equals(NAME_ITEM) && i.Qualidade < 50);
            foreach (var item in itemValidado)
            {

                if (item.PrazoParaVenda < 0)
                {
                    DecrementaQualidade += DecrementaQualidade;
                }
                if (item.Qualidade > 0)
                {
                    item.Qualidade -= DecrementaQualidade;
                }
                item.PrazoParaVenda -= DecrementaPrazoParaVenda;
                Produto = item;
            }
            return Produto;
        }
    }
}