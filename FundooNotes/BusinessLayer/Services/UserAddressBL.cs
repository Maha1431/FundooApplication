using BusinessLayer.Interface;
using CommonLayer.UserAddress;
using RepositoryLayer.Entities;
using RepositoryLayer.Interface;
using RepositoryLayer.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class UserAddressBL : IUserAddressBL
    {
        IUserAddressRL userAddressRL;

        public UserAddressBL(IUserAddressRL userAddressRL)
        {
            this.userAddressRL = userAddressRL;
        }
        public async Task AddUserAddress(UserAddressPostModel userAddress, int Userid)
        {
            try
            {
                await userAddressRL.AddUserAddress(userAddress,Userid);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<UserAddress>> GetUserAddresses(int Userid)
        {
            try
            {
                return await userAddressRL.GetUserAddresses(Userid);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task UpdateUserAddress(GetUserAddressModel userAddress, int Userid, int AddressId)
        {
            try
            {
                 await userAddressRL.UpdateUserAddress(userAddress, Userid,AddressId);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
