using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Registration.CommonLayer.Model
{
    public class Login
    {
        public class LoginReq
        { 
          
            public string Email { get; set; }
            public string Password { get; set; }
            public string ConfirmPassword { get; set; }


        }
        public class LoginRes
        {
            public int EmployeeId { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public bool IsActive { get; set; }
            public bool IsSuccess { get; set; }
        }
    }
}
