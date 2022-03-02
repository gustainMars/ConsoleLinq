using LINQcSharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQcSharp
{
    class Program
    {
        private static List<Categoria> categorias = new()
        {
            new Categoria { CategoriaId = 1, NomeCategoria = "Informática" },
            new Categoria { CategoriaId = 2, NomeCategoria = "Móveis" },
            new Categoria { CategoriaId = 3, NomeCategoria = "Roupa" },
        };

        private static List<Produto> produtos = new()
        {
            new Produto { Nome = "Teclado + Mouse", Preco = 500.4M, CategoriaId = 1 },
            new Produto { Nome = "Escrivaninha", Preco = 900M, CategoriaId = 2 },
            new Produto { Nome = "Cama", Preco = 1500M, CategoriaId = 2 },
            new Produto { Nome = "Camiseta preta", Preco = 500M, CategoriaId = 3 },
            new Produto { Nome = "Monitor Gaymer", Preco = 1499M, CategoriaId = 1 }
        };

        private static List<Promocao> promocoes = new()
        {
            new Promocao { CategoriaId = 1, Desconto = 10 },
            new Promocao { CategoriaId = 2, Desconto = 30 },
            new Promocao { CategoriaId = 3, Desconto = 20 },
        };

        static void Main(string[] args)
        {
            var resultado = from prods in produtos
                            join cat in categorias on prods.CategoriaId equals cat.CategoriaId
                            join desc in promocoes on prods.CategoriaId equals desc.CategoriaId
                            select new
                            {
                                prods.Nome,
                                cat.NomeCategoria,
                                prods.Preco,
                                PrecoPromocional = prods.Preco - (prods.Preco * (desc.Desconto / 100))
                            };

            foreach (var produtoCat in resultado)
                Console.WriteLine($"{produtoCat.Nome,-25} R$ {produtoCat.Preco,-15} R$ {produtoCat.PrecoPromocional,-15}{produtoCat.NomeCategoria}\n");
        }
    }
}
