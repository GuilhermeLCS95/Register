﻿using Register.Models;

namespace Register.Repository
{
    public interface IUserRepository
    {
        UserModel LoginSearch(string login);
        UserModel SearchForId(int id);
        List<UserModel> GetAll();
        UserModel Add(UserModel user);
        UserModel Update(UserModel user);
        bool Delete(int id);
    }
}
