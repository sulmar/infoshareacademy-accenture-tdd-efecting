using System.Net.Mail;

namespace Exceptions;

public class SenderService
{
    private const int MaxBodyLength = 1000;

    public bool SendEmail(string recipient, string subject, string body)
    {
        if (string.IsNullOrEmpty(recipient) || !recipient.Contains("@"))
        {
            return false;           
        }

        if (body.Length > MaxBodyLength)
        {
            return false;
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

                return true;
            }
        }
        catch (SmtpException ex)
        {
            Console.WriteLine($"Problem z połączeniem SMTP: {ex.Message}");
            return false;
        }
        catch (Exception ex)
        {            
            Console.WriteLine($"Wystąpił nieoczekiwany błąd podczas wysyłania e-maila: {ex.Message}");
            return false;
        }
    }
}
