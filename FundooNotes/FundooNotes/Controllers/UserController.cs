using BusinessLayer.Interface;
using CommonLayer.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Interface;
using RepositoryLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;


namespace FundooNotes.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UserController : ControllerBase
    {
        IUserBL userBL;
        FundooNotesDbContext DbContext;
        public  UserController(IUserBL userBL, FundooNotesDbContext DbContext)
        {
            this.userBL = userBL;
            this.DbContext = DbContext;
        }
        [HttpGet("getallusers")]
        public ActionResult GetAllUsers()
        {
            try
            {
                var result = this.userBL.GetAllUsers();
                return this.Ok(new { success = true, message = $"Below are the User data", data = result });
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        [HttpPost("register")]
        public ActionResult  RegisterUser(UserPostModel userPostModel)
        {
            try
            {
                this.userBL.RegisterUser(userPostModel);
                return this.Ok(new {success=true, Message=$"Registration is successfull{userPostModel.email}"});
            }
            catch(Exception e)
            {
                return this.BadRequest(new { Success = false, Message = e.Message });
            }
        }
        [HttpPost("login")]
        public ActionResult Login(UserLogin userLogin)
        {
            try
            {

                var result = this.userBL.Login(userLogin);
                return this.Ok(new { success = true, Message = $"Login is Successsfull{userLogin.email}",Token=result});

            }
            catch(Exception e)
            {
                return this.BadRequest(new { Success = false, Message = e.Message });
            }
        }
        
        [HttpPost("forgetPassword")]
        public IActionResult ForgotPassword(string email)
        {
            try
            {
                //Send user data to manager

                var result = DbContext.users.FirstOrDefault(x => x.email == email);
                if (result == null)
                {
                    return this.BadRequest(new { success = false, message = "Email is not valid" });
                }
                else
                {
                     this.userBL.ForgetPassword(email);

                    return this.Ok(new { success = true, Message = $"Token sent succesfully,Please check your email" });
                }
              
            }
            catch (Exception e)
            {
                return BadRequest(new { success = false, e.Message });
            }
        }
        [Authorize]
        [HttpPut("resetpassword")]
        public ActionResult ResetPassword( string password, string cPassword)
        {
            try
            {
                if(password != cPassword)
                {
                    return this.BadRequest(new { success = false, message = "passwords are not same" });
                }
              
                var identity = User.Identity as ClaimsIdentity;
                if (identity != null)
                {
                    IEnumerable<Claim> claims = identity.Claims;
                    var UserEmailObject = claims.Where(p => p.Type == @"http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress").FirstOrDefault()?.Value;
                    if(UserEmailObject != null)
                    {
                        this.userBL.ResetPassword(UserEmailObject, password, cPassword);

                        return Ok(new { success = true, message = "Password Reset succesfully" });
                    }
                    else
                    {
                        return Ok(new { success = false, message = "Email is not Authorized" });
                    }


                }
                return this.BadRequest(new { success = false, message = "Password Reset unsuccesfully" });

            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
