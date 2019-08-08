using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SunLife.Web.Models
{
    public class User
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public int EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }    
        public string SecurityStamp { get; set; }
        public string PhoneNumber { get; set; }
        public int PhoneNumberConfirmed { get; set; }
        public int TwoFactorEnabled { get; set; }
        public DateTime LockoutEndDateUtc { get; set; }
        public int LockoutEnable { get; set; }
        public int AccessFailedCount { get; set; }
        public string UserName { get; set; }
        public DateTime CreateDate { get; set; }
    }
}