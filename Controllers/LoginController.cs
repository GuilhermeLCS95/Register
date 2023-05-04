using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Register.Models;
using Register.Repository;

namespace Register.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserRepository _userRepository;
        public LoginController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UserModel user = _userRepository.LoginSearch(loginModel.Login);

                    if(user != null)
                    {
                        if (user.PasswordSearch(loginModel.Password))
                        {
                            return RedirectToAction("Index", "Home");
                        }                                         
                    }
                    TempData["ErrorMessage"] = "Login and/or password invalid. Please, try again.";
                }
                return View("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Failed to login. " + ex.Message;
                return RedirectToAction("Index");
            }
        }
    }
}
