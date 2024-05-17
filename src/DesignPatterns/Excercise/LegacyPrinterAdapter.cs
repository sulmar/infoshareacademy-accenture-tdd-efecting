namespace Excercise;

public partial interface IPrinter
{
    public class LegacyPrinterAdapter : IPrinter
    {
        public int Counter { get; private set; }

        private readonly LegacyPrinter legacyPrinter;

        public LegacyPrinterAdapter()
        {
            legacyPrinter = new LegacyPrinter();
        }

        public void Print(string document, int copies = 1)
        {
            for (int copy = 1; copy <= copies; copy++)
            {
                legacyPrinter.PrintDocument(document);
            }
        }
    }
}