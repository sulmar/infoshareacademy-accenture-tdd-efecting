Console.WriteLine("Hello, Dependency Inversion Principle (DIP)!");

var phoneService = new PhoneService();
phoneService.UseMotorolaRadio();

public class PhoneService
{
    private readonly MotorolaRadio _motorolaRadio;
    private readonly HyteraRadio _hyteraRadio;

    public PhoneService()
    {
        _motorolaRadio = new MotorolaRadio();
        _hyteraRadio = new HyteraRadio();
    }

    public void Call()
    {
        // Implementacja wykonywania połączenia telefonicznego
    }

    public void UseMotorolaRadio()
    {
        _motorolaRadio.PowerOn("1234");
        _motorolaRadio.SelectChannel(5);
        _motorolaRadio.Send("Hello from Motorola!");
        _motorolaRadio.PowerOff();
    }

    public void UseHyteraRadio()
    {
        _hyteraRadio.Init();
        _hyteraRadio.SendMessage(2, "Hello from Hytera!");
        _hyteraRadio.Release();
    }
}


public class HyteraRadio
{

    private RadioStatus status;

    public void Init()
    {
        status = RadioStatus.On;
    }

    public void SendMessage(byte channel, string content)
    {
        if (status == RadioStatus.On)
        {
            Console.WriteLine($"CHANNEL {channel}, MESSAGE {content}");
        }
    }

    public void Release()
    {
        status = RadioStatus.Off;
    }

    public enum RadioStatus
    {
        On,
        Off
    }
}

public class MotorolaRadio
{
    private bool enabled;

    private byte? selectedChannel;

    public MotorolaRadio()
    {
        enabled = false;
    }

    public void PowerOn(string pincode)
    {
        if (pincode == "1234")
        {
            enabled = true;
        }
    }

    public void SelectChannel(byte channel)
    {
        this.selectedChannel = channel;
    }

    public void Send(string message)
    {
        if (enabled && selectedChannel != null)
        {
            Console.WriteLine($"<Xml><Send Channel={selectedChannel}><Message>{message}</Message></xml>");
        }
    }

    public void PowerOff()
    {
        enabled = false;
    }



}