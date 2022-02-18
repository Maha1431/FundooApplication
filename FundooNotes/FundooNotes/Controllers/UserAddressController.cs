using BusinessLayer.Interface;
using CommonLayer.UserAddress;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Entities;
using RepositoryLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundooNotes.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UserAddressController : ControllerBase
    {
        IUserAddressBL userAddressBL;

        FundooNotesDbContext DbContext;

        public UserAddressController(IUserAddressBL userAddressBL, FundooNotesDbContext DbContext)
        {
            this.userAddressBL = userAddressBL;
            this.DbContext = DbContext;
        }
        [Authorize]
        [HttpPost("addUserAddress")]
        public async Task<IActionResult> AddUserAddress(UserAddressPostModel userAddress)
        {
            try
            {
                int userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "Userid").Value);
                await this.userAddressBL.AddUserAddress(userAddress, userId);

                return this.Ok(new { success = true, Message = $"UserAddress is added successfull" });
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        [Authorize]
        [HttpGet("getUserAddress")]
        public async Task<IActionResult> GetUserAddress()
        {
            try
            {
                int userid = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "Userid").Value);
                var userAddressList = new List<UserAddress>();
                userAddressList = await userAddressBL.GetUserAddresses(userid);

                return this.Ok(new { Success = true, message = $"GetAll UserAdress successfully ", data = userAddressList });

            }
            catch (Exception)
            {

                throw;
            }
        }
        [Authorize]
        [HttpPost("updateUserAddress/{AddressId}")]
        public async Task<IActionResult> UpdateUserAddress(GetUserAddressModel userAddress, int AddressId)
        {
            try
            {
                var userId = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("userId", StringComparison.InvariantCultureIgnoreCase));
                int Userid = Int32.Parse(userId.Value);

                await this.userAddressBL.UpdateUserAddress(userAddress, Userid, AddressId);
                return this.Ok(new { success = true, Message = $"Address is updated successfull" });
            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}
