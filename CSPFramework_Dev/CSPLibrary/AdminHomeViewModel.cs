using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSPLibrary
{
    public class AdminHomeViewModel
    {
        public IEnumerable<CSPLibrary.RegisteredUserModel> RegisteredUserList { get; set; }
        public NewUserModel NewUserRegistrationModel { get; set; }
        
    }
}