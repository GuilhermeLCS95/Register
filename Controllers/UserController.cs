using Microsoft.AspNetCore.Mvc;
using Register.Models;
using Register.Repository;

namespace Register.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public IActionResult Index()
        {
            List<UserModel> users = _userRepository.GetAll();
            return View(users);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(UserModel userModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _userRepository.Add(userModel);
                    TempData["SucessMessage"] = "User registered.";
                    return RedirectToAction("Index");
                }
                return View(userModel);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Failed to register. " + ex.Message;
                return RedirectToAction("Index");
            }
        }
    }
}
