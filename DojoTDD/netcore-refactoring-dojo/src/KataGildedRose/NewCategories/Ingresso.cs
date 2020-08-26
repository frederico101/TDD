using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KataGildedRose.NewCategories
{
    public class Ingresso : IValidaItens
    {
        public static int MAX_QUALIDADE_ITEM => 50;
        public int PrazoVendaDecrement { get; set; } = 1;
        public int QualidadeIncrement { get; set; } = 1;
        public static String ITEM_NOME => "Ingressos para o concerto do Turisas";
        public Item Produto { get; set; }
        public Item ValidarItems(IList<Item> Itens)
        {

            var itemsValidados = Itens.Where(i => i.Nome.Equals(ITEM_NOME) && i.Qualidade <= MAX_QUALIDADE_ITEM);
            foreach (var item in itemsValidados)
            {

                if (item.Qualidade <= 47 && item.PrazoParaVenda <= 5 && item.PrazoParaVenda != 0)
                {
                    QualidadeIncrement = 3;
                }
                else if (item.Qualidade <= 47 && item.PrazoParaVenda <= 10 && item.PrazoParaVenda != 0)
                {
                    QualidadeIncrement = 2;
                }
                if (item.Qualidade < MAX_QUALIDADE_ITEM && item.PrazoParaVenda >= 1)
                {
                    item.Qualidade += QualidadeIncrement;
                }
                else if(item.Qualidade <= MAX_QUALIDADE_ITEM && item.PrazoParaVenda <=0)
                {
                    item.Qualidade -= item.Qualidade;
                    QualidadeIncrement -= QualidadeIncrement;
                }
                item.PrazoParaVenda -= PrazoVendaDecrement;
                Produto = item;
            }
            return Produto;
        }

    }
}