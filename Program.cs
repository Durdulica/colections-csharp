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

    private static void Main()
    {
        DemoLista(new ListaInlantuita<string>());
    }
}