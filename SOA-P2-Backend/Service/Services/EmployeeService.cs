using Domain.Entities;
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
    public class EmployeeService : IEmployee
    {
        private readonly ILogger<EmployeeService> _logger;
        private readonly EmployeeRepository empleoyeeRepository;

        public EmployeeService(ILogger<EmployeeService> logger, ApplicationDbContext context)
        {
            _logger = logger;
            empleoyeeRepository = new EmployeeRepository(context);
        }

        public DataResponse GetAll()
        {
            DataResponse res = new DataResponse();
            List<EmpleadoVM> empleaoyees = new List<EmpleadoVM>();

            try
            {
                empleaoyees = empleoyeeRepository.GetList();
                res.Code = 200;
                res.Data = empleaoyees;
                res.Message = "OK";
            }
            catch (Exception e) 
            {
                _logger.LogError(e.Message);
                res.Code = 500;
                res.Data = empleaoyees;
                res.Message = "Ocurrio un error, al obtener la lista de empleado";
            }

            return res;
        }

        public DataResponse CreateEmployee(RequestPostCreateEmployee requestPostCreateEmployee)
        {
            DataResponse res = new DataResponse();
            try
            {
                empleoyeeRepository.AddEmployee(requestPostCreateEmployee);
                res.Code = 200;
                res.Data = requestPostCreateEmployee;
                res.Message = "OK";
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                res.Code = 500;
                res.Data = requestPostCreateEmployee;
                res.Message = "Ocurrio un error, al crear el empleado";
            }
            return res;
        }

        public DataResponse UpdateEmployee(RequestPutUpdateEmployee requesPatchUpdateEmployee)
        {
            DataResponse res = new DataResponse();
            try
            {
                bool isUpdate = empleoyeeRepository.UpdateEmployee(requesPatchUpdateEmployee);
                if (isUpdate)
                {
                    res.Code = 200;
                    res.Data = requesPatchUpdateEmployee;
                    res.Message = "Usuario actualizado";
                } else
                {
                    res.Code = 400;
                    res.Data = requesPatchUpdateEmployee;
                    res.Message = "Ocurrion un error al actulizar el usuario";
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                res.Code = 500;
                res.Data = requesPatchUpdateEmployee;
                res.Message = "Ocurrio un error al actualizar el usuario";
            }
            return res;
        }
        public DataResponse DeleteEmployee(int idEmployee)
        {
            DataResponse res = new DataResponse();
            try
            {
                bool isDelete = empleoyeeRepository.DeleteEmployee(idEmployee);
                if (isDelete)
                {
                    res.Code = 200;
                    res.Data = idEmployee;
                    res.Message = "Usuario eliminado";
                } else
                {
                    res.Code = 400;
                    res.Data = idEmployee;
                    res.Message = "Ocurrio un error al eliminar el usuario";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                res.Code = 500;
                res.Data = idEmployee;
                res.Message = "Ocurrio un error al eliminar el usuario";

            }
            return res;
        }
    }
}
