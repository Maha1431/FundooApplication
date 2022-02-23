using CommonLayer.User;
using Experimental.System.Messaging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RepositoryLayer.Entities;
using RepositoryLayer.Interface;
using RepositoryLayer.Services;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;




namespace RepositoryLayer.Services
{
    public class UserRL : IUserRL
    {
        FundooNotesDbContext dbContext;
        private readonly IConfiguration configuration;

        public UserRL(FundooNotesDbContext dbContext)
        {
            this.dbContext = dbContext;

        }
        public List<User> GetAllUsers()
        {
            try
            {
                var result = dbContext.users
                    .Include(u => u.Addressess)
                    .Include(u => u.Notes)
                    .Include(u => u.Labels).ToList();
                 return result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void RegisterUser(UserPostModel userPostModel)
        {
            try
            {
                User user = new User();
                user.Userid = new User().Userid;
                user.firstname = userPostModel.firstname;
                user.lastname = userPostModel.lastname;
                user.phone = userPostModel.phone;
                user.adddress = userPostModel.adddress;
                user.email = userPostModel.email;
                user.password = StringCipher.Encrypt(userPostModel.password);
                user.cpassword = userPostModel.cpassword;
                user.registereddate = DateTime.Now;
                dbContext.users.Add(user);
                dbContext.SaveChanges();
              
            }
            catch (Exception e)
            {
                throw e;
            }
        }


     public string Login(UserLogin userLogin)

        {
            try
            {
                User user = new User();
                var result = dbContext.users.Where(x => x.email == userLogin.email && x.password == userLogin.password).FirstOrDefault();
                // int Id = (int)result.UserId;
                int Id = result.Userid;
                if (result != null)
                    return GenerateJWTToken(userLogin.email, Id);
                /*int id = result.Userid;
                if (result != null)
                {
                    return GenerateJWTToken(userLogin.email, id);

                }*/
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        private static string GenerateToken(string email)
        {
            if (email == null)
            {
                return null;
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes("THIS_IS_MY_KEY_TO_GENERATE_TOKEN");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("email", email),

                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials =
                new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

        }
        private string GenerateJWTToken(string email, int Userid)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes("THIS_IS_MY_KEY_TO_GENERATE_TOKEN");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("email", email),

                   new Claim("Userid",Userid.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials =
                new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

        }
        public bool ForgetPassword(string email)
        {
            try
            {
                var checkemail = dbContext.users.FirstOrDefault(e => e.email == email);
                //var checkemail = dbContex.Users.FirstOrDefault(e => e.Email == email);
                if (checkemail != null)

                {
                    MessageQueue queue;
                    //ADD MESSAGE TO QUEUE
                    if (MessageQueue.Exists(@".\Private$\FundooQueue"))
                    {
                        queue = new MessageQueue(@".\Private$\FundooQueue");
                    }
                    else
                    {
                        queue = MessageQueue.Create(@".\Private$\FundooQueue");
                    }

                    Message MyMessage = new Message();
                    MyMessage.Formatter = new BinaryMessageFormatter();
                    MyMessage.Body = GenerateJWTToken(email, checkemail.Userid);
                    MyMessage.Label = "Forget Password Email";
                    queue.Send(MyMessage);
                    Message msg = queue.Receive();
                    msg.Formatter = new BinaryMessageFormatter();
                    EmailService.SendEmail(email, msg.Body.ToString());
                    queue.ReceiveCompleted += new ReceiveCompletedEventHandler(msmqQueue_ReceiveCompleted);

                    queue.BeginReceive();
                    queue.Close();
                    return true;

                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }


            
        }

       public void ResetPassword(string email, string password, string cpassword)
        {
            try
            {

                User user = new User();
                var result = dbContext.users.FirstOrDefault(a => a.email == email);

                if (result != null)
                {
                    result.password = password;
                    result.cpassword = cpassword;
                    dbContext.SaveChanges();

                }

            }
            catch (Exception e)
            {
                throw e;
            }
        }
        private void msmqQueue_ReceiveCompleted(object sender, ReceiveCompletedEventArgs e)
        {
            try
            {
                MessageQueue queue = (MessageQueue)sender;
                Message msg = queue.EndReceive(e.AsyncResult);
                EmailService.SendEmail(e.Message.ToString(), GenerateToken(e.Message.ToString()));
                queue.BeginReceive();
            }
            catch (MessageQueueException ex)
            {
                if (ex.MessageQueueErrorCode ==
                    MessageQueueErrorCode.AccessDenied)
                {
                    Console.WriteLine("Access is denied. " +
                        "Queue might be a system queue.");
                }
              
             
            }
        }






    }
}
