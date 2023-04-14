using Register.Data;
using Register.Models;

namespace Register.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly DataContext _dataContext;
        public ContactRepository(DataContext dataContext)
        {
            _dataContext= dataContext;
        }
        public ContactModel Add(ContactModel contact)
        {
            _dataContext.Contacts.Add(contact);
            _dataContext.SaveChanges();
            return contact;
        }
        public ContactModel SearchForId(int id)
        {
            return _dataContext.Contacts.FirstOrDefault(x => x.Id == id);
        }
        public List<ContactModel> GetAll()
        {
            return _dataContext.Contacts.ToList();
        }

        public ContactModel Update(ContactModel contact)
        {
            ContactModel contactDB = SearchForId(contact.Id);
            if(contactDB == null) throw new System.Exception("Ops! Houve um erro.");
           
            contactDB.Name = contact.Name;
            contactDB.Email = contact.Email;
            contactDB.Phone = contact.Phone;
            _dataContext.Contacts.Update(contactDB);
            _dataContext.SaveChanges();
            return contactDB;
          
        }
    }
}
