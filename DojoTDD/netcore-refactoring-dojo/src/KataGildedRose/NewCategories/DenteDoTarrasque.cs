using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KataGildedRose
{
    public class DenteDoTarrasque : IValidaItens
    {
        public static int QUALIDADE => 80;
        public static String ITEM_NOME => "Dente do Tarrasque";
        public Item Produto { get; set; }
        public Item ValidarItems(IList<Item> Itens)
        {
                foreach (var item in Itens)
                {
                    if (item.Nome.Equals(ITEM_NOME))
                    {
                        item.Qualidade = QUALIDADE;
                        Produto = item;
                    }
                }
                return Produto;
        }
    }
}