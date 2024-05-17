using System.Diagnostics.SymbolStore;
using static Excercise.IPrinter;

namespace Excercise.UnitTests;

public class UnitTest1
{
    IPrinter sut;

    public UnitTest1()
    {
        sut = new CostPrinterDecorator(new CounterPrinterProxy(new LegacyPrinterAdapter()));
    }

    [Fact]
    public void Test1()
    {
        sut.Print("a", 2);
        sut.Print("a", 3);

        Assert.Equal(5, sut.Counter);
    }

    [Fact]
    public void CostTest()
    {
        var sut = new CostPrinterDecorator(new FakePrinter());

        sut.Print("a", 2);

        Assert.Equal(0.2m, sut.Cost);
    }

    [Fact]
    public void CounterTest()
    {
        var sut = new CounterPrinterProxy(new FakePrinter());
        
        sut.Print("a", 2);
        sut.Print("b", 3);

        Assert.Equal(5, sut.Counter);
    }
}

// Null Object Pattern

internal class FakePrinter : IPrinter
{
    public int Counter => throw new NotImplementedException();

    public void Print(string document, int copies = 1)
    {}
}
