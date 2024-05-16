
// Abstract Adapter
// Concrete Adapter B
public class MotorolaRadioAdapter : IRadioAdapter
{
    // Adaptee
    private readonly MotorolaRadio _motorolaRadio;
    private readonly string pincode;

    public MotorolaRadioAdapter(string pincode)
    {
        _motorolaRadio = new MotorolaRadio();
        this.pincode = pincode;
    }

    public void Send(byte channel, string message)
    {
        _motorolaRadio.PowerOn(pincode);
        _motorolaRadio.SelectChannel(channel);
        _motorolaRadio.Send(message);
        _motorolaRadio.PowerOff();
    }
}
