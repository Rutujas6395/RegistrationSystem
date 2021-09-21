using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Registration.CommonLayer.Model
{
    public class RegisterEmployee
    {
        //Register new Employee
        public class RegisterEmployeeReq
        {
            public string EmployeeName { get; set; }
            public string Mobile { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public string Gender{ get; set; }
            public DateTime DoB{ get; set; }
            //public DateTime DoC { get; set; }
            public int EmployeeAge { get; set; }
            public string EmployeeType { get; set; }
            public bool IsActive { get; set; }
        }
        public class RegisterEmployeeRes
        {
            public string EmployeeName { get; set; }
            public string Mobile { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public string Gender { get; set; }
            public DateTime DoB { get; set; }
           // public DateTime DoC { get; set; }
            public string EmployeeType { get; set; }
            public int EmployeeAge { get; set; }
            public bool IsActive { get; set; }
            public bool IsSuccess { get; set; }
            public string Message { get; set; }
        }

    }
}
