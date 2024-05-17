namespace Excercise;

public interface ICostStrategy
{
    decimal Calculate(int copies);
}

public class PerCopyCostStrategy(decimal costPerCopy) : ICostStrategy
{
    public decimal Calculate(int copies) => copies * costPerCopy;
}

public partial interface IPrinter
{    
    public class CostPrinterDecorator : IPrinter
    {
        private readonly IPrinter printer;        
        private ICostStrategy costStrategy;

        public int Counter => printer.Counter;

        public decimal Cost { get; private set; }

        public CostPrinterDecorator(IPrinter printer)
            : this(printer, new PerCopyCostStrategy(0.1m))
        {
                
        }

        public CostPrinterDecorator(IPrinter printer, ICostStrategy costStrategy)
        {
            this.printer = printer;
            this.costStrategy = costStrategy;
        }

        public void Print(string document, int copies = 1)
        {
            printer.Print(document, copies);

            Cost = costStrategy.Calculate(copies);
        }
    }
}