
public class PhoneService
{
    private IRadioAdapter _radio;

    public void SendMessage(byte channel, string message)
    {
        _radio.Send(channel, message);        
    }

    public void UseRadio(IRadioAdapter radioAdapter)
    {
        _radio = radioAdapter;
    }
}
