using System.Collections.Generic;
using MeuAcerto.Selecao.KataGildedRose.NewCategories;

namespace KataGildedRose
{
    class GildedRose
    {
        IList<Item> Itens;
        BoloDeManaConjurado _boloDeManaConjurado = new BoloDeManaConjurado();
        DenteDoTarrasque _denteDoTarrasque = new DenteDoTarrasque();

        QueijoBEnvelhecido _queijoBEnvelhecido = new QueijoBEnvelhecido();
        Ingresso _ingresso = new Ingresso();
        ElixirDoMangusto _elixirDoMangusto = new ElixirDoMangusto();
        Corselete5DEX _corselete5Dex = new Corselete5DEX();

        public GildedRose(IList<Item> Itens)
        {
            this.Itens = Itens;
        }
        public IList<Item> GetItems() => this.Itens;
        public void AtualizarQualidade(IList<Item> itens)
        {
            _ingresso.ValidarItems(itens);
            _boloDeManaConjurado.ValidarItems(itens);
            _denteDoTarrasque.ValidarItems(itens);
            _queijoBEnvelhecido.ValidarItems(itens);
            _elixirDoMangusto.ValidarItems(itens);
            _corselete5Dex.ValidarItems(itens);
        }

    }
}
