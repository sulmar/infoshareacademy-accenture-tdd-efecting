namespace Excercise;

public partial interface IPrinter
{
    public class CounterPrinterProxy(IPrinter printer) : IPrinter
    {
        public int Counter { get; private set; }        

        public void Print(string document, int copies = 1)
        {
            // Real subject
            printer.Print(document, copies);

            Counter += copies;
        }
    }
}