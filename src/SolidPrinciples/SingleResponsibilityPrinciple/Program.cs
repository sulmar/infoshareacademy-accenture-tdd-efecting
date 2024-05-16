

Console.WriteLine("Hello, Single Responsibility Principle (SRP)!");

Customer customer = new Customer();

class Customer
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Address Address { get; set; }
    public string Email { get; set; }    
}

class Address
{
    public string City { get; set; }
    public string PostCode { get; set; }
    public string Street { get; set; }
    public Location Location { get; set; }
}

struct Location
{
    public float Latitude { get; set; }
    public float Longitude { get; set; }

    public bool IsValid()
    {
        throw new NotImplementedException();
    }
}

class User
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }

}


public class EmailValidator 
{
    public void Validate(string email)
    {
        if (!email.Contains("@") || !email.Contains("."))
        {
            throw new FormatException("Email address is a invalid format!");
        }
    }
}

public class PostCodeValidator 
{
    public void Validate(string postcode)
    {
        if (postcode.Length != 5)
        {
            throw new FormatException("Post code is a invalid format!");
        }
    }
}
