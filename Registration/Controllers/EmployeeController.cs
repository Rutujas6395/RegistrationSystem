using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            try
            {
                res = await this._serviceLayer.RegisterEmployee(req);
            }
            catch (Exception ex)
            {
                
            }
            return Ok(res);
        }

        [HttpGet]
        [Route("Login")]
        public async Task<IActionResult> LoginEmployeeDetails(LoginReq req)
        {
            LoginRes res = null;
            try
            {
                res = await this._serviceLayer.Login(req);
            }
            catch (Exception ex)
            {

            }
            return Ok(res);
        }
    }

}
