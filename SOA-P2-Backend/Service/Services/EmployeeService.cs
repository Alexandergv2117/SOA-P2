using Domain.Entities;
using Domain.Request;
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

        public List<EmpleadoVM> GetAll()
        {
            List<EmpleadoVM> empleaoyees = new List<EmpleadoVM>();

            try
            {
                empleaoyees = empleoyeeRepository.GetList();
            }
            catch (Exception e) 
            {
                _logger.LogError(e.Message);
            }

            return empleaoyees;
        }

        public string CreateEmployee(RequestPostCreateEmployee requestPostCreateEmployee)
        {
            try
            {
                empleoyeeRepository.AddEmployee(requestPostCreateEmployee);
                return "Usuario creado";
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return "Ocurrio un error al crear el usuario";
            }
        }
		public string UpdateEmployee(RequestPatchUpdateEmployee requesPatchUpdateEmployee)
        {
            try
            {
                empleoyeeRepository.UpdateEmployee(requesPatchUpdateEmployee);
                return "Usuario actualizado";
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
                return "Ocurrio un error al actualizar el usuario";
			}
        }
		public string DeleteEmployee(string idEmployee)
        {
            try
            {
                empleoyeeRepository.DeleteEmployee(idEmployee);
                return "Usuario eliminado";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return "Ocurrio un error al eliminar el usuario";

			}
        }
	}
}
