namespace Excercise;

public partial interface IPrinter
{
    void Print(string document, int copies = 1);
    int Counter { get; }   
}

public class Printer : IPrinter
{
    public int Counter { get; private set; }

    public void Print(string document, int copies = 1)
    {
        for (int copy = 1; copy <= copies; copy++)
        {
            Console.WriteLine($"Printer is printing: {document}");
        }
    }
}