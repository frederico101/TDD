using System.Collections.Generic;

namespace MaiorEMenorTest
{
    public class ConversorDeNumeroRomano
    {
        private static Dictionary<char, int> tabela = new Dictionary<char, int>() {
            {'I', 1},
            {'V', 5},
            {'X', 10},
            {'L', 50},
            {'C', 100},
            {'D', 500},
            {'M', 1000}
            };
        public int Converter(string numeroEmRomano)
        {
            int acumulador = 0;
            int ultimoVizinhoDaDireita = 0;
            for (int i = numeroEmRomano.Length - 1; i >= 0; i--)
            {
                // pega o inteiro referente ao simbolo atual
                int atual = tabela[numeroEmRomano[i]];
                // se o da direita for menor, o multiplicaremos
                // por -1 para torná-lo negativo
                int multiplicador = 1;
                if (atual < ultimoVizinhoDaDireita) multiplicador = -1;
                acumulador +=
                tabela[numeroEmRomano[i]] * multiplicador;
                // atualiza o vizinho da direita
                ultimoVizinhoDaDireita = atual;

            }
            return acumulador;
        }
    }
}