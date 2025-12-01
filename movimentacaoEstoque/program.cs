using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
public class Root
{
    [JsonPropertyName("estoque")]
    public List<Produto> Estoque { get; set; }
}

public class Produto
{
    [JsonPropertyName("codigoProduto")]
    public int CodigoProduto { get; set; }

    [JsonPropertyName("descricaoProduto")]
    public string DescricaoProduto { get; set; }
    [JsonPropertyName("estoque")]
    public int QtdEstoque { get; set; }
}

public class Movimentacao
{
    public Guid Id { get; set; }
    public string Descricao { get; set; }
    public int Quantidade { get; set; }
}
public class program
{
    public static void Main()
    {
        string json = @"
        {
	        ""estoque"":
	        [
	          {
		        ""codigoProduto"": 101,
		        ""descricaoProduto"": ""Caneta Azul"",
		        ""estoque"": 150
	          },
	          {
		        ""codigoProduto"": 102,
		        ""descricaoProduto"": ""Caderno Universitário"",
		        ""estoque"": 75
	          },
	          {
		        ""codigoProduto"": 103,
		        ""descricaoProduto"": ""Borracha Branca"",
		        ""estoque"": 200
	          },
	          {
		        ""codigoProduto"": 104,
		        ""descricaoProduto"": ""Lápis Preto HB"",
		        ""estoque"": 320
	          },
	          {
		        ""codigoProduto"": 105,
		        ""descricaoProduto"": ""Marcador de Texto Amarelo"",
		        ""estoque"": 90
	          }
	        ]
        }";
        var root = jsonSerializer.Deserialize<Root>(json);
        Console.WriteLine("====Movimentação de estoque====");

        Console.WriteLine("informe o código do produto.");
        int cod = int.Parse(Console.ReadLine());

        var produto = root.FirstOrDefault(produto => produto.codigoProduto == cod);
        if (produto == null)
        {
            Console.WriteLine("produto não encontrado");
            return;
        }

        Console.WriteLine($"Produto econtrado:{produto.descricaoProduto}");
        Console.WriteLine($"Estoque atual:{produto.estoque}");

        Console.WriteLine("Digite E para entrada ou S para saída.");
        string tipo = Console.ReadLine().ToUpper();

        Console.WriteLine("Quantidade:");
        int qntd = int.Parse(Console.WriteLine());

        var mov = new Movimentacao
        {
            Id = Guid.NewGuid(),
            Descricao = tipo == "E" ? "Entrada de Produto" : "Saída de produto",
            Quantidade = qntd
        };

        if (tipo == "E")
        {
            produto.QtdEstoque += qntd;
        }
        else if (tipo == "S")
        {
            produto.QtdEstoque -= qntd;
        }

        Console.WriteLine($"\nMovimentação registrada:");
        Console.WriteLine($"ID: {mov.Id}");
        Console.WriteLine($"Descrição: {mov.Descricao}");
        Console.WriteLine($"Quantidade Movimentada: {mov.Quantidade}");

        Console.WriteLine($"Estoque final do produto {produto.descricaoProduto}: {produto.estoque}");


    }
}