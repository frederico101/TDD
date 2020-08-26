using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KataGildedRose.NewCategories
{
    public class Corselete5DEX : IValidaItens
    {
        public static int MAX_QUALIDADE_ITEM => 51;
        public static int MIN_QUALIDADE_ITEM => 0;

        public static int DECREMENT_ITEM_FASTEST => 2;
        public static String ITEM_NOME => "Corselete +5 DEX";
        public Item Produto { get; set; }
        public int QualidadeDecrement { get; set; } = 1;
        public int PrazoParaVendas { get; set; } = 1;
        public Item ValidarItems(IList<Item> Itens)
        {

            var itemsValidados = Itens.Where(i => i.Nome.Equals(ITEM_NOME) && i.Qualidade < MAX_QUALIDADE_ITEM);

            foreach (var item in itemsValidados)
            {

                if (item.PrazoParaVenda <= MIN_QUALIDADE_ITEM)
                {
                    QualidadeDecrement = DECREMENT_ITEM_FASTEST;
                }
                if (item.Qualidade > MIN_QUALIDADE_ITEM)
                {
                    item.Qualidade -= QualidadeDecrement;
                }
                item.PrazoParaVenda -= PrazoParaVendas;
                Produto = item;
            }
            return Produto;
        }
    }
}