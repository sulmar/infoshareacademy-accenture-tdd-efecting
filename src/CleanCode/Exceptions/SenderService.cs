using System.Net.Mail;

namespace Exceptions;

public class InvalidEmailException : Exception
{
    public InvalidEmailException(string message)
        : base(message)
    {
        
    }
}

public class MessageBodyTooLongException : Exception
{
    public int CurrentBodyLength { get; private set; }

    public MessageBodyTooLongException(string message, int currentBodyLength) 
        : base(message)
    {
        this.CurrentBodyLength = currentBodyLength;
    }
}

public class SenderService
{
    private const int MaxBodyLength = 1000;

    public void SendEmail(string recipient, string subject, string body)
    {
        if (string.IsNullOrEmpty(recipient) || !recipient.Contains("@"))
        {
            throw new InvalidEmailException("Błędny adres email");
        }

        if (body.Length > MaxBodyLength)
        {
            throw new MessageBodyTooLongException("Przekroczono rozmiar wiadomości", body.Length);
        }

        try
        {
            using (var client = new SmtpClient("smtp.example.com"))
            {
                // Konfiguracja klienta SMTP (np. ustawienia portu, poświadczenia itp.)
                client.Port = 587;
                client.Credentials = new System.Net.NetworkCredential("username", "password");
                client.EnableSsl = true;

                var mailMessage = new MailMessage("sender@example.com", recipient, subject, body);
                client.Send(mailMessage);

            }
        }
        catch (SmtpException ex)
        {
            Console.WriteLine(value: $"Problem z połączeniem SMTP: {ex.Message}");

            throw;
        }
        
    }
}
