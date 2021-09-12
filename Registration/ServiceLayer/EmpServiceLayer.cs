using Registration.RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Text.RegularExpressions;
using static Registration.CommonLayer.Model.Login;
using static Registration.CommonLayer.Model.RegisterEmployee;

namespace Registration.ServiceLayer
{
    public class EmpServiceLayer :IEmpServiceLayer
    {
        public readonly IEmpRepositoryLayer _repositoryLayer;

        public EmpServiceLayer(IEmpRepositoryLayer RepositoryLayer)    //Dependency Injection /Constructor
        {
            _repositoryLayer = RepositoryLayer;
        }

        public async Task<RegisterEmployeeRes> RegisterEmployee(RegisterEmployeeReq req)
        {
            RegisterEmployeeRes res = null;
            String Email = req.Email;
            try {
               Regex regex = new Regex(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-
            9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                RegexOptions.CultureInvariant | RegexOptions.Singleline);
                if (regex.IsMatch(Email))
                {
                    res.Email = Email;
                }
            }
           catch(Exception ex) { 
           
                res.Message = "Invalid Mail-ID";
                res.IsSuccess = false;
            }
            res = await _repositoryLayer.RegisterEmployee(req);
            return res;

         }
        public async Task<LoginRes> Login(LoginReq req)
        {
            LoginRes res = null;
            res = await _repositoryLayer.Login(req);
            return res;
        }
    }
}
