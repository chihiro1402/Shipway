using ShipwayBusiness.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipwayBusiness.CoreProvider
{
    public interface IUserProvider
    {
        User GetUserById(int id);
        List<User> GetAllUser();
        List<User> GetAllAdminAngency();
        List<User> GetAllCustomer();
        User UpdateUser(User user);
        void InsertUser(User user);
        bool Delete(User user);
        User Login(string username, string password, out User user);
        User GetUserByUsername(string username);

        //get Customer
        List<User> GetListCutomer();

    }
}
