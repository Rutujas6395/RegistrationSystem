using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;
using Registration.Helper;
using System.Data.Common;
using Microsoft.Extensions.Configuration;
using static Registration.CommonLayer.Model.RegisterEmployee;
using System.Globalization;
using static Registration.CommonLayer.Model.Login;

namespace Registration.RepositoryLayer
{
    public class EmpRepositoryLayer : IEmpRepositoryLayer
    {
        public readonly IConfiguration _configuration;
        public readonly SqlConnection sqlConnection;

        public EmpRepositoryLayer(IConfiguration configuration)
        {
            _configuration = configuration;
            var ConfigurationDatabase = this.GetDatabaseConfiguration();
            this.sqlConnection = new SqlConnection(configuration.GetSection("ConnectionStrings").GetSection("DatabaseConnectionString").Value);

        }
        private IConfigurationRoot GetDatabaseConfiguration()
        {
            var DatabaseConnectionBuilder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return DatabaseConnectionBuilder.Build();
        }
        //       Adding Employee
        public async Task<RegisterEmployeeRes> RegisterEmployee(RegisterEmployeeReq req)
        {
            RegisterEmployeeRes res = new RegisterEmployeeRes()
            {
                IsSuccess = true
            };

            try
            {
                String SqlQuery = SqlQueries.RegisterEmployee;
                SqlCommand sqlCommand = new SqlCommand(SqlQuery, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.Text;
                sqlCommand.CommandTimeout = 180;
                sqlCommand.Parameters.AddWithValue("@EmployeeName", req.EmployeeName);
                sqlCommand.Parameters.AddWithValue("@Mobile", req.Mobile);
                sqlCommand.Parameters.AddWithValue("@Email", req.Email);
                sqlCommand.Parameters.AddWithValue("@Gender", req.Gender);
                sqlCommand.Parameters.AddWithValue("@Password", req.Password);
                //sqlCommand.Parameters.AddWithValue("@DoC", req.DoC);
                sqlCommand.Parameters.AddWithValue("@DoB", req.DoB);
                sqlCommand.Parameters.AddWithValue("@EmployeeAge",  req.EmployeeAge);
                sqlCommand.Parameters.AddWithValue("@EmployeeType", req.EmployeeType);
                sqlCommand.Parameters.AddWithValue("@IsActive", (req.IsActive));
                
                sqlConnection.Open();
                int status = await sqlCommand.ExecuteNonQueryAsync();
                if (status <= 0)
                {
                    res.IsSuccess = false;
                }
                else
                {
                    res.EmployeeName = req.EmployeeName;
                    res.Email = req.Email;
                    res.Password = req.Password;
                    res.Mobile = req.Mobile;
                    res.Gender = req.Gender;
                    res.DoB = req.DoB;
                    res.EmployeeAge = req.EmployeeAge;
                    res.EmployeeType = req.EmployeeType;
                    res.IsActive = req.IsActive;
                 }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                sqlConnection.Close();
            }
            return res;
        }


        public async Task<LoginRes> Login(LoginReq req)
        {
            LoginRes res = new LoginRes()
            {
                IsSuccess = true
            };

            try
            {
                String SqlQuery = SqlQueries.Login;
                SqlCommand sqlCommand = new SqlCommand(SqlQuery, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.Text;
                sqlCommand.CommandTimeout = 180;
                sqlCommand.Parameters.AddWithValue("@Email", req.Email);
                sqlCommand.Parameters.AddWithValue("@Password", req.Password);
                sqlCommand.Parameters.AddWithValue("@EmployeeId", Convert.ToInt32(req.EmployeeId));
                sqlCommand.Parameters.AddWithValue("@IsActive", (req.IsActive));
                sqlConnection.Open();
                using (DbDataReader db = await sqlCommand.ExecuteReaderAsync())
                {
                    if (db.HasRows)
                    {
                        await db.ReadAsync();
                        res.EmployeeId = db["EmployeeId"] != DBNull.Value ? Convert.ToInt32(db["EmployeeId"]) : 0;
                        res.Email = db["Email"] != DBNull.Value ? db["Email"].ToString() : null;
                        res.Password = db["Password"] != DBNull.Value ? db["Password"].ToString() : null;
                        res.IsActive = db["IsActive"] != DBNull.Value ? Convert.ToBoolean(db["IsActive"]) : true;
 
                    }
                }

            }
            catch (Exception ex)
            {
            }
            finally
            {
                sqlConnection.Close();
            }
            return res;
        }
    }
}
