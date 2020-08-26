using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KataGildedRose
{
    public class QueijoBEnvelhecido : IValidaItens
    {
        public static int MAX_QUALIDADE_ITEM => 50;
        public static String ITEM_NOME => "Queijo Brie Envelhecido";
        public Item Produto { get; set; }
        public int PrazoVendaDecrement { get; set; } = 1;
        public int qualidadeIncrement { get; set; } = 1;
        public Item ValidarItems(IList<Item> Itens)
        {

            var ItemsValidados = Itens.Where(i => i.Nome.Equals(ITEM_NOME) && i.Qualidade <= MAX_QUALIDADE_ITEM);

            foreach (var item in ItemsValidados)
            {
                if (item.PrazoParaVenda <= 0)
                {
                    qualidadeIncrement = 2;
                }
                if (item.Qualidade <  MAX_QUALIDADE_ITEM )
                {
                    item.Qualidade += qualidadeIncrement;
                }

                item.PrazoParaVenda -= PrazoVendaDecrement;

                Produto = item;
            }
            return Produto;
        }

    }

}