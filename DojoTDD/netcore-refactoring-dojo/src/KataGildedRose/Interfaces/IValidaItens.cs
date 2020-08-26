using System.Collections.Generic;
using System.Threading.Tasks;

namespace KataGildedRose
{
    public interface IValidaItens
    {
        Item ValidarItems(IList<Item> Itens);
    }
}