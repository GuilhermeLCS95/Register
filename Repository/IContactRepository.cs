using Register.Models;

namespace Register.Repository
{
    public interface IContactRepository
    {
        ContactModel SearchForId(int id);
        List<ContactModel> GetAll();
        ContactModel Add(ContactModel contact);
        ContactModel Update(ContactModel contact);
    }
}
