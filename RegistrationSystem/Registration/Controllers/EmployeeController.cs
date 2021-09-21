using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Registration.CommonLayer.Exceptions;
using Registration.RepositoryLayer;
using Registration.ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Registration.CommonLayer.Model.Login;
using static Registration.CommonLayer.Model.RegisterEmployee;

namespace Registration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
       // private readonly CustomExceptions.ExceptionType _logger;
       //  private readonly IEmpRepositoryLayer _repositoryLayer;
        public readonly IEmpServiceLayer _serviceLayer;

        public EmployeeController(IEmpServiceLayer ServiceLayer)
        {  
             _serviceLayer = ServiceLayer;
         }


        [HttpPost]
        [Route("RegisterEmployee")]
        public async Task<IActionResult> RegisterEmployeeDetails(RegisterEmployeeReq req)
        {
            RegisterEmployeeRes res = null;
            bool Success = true;
            try
            {
                res = await this._serviceLayer.RegisterEmployee(req);
                if (res.IsSuccess == false)
                {
                    bool Status = false;
                    return BadRequest(new { Status });
                }
            }
            catch (Exception ex)
            {
                bool Status = false;
                return BadRequest(new { Status, Message = ex.Message });
             }
            return Ok(new { Success, Message ="Registered successfully" , data=res});
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> LoginEmployeeDetails(LoginReq req)
        {
            LoginRes res = null;
            bool LoginSuccess = true;
            try
            {
                res = await this._serviceLayer.Login(req);
                if (res.IsSuccess == false)
                {
                    bool Status = false;
                    return BadRequest(new { Status });
                }
                res = await this._serviceLayer.Login(req);
            }
            catch (Exception ex)
            {
                bool Status = false;
                return BadRequest(new { Status, Message = ex.Message });
            }
            return Ok(new { LoginSuccess, Message = "Logged In successfully", data = res });
        }
    }

}
