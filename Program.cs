using Colections;

internal class Program
{
    static void DemoLista(ILista<string> lista)
    {
        Console.WriteLine(lista + " Count=" + lista.Count);
        lista.Add("b");
        lista.Add("d");
        lista.Insert(0, "a");
        lista.Insert(2, "c");
        lista.Insert(4, "e");
        Console.WriteLine(lista + " Count=" + lista.Count);
        lista.RemoveAt(0);
        lista.RemoveAt(3);
        Console.WriteLine(lista.Remove("c") + " " + lista.Remove("x"));
        lista.Add("f");
        lista[1] = "D";
        Console.WriteLine(lista + " Count=" + lista.Count);
        Console.WriteLine(lista.IndexOf("f") + " " + lista.IndexOf("a"));
        Console.WriteLine(lista.Contains("b") + " " + lista.Contains("a"));
        foreach (string s in lista)
        {
            Console.Write(s + ";");
        }
        Console.WriteLine();
        Console.WriteLine(string.Join("|", lista.AsVector()));
        lista.Clear();
        lista.Add("z");
        Console.WriteLine(lista + " " + lista[0] + " Count=" + lista.Count);
    }

    static void Pas1()
    {
        DemoLista(new ListaInlantuita<string>());
    }

    static void Pas2()
    {
        ListaTablou<int> numere = new ListaTablou<int>();
        Console.WriteLine($"Count={numere.Count} " +
                          $"Capacitate={numere.Capacity}");
        for (int i = 1; i <= 9; i++)
        {
            numere.Add(i * 10);
            Console.WriteLine($"+{i * 10}: Count={numere.Count} " +
                              $"Capacitate={numere.Capacity}");
        }
        Console.WriteLine("---");
        DemoLista(new ListaTablou<string>());
    }

    private static void Main()
    {
        Pas2();

        /*IEnumerable<string> Culori()
        {
            Console.WriteLine("  [metoda] dau rosu");
            yield return "rosu";

            Console.WriteLine("  [metoda] dau verde");
            yield return "verde";

            Console.WriteLine("  [metoda] dau albastru");
            yield return "albastru";
        }

        foreach (string c in Culori())
        {
            Console.WriteLine("[foreach] am primit " + c);
        }*/
    }
}