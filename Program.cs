using Colections;

internal class Program
{
    private static void Main()
    {
        ListaInlantuita<int> lista = new ListaInlantuita<int>();

        lista.Add(1);
        lista.Add(2);
        lista.Add(3);
        lista.Insert(3, 20);
        lista.RemoveAt(3);
        Console.WriteLine(lista.Count);
    }
}