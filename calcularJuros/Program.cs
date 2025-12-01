using System;
public class CalcularJuros
{
    public static void Main()
    {
        Console.WriteLine("Digite o valor da conta");
        decimal valorOriginal = decimal.Parse(Console.ReadLine());

        Console.WriteLine("Digite a data dd/mm/aaa");
        DateTime datafinal = DateTime.Parse(Console.ReadLine());

        DateTime hoje = DateTime.Today;

        if (hoje <= datafinal)
        {
            Console.WriteLine("Sua conta não está vencida. Sem juros por atraso.");
            return;
        }
        int diasAtraso = (hoje - datafinal).Days;
        decimal multaDia = 0.25m;
        decimal valorJuros = valorOriginal * multaDia * diasAtraso;
        decimal valorFinal = valorOriginal + valorJuros;

        Console.WriteLine($"\nDias de atraso: {diasAtraso}");
        Console.WriteLine($"\nValor Juros: {valorJuros}");
        Console.WriteLine($"\nValor final: {valorFinal}");

    }
}