namespace Excercise;

public partial interface IPrinter
{
    public sealed class LegacyPrinter
    {
        public void PrintDocument(string document)
        {
            Console.WriteLine($"Legacy Printer is printing: {document}");
        }
    }
}