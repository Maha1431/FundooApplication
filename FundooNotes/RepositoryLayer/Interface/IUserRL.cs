using CommonLayer.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IUserRL
    {
        void RegisterUser(UserPostModel userPostModel);

        string Login(UserLogin userLogin);


        bool ForgetPassword(string email);

        void ResetPassword(string email, string password, string cpassword);
        List<User> GetAllUsers();
    }
}
