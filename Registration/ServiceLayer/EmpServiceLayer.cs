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
            RegisterEmployeeRes res = new RegisterEmployeeRes();
           
            String Email = req.Email;
            
           try {
                Regex regex = new Regex(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
                if (regex.IsMatch(Email))
                {
                    res.Email = Email;
                    Regex rg= new Regex("(0|91)?[7-9][0-9]{9}");
                    if (rg.IsMatch(req.Mobile))
                    {
                        res.Mobile = req.Mobile;
                    }
                    else {
                        res.Message = "invalid";
                        res.IsSuccess = false;
                    }
                }
                else
                {
                    res.Message = "invalid";
                    res.IsSuccess = false;
                 }

            }
            catch (Exception ex) {
                
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
