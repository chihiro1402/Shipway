using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShipwayBusiness.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Name { get; set; }
        public bool IsSuperAdmin { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsCustomer { get; set; }
        public string PromoCode { get; set; }
        public int? AgencyId { get; set; }
    }

    public class UserViewModel
    {
        public User User { get; set; }
        public int PermissionId { get; set; }
    }
}