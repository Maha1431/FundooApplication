using CommonLayer.User;
using RepositoryLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
   public interface IUserBL
    {
        void RegisterUser(UserPostModel userPostModel);

       string Login(UserLogin userLogin);

       bool ForgetPassword(string email);

       void ResetPassword(string email, string password, string cpassword);

        List<User> GetAllUsers();
    }
}
