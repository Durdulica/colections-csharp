using Colections;
using Colections.Common;
using System.Collections;
using System.Linq;

internal class Program
{
    static void ExYield()
    {
        static IEnumerable<string> Culori()
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
        }
    }

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
        Console.WriteLine(string.Join("|", lista.ToArray()));
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
        ListaTablou<int> numere = new();
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

    static void Pas3()
    {
        IColectie<int>[] colectii =  { new ListaInlantuita<int>(), new ListaTablou<int>() };

        foreach (IColectie<int> patrate in colectii)
        {
            for (int i = 1; i <= 5; i++)
            {
                patrate.Add(i * i);
            }
            Console.WriteLine(patrate);
            Console.WriteLine(patrate.Contains(16) + " " + patrate.Contains(15));
            int[] tablou = patrate.ToArray();
            Console.WriteLine(tablou.Length + " " + tablou[4]);
        }
    }

    static void Pas4()
    {
        StivaTablou<char> stiva = new StivaTablou<char>();
        foreach (char c in "abcde")
        {
            stiva.Push(c);
        }
        Console.WriteLine(stiva + " Varf=" + stiva.Peek());
        Console.WriteLine(stiva.Pop() + " " + stiva.Pop() + " " + stiva);

        CoadaCirculara<int> coada = new CoadaCirculara<int>();
        for (int i = 1; i <= 4; i++)
        {
            coada.Push(i * 10);
        }
        Console.WriteLine(coada + " Capacitate=" + coada.Capacity);
        Console.WriteLine(coada.Pop() + " " + coada.Pop());
        coada.Push(50);
        coada.Push(60);
        Console.WriteLine(coada + " Capacitate=" + coada.Capacity);
        coada.Remove(30);
        Console.WriteLine(coada + " Primul=" + coada.First());
        coada.Push(70);
        coada.Push(80);
        Console.WriteLine(coada + " Capacitate=" + coada.Capacity);
    }
    private static void Main()
    {
        //Pas1();
        //Pas2();
        //Pas3();
        //Pas4();
        IDictionary
    }
}