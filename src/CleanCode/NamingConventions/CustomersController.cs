namespace NamingConventions;

#region ControllerBase

public interface IActionResult { }
public class HttpPostAttribute : Attribute { }
public class ModelState  
{
    public void AddModelError(string error, string description) { throw new NotImplementedException(); }
}

public enum StatusCodes { Status400BadRequest = 400 }
public class ControllerBase
{
    public ModelState ModelState { get; set; }
    public IActionResult Ok(object model) { throw new NotImplementedException(); }
    public IActionResult Problem(StatusCodes statusCode) { throw new NotImplementedException(); }
}

#endregion

public class Customer { }

public class CustomerService
{
    public Customer GetCustomer(int customerId) { throw new NotImplementedException(); }
}


public class CustomersController : ControllerBase
{
    private CustomerService _customerService;

    public CustomersController(CustomerService customerService)
    {
        _customerService = customerService;
    }

    public IActionResult GetCustomer(int customerId)
    {
        if (customerId == 68 || customerId == 421)
        {
            return Problem(statusCode: StatusCodes.Status400BadRequest);
        }

        return Ok(_customerService.GetCustomer(customerId));
    }
}
