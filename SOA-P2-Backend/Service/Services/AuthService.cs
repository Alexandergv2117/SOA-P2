using Domain.Request;
using Domain.Response;
using Microsoft.Extensions.Logging;
using Repository.Context;
using Repository.DAO;
using Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class AuthService : IAuth
    {
        private readonly ILogger<AuthService> _logger;
        private readonly EmployeeRepository _employeeRepository;

        public AuthService(ILogger<AuthService> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _employeeRepository = new EmployeeRepository(context);
        }

        public DataResponse ValidCredentials(RequestPostLogin user)
        {
            DataResponse res = new DataResponse();
            try
            {
                bool isValidCredentials = _employeeRepository.validCredentials(user);

                if (isValidCredentials)
                {
                    res.Code = 200;
                    res.Data = null;
                    res.Message = "Usuario y contraseña correctos";
                }
                else
                {
                    res.Code = 401;
                    res.Data = null; 
                    res.Message = "Usuario y/o contraseña incorectos";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return res;
        }
    }
}
