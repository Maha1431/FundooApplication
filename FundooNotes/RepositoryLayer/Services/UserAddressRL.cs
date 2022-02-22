using CommonLayer.UserAddress;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Entities;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Services
{
    public class UserAddressRL : IUserAddressRL
    {
        FundooNotesDbContext dbContext;


        public UserAddressRL(FundooNotesDbContext dbContext)
        {
            this.dbContext = dbContext;

        }
        public async Task AddUserAddress(UserAddressPostModel userAddress, int Userid)
        {
            try
            {
                //var user = dbContext.users.FirstOrDefault(e => e.Userid == Userid);
                UserAddress address = new UserAddress();
                address.AddressId = new UserAddress().AddressId;
                address.Userid = Userid;
                address.Type = userAddress.Type;
                
                    if (address.Type == "Home")
                    {
                        address.Type = "Home";
                    }
                    else if (address.Type == "Work")
                    {
                        address.Type = "Work";
                    }
                    else
                    {
                        // address.Type != "Home" && address.Type != "Work"
                        address.Type = "Other";
                    }

                

                address.Address = userAddress.Address;
                address.City = userAddress.City;
                address.State = userAddress.State;
                dbContext.Address.Add(address);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<UserAddress>> GetUserAddresses(int Userid)
        {
            return await dbContext.Address.Where(u => u.Userid == Userid)
                .Include(u => u.User)
                .ToListAsync();
        }

        public async Task UpdateUserAddress(GetUserAddressModel userAddress, int Userid, int AddressId)
        {
            try
            {
                UserAddress useraddress = dbContext.Address.Where(e => e.Userid == Userid).FirstOrDefault();
                useraddress.Type = userAddress.Type;
                useraddress.City = userAddress.City;
                useraddress.State = userAddress.State;

                dbContext.Address.Update(useraddress);
                await dbContext.SaveChangesAsync();

            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task DeleteAddress( int AddressId)
        {
            try
            {
                UserAddress userAddress = dbContext.Address.Where(e => e.AddressId == AddressId).FirstOrDefault();
                if (userAddress.Equals(null))
                {
                    throw new Exception("No User address for this userid.");
                }

                dbContext.Address.Remove(userAddress);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }




        }

    }
}

