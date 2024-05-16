namespace DRY;

#region Controller

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

#endregion

public class AccountController : Controller
{
    [HttpPost]
    public IActionResult AddUsername(string newUsername)
    {
        if (!IsValidUsername(newUsername))
        {
            ModelState.AddModelError(nameof(newUsername), ErrorMessages.TooShortUsername);

            return View("AddUsername");
        }

        // Add the username to the database
        // Redirect to success page

        return Redirect("/");
    }

    [HttpPost]
    public IActionResult UpdateUsername(string newUsername)
    {
        if (!IsValidUsername(newUsername))
        {
            ModelState.AddModelError(nameof(newUsername), ErrorMessages.TooShortUsername);

            return View("ChangeUsername");
        }

        // Update the username in the database
        // Redirect to success page

        return Redirect("/");
    }

    private static bool IsValidUsername(string newUsername)
    {
        return !string.IsNullOrEmpty(newUsername) && newUsername.Length >= 4;
    }


}
