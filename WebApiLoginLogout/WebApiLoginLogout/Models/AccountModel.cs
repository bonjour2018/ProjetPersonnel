using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiLoginLogout.Models
{ //pour le controlleur Account pour register
    public class AccountModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string LoggedOn { get; set; }
        
    }
}