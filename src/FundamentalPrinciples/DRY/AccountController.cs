namespace DRY;

public interface IActionResult { }
public class HttpPostAttribute : Attribute { }
public class ModelState {

    public void AddModelError(string error, string description) { }

}

public class Controller
{
    public ModelState ModelState { get; set; }

    public IActionResult View(string viewName) { throw new NotImplementedException();  }
    public IActionResult Redirect(string url) { throw new NotImplementedException();  }
}

public class AccountController : Controller
{
    [HttpPost]
    public IActionResult AddUsername(string newUsername)
    {
        if (string.IsNullOrEmpty(newUsername) || newUsername.Length < 4)
        {
            ModelState.AddModelError("newUsername", "Username must be at least 4 characters.");
            return View("AddUsername");
        }

        // Add the username to the database
        // Redirect to success page

        return Redirect("/");
    }

    [HttpPost]
    public IActionResult UpdateUsername(string newUsername)
    {
        if (string.IsNullOrEmpty(newUsername) || newUsername.Length < 4)
        {
            ModelState.AddModelError("newUsername", "Username must be at least 4 characters.");
            return View("ChangeUsername");
        }

        // Update the username in the database
        // Redirect to success page

        return Redirect("/");
    }

    
}
