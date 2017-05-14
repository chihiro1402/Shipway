using ShipwayBusiness.CoreProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShipwayBusiness.Entities;
using ShipwayBusiness.Repository.UnitOfWork;

namespace ShipwayBusiness.DataAccessLayer
{
    public class UserProvider : IUserProvider
    {
        public bool Delete(User user)
        {
            using( var uow= new ShipwayUnitOfWork())
            {
                return uow.UserRepository.Delete(user);
            }
        }

        public List<User> GetAllAdminAngency()
        {
            using(var uow= new ShipwayUnitOfWork())
            {
                return uow.UserRepository.FindAll(p => p.IsAdmin == true).ToList();
            }
        }

        public List<User> GetAllCustomer()
        {
            using( var uow= new ShipwayUnitOfWork())
            {
                return uow.UserRepository.FindAll(p => p.IsCustomer == true).ToList();
            }
        }

        public List<User> GetAllUser()
        {
            using(var uow= new ShipwayUnitOfWork())
            {
                return uow.UserRepository.GetAll().ToList();
            }
        }

        public User GetUserById(int id)
        {
            using( var uow= new ShipwayUnitOfWork())
            {
                return uow.UserRepository.Find(p => p.Id == id);
            }
        }

        public User GetUserByUsername(string username)
        {
            using( var uow= new ShipwayUnitOfWork())
            {
                return uow.UserRepository.Find(p => p.UserName == username);
            }
        }

        public void InsertUser(User user)
        {
            using( var uow= new ShipwayUnitOfWork())
            {
                uow.UserRepository.Add(user);
            }
        }

        public User Login(string username, string password, out User user)
        {
            using( var uow= new ShipwayUnitOfWork())
            {
                user = uow.UserRepository.Find(p => p.UserName == username);
                return uow.UserRepository.Find(p => p.UserName == username && p.Password == password);
            }
        }

        public User UpdateUser(User user)
        {
            using(var uow= new ShipwayUnitOfWork())
            {
                return uow.UserRepository.Update(user);
            }
        }


        //Customer
        public List<User> GetListCutomer()
        {
            using(var uow= new ShipwayUnitOfWork())
            {
                return uow.UserRepository.FindAll(p => p.IsCustomer == true).ToList();
            }
        }
    }
}