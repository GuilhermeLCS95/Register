using Microsoft.AspNetCore.Mvc;
using Register.Models;
using Register.Repository;

namespace Register.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactRepository _contactRepository;
        public ContactController(IContactRepository contactRepository) 
        { 
            _contactRepository = contactRepository;
        }
        public IActionResult Index()
        {
            List<ContactModel> contacts = _contactRepository.GetAll();
            return View(contacts);
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Edit(int id)
        {
            ContactModel contact = _contactRepository.SearchForId(id);
            return View(contact);
        }
        public IActionResult DeleteView(int id)
        {
            ContactModel contact = _contactRepository.SearchForId(id);
            return View(contact);
        }
        public IActionResult Delete(int id)
        {
            try
            {
                bool deleted = _contactRepository.Delete(id);
                if (deleted)
                {
                    TempData["SucessMessage"] = "Contact deleted.";
                }
                else
                {
                    TempData["ErrorMessage"] = "Failed to delete this contact.";
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Failed to delete this contact. " + ex.Message;
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Create(ContactModel contactModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contactRepository.Add(contactModel);
                    TempData["SucessMessage"] = "Contact registered.";
                    return RedirectToAction("Index");
                }
                return View(contactModel);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Failed to register. " + ex.Message;
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Edit(ContactModel contactModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contactRepository.Update(contactModel);
                    TempData["SucessMessage"] = "Contact's information updated.";
                    return RedirectToAction("Index");
                }
                return View(contactModel);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Failed to update contact's information. " + ex.Message;
                return RedirectToAction("Index");
            }
        }
    }
}
