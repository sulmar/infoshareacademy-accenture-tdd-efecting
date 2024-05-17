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


public interface ILogger
{
    void Log(string message);
}

public class DbPrinterProxy(IPrinter printer, ILogger logger) : IPrinter
{
    public int Counter => throw new NotImplementedException();

    public void Print(string document, int copies = 1)
    {
        // Real subject
        printer.Print(document, copies);

        logger.Log(document);
    }
}