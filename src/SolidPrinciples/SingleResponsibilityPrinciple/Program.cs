

Console.WriteLine("Hello, Single Responsibility Principle (SRP)!");

class Customer
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string City { get; set; }
    public string PostCode { get; set; }
    public string Street { get; set; }
    public string Email { get; set; }

    public void ValidateEmail(string email)
    {
        if (!email.Contains("@") || !email.Contains("."))
        {
            throw new FormatException("Email address is a invalid format!");
        }
    }

    public void ValidatePostCode(string postcode)
    {
        if (postcode.Length != 5)
        {
            throw new FormatException("Post code is a invalid format!");
        }
    }
}