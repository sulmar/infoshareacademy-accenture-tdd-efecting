


// Concrete Adapter A
// wariant obiektowy - ponieważ zawiera adoptowany obiekt (Adaptee)
public class HyteraRadioAdapter : IRadioAdapter
{
    // Adaptee
    private readonly HyteraRadio _hyteraRadio;

    public HyteraRadioAdapter()
    {
        _hyteraRadio = new HyteraRadio();
    }

    public void Send(byte channel, string message)
    {
        _hyteraRadio.Init();
        _hyteraRadio.SendMessage(channel, message);
        _hyteraRadio.Release();
    }
}

// Concrete Adapter A
// wariant klasowy - ponieważ używa dziedziczenia

