using CommonLayer.UserAddress;
using RepositoryLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interface
{
   public interface IUserAddressRL
    {
         Task AddUserAddress(UserAddressPostModel userAddress, int Userid);
         Task<List<UserAddress>> GetUserAddresses(int Userid);
         Task UpdateUserAddress(GetUserAddressModel userAddress, int Userid, int AddressId);
         Task DeleteAddress(int AddressId);
    }
}
