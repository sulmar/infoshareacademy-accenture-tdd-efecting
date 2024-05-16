Console.WriteLine("Hello, Dependency Inversion Principle (DIP)!");

IRadioAdapter radioAdapter = RadioAdapterFactory.Create('M');

var phoneService = new PhoneService();
phoneService.UseRadio(radioAdapter);

phoneService.SendMessage(1, "Hello World!");


class RadioAdapterFactory
{
    public static IRadioAdapter Create(char symbol)
    {
        switch(symbol)
        {
            case 'M' :  return new MotorolaRadioAdapter("1234");
            case 'H': return new HyteraRadioAdapter();
            default:
                throw new NotSupportedException();
        }
    }
    
}