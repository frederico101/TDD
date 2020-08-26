using System;
using System.Collections.Generic;

namespace KataGildedRose
{
	class Program
	{
		public static void Main(string[] args)
		{
			IList<Item> itens = new List<Item>{
				new Item {Nome = "Corselete +5 DEX", PrazoParaVenda = 10, Qualidade = 20},
				new Item {Nome = "Queijo Brie Envelhecido", PrazoParaVenda = 2, Qualidade = 0},
				new Item {Nome = "Elixir do Mangusto", PrazoParaVenda = 5, Qualidade = 7},
				new Item {Nome = "Dente do Tarrasque", PrazoParaVenda = 0, Qualidade = 80},
				new Item {Nome = "Dente do Tarrasque", PrazoParaVenda = -1, Qualidade = 80},
				new Item
				{
					Nome = "Ingressos para o concerto do Turisas",
					PrazoParaVenda = 15,
					Qualidade = 20
				},
				new Item
				{
					Nome = "Ingressos para o concerto do Turisas",
					PrazoParaVenda = 10,
					Qualidade = 49
				},
				new Item
				{
					Nome = "Ingressos para o concerto do Turisas",
					PrazoParaVenda = 5,
					Qualidade = 49
				},
				// Este item conjurado ainda não funciona direto!
				new Item {Nome = "Bolo de Mana Conjurado", PrazoParaVenda = 3, Qualidade = 6}
			};

			var app = new GildedRose(itens);


			for (var i = 0; i < 31; i++)
			{
				Console.WriteLine("-------- dia " + i + " --------");
				Console.WriteLine("Nome, PrazoParaVenda, Qualidade");
				for (var j = 0; j < itens.Count; j++)
				{
					Console.WriteLine(itens[j].Nome + ", " + itens[j].PrazoParaVenda + ", " + itens[j].Qualidade);
				}
				Console.WriteLine("");
				app.AtualizarQualidade(itens);
			}
		}

	}
}
