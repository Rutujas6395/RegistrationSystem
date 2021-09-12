using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Registration.CommonLayer.Model.Login;
using static Registration.CommonLayer.Model.RegisterEmployee;

namespace Registration.ServiceLayer
{
    public interface IEmpServiceLayer
    {
        Task<RegisterEmployeeRes> RegisterEmployee(RegisterEmployeeReq req);
        Task<LoginRes> Login(LoginReq req);
    }
}
