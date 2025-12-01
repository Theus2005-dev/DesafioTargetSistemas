using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;


public class Root
{
    [JsonPropertyName("vendas")]
    public List<Venda> Vendas { get; set; }
}

public class Venda
{
    [JsonPropertyName("vendedor")]
    public string Vendedor { get; set; }

    [JsonPropertyName("valor")]
    public double Valor { get; set; }

    public double CalcularComissao()
    {
        if (Valor < 100)
            return 0;
        if (Valor < 500)
            return Valor * 0.01;

        return Valor * 0.05;

    }
}

public class Programa
{
    public static void Main()
    {
        string jsonData = @"
{
  ""vendas"": [
    { ""vendedor"": ""João Silva"", ""valor"":1200.50 },
    { ""vendedor"": ""João Silva"", ""valor"": 950.75 },
    { ""vendedor"": ""João Silva"", ""valor"": 1800.00 },
    { ""vendedor"": ""João Silva"", ""valor"": 1400.30 },
    { ""vendedor"": ""João Silva"", ""valor"": 1100.90 },
    { ""vendedor"": ""João Silva"", ""valor"": 1550.00 },
    { ""vendedor"": ""João Silva"", ""valor"": 1700.80 },
    { ""vendedor"": ""João Silva"", ""valor"": 250.30 },
    { ""vendedor"": ""João Silva"", ""valor"": 480.75 },
    { ""vendedor"": ""João Silva"", ""valor"": 320.40 },
    
    { ""vendedor"": ""Maria Souza"", ""valor"": 2100.40 },
    { ""vendedor"": ""Maria Souza"", ""valor"": 1350.60 },
    { ""vendedor"": ""Maria Souza"", ""valor"": 950.20 },
    { ""vendedor"": ""Maria Souza"", ""valor"": 1600.75 },
    { ""vendedor"": ""Maria Souza"", ""valor"": 1750.00 },
    { ""vendedor"": ""Maria Souza"", ""valor"": 1450.90 },
    { ""vendedor"": ""Maria Souza"", ""valor"": 400.50 },
    { ""vendedor"": ""Maria Souza"", ""valor"": 180.20 },
    { ""vendedor"": ""Maria Souza"", ""valor"": 90.75 },
    
    { ""vendedor"": ""Carlos Oliveira"", ""valor"": 800.50 },
    { ""vendedor"": ""Carlos Oliveira"", ""valor"": 1200.00 },
    { ""vendedor"": ""Carlos Oliveira"", ""valor"": 1950.30 },
    { ""vendedor"": ""Carlos Oliveira"", ""valor"": 1750.80 },
    { ""vendedor"": ""Carlos Oliveira"", ""valor"": 1300.60 },
    { ""vendedor"": ""Carlos Oliveira"", ""valor"": 300.40 },
    { ""vendedor"": ""Carlos Oliveira"", ""valor"": 500.00 },
    { ""vendedor"": ""Carlos Oliveira"", ""valor"": 125.75 },
    
    { ""vendedor"": ""Ana Lima"", ""valor"": 1000.00 },
    { ""vendedor"": ""Ana Lima"", ""valor"": 1100.50 },
    { ""vendedor"": ""Ana Lima"", ""valor"": 1250.75 },
    { ""vendedor"": ""Ana Lima"", ""valor"": 1400.20 },
    { ""vendedor"": ""Ana Lima"", ""valor"": 1550.90 },
    { ""vendedor"": ""Ana Lima"", ""valor"": 1650.00 },
    { ""vendedor"": ""Ana Lima"", ""valor"": 75.30 },
    { ""vendedor"": ""Ana Lima"", ""valor"": 420.90 },
    { ""vendedor"": ""Ana Lima"", ""valor"": 315.40 }
  ]
}
";
        Root dados = JsonSerializer.Deserialize<Root>(jsonData);

        if (dados == null || dados.Vendas == null)
        {
            Console.WriteLine("Dados nulos");
            return;
        }

        var comissaoPorVendedor = dados.Vendas
            .GroupBy(v => v.Vendedor)
            .Select(g => new
            {
                Vendedor = g.Key,
                TotalComissao = g.Sum(v => v.CalcularComissao())
            }
                   );
        Console.WriteLine("\n =====Total por vendedor=====");

        foreach (var item in comissaoPorVendedor)
        {
            Console.WriteLine($"{item.Vendedor}: {item.TotalComissao:C2}");
        }

    }
}
