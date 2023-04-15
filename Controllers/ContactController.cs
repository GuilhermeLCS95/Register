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
            _contactRepository.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Create(ContactModel contactModel)
        {
            _contactRepository.Add(contactModel);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(ContactModel contactModel)
        {
            _contactRepository.Update(contactModel);
            return RedirectToAction("Index");
        }
    }
}
