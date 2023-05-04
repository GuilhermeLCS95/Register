using Register.Data;
using Register.Models;

namespace Register.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _dataContext;
        public UserRepository(DataContext dataContext)
        {
            _dataContext= dataContext;
        }
        public UserModel Add(UserModel user)
        {
            user.RegisterDate= DateTime.Now;
            _dataContext.Users.Add(user);
            _dataContext.SaveChanges();
            return user;
        }
        public UserModel LoginSearch(string login)
        {
            return _dataContext.Users.FirstOrDefault(x => x.Login.ToUpper() == login.ToUpper());
        }
        public UserModel SearchForId(int id)
        {
            return _dataContext.Users.FirstOrDefault(x => x.Id == id);
        }
        public List<UserModel> GetAll()
        {
            return _dataContext.Users.ToList();
        }

        public UserModel Update(UserModel user)
        {
            UserModel userDB = SearchForId(user.Id);
            if(userDB == null) throw new System.Exception("Ops! Houve um erro.");
           
            userDB.Name = user.Name;
            userDB.Login = user.Login;
            userDB.Email = user.Email;
            userDB.Profile= user.Profile;
            userDB.EditDate= DateTime.Now;
            _dataContext.Users.Update(userDB);
            _dataContext.SaveChanges();
            return userDB;
          
        }

        public bool Delete(int id)
        {
            UserModel userDB = SearchForId(id);
            if (userDB == null) throw new System.Exception("Ops! Houve um erro. Não foi possível deletar este usuário.");

            _dataContext.Users.Remove(userDB);
            _dataContext.SaveChanges();
            return true;
        }
    }
}
