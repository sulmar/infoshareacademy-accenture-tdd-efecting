Console.WriteLine("Hello, Dependency Inversion Principle (DIP)!");

var phoneService = new PhoneService();
phoneService.UseRadio(new HyteraRadioAdapter());

phoneService.SendMessage(1, "Hello World!");

phoneService.UseRadio(new MotorolaRadioAdapter("1234"));
phoneService.SendMessage(1, "Hello TDD!");
