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
        public IActionResult DeleteView(int id)
        {
            UserModel user = _userRepository.SearchForId(id);
            return View(user);
        }
        public IActionResult Delete(int id)
        {
            try
            {
                bool deleted = _userRepository.Delete(id);
                if (deleted)
                {
                    TempData["SucessMessage"] = "User deleted.";
                }
                else
                {
                    TempData["ErrorMessage"] = "Failed to delete this user.";
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Failed to delete this user. " + ex.Message;
                return RedirectToAction("Index");
            }
        }
        public IActionResult Edit(int id)
        {
            UserModel user = _userRepository.SearchForId(id);
            return View(user);
        }

        [HttpPost]
        public IActionResult Edit(UserNoPasswordModel userNoPasswordModel)
        {
            try
            {
                UserModel user = null;
                if (ModelState.IsValid)
                {
                    user = new UserModel()
                    {
                        Id = userNoPasswordModel.Id,
                        Name = userNoPasswordModel.Name,
                        Login = userNoPasswordModel.Login,
                        Email = userNoPasswordModel.Email,
                        Profile = userNoPasswordModel.Profile,
                    };
                   user = _userRepository.Update(user);
                    TempData["SucessMessage"] = "User's information updated.";
                    return RedirectToAction("Index");
                }
                return View(user);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Failed to update contact's information. " + ex.Message;
                return RedirectToAction("Index");
            }
        }
    }
}
