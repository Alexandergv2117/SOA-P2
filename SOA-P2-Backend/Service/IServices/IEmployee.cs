using Domain.Entities;
using Domain.Request;
using Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IServices
{
    public interface IEmployee
    {
        DataResponse GetAll();
        DataResponse CreateEmployee(RequestPostCreateEmployee newEmployee);
        DataResponse UpdateEmployee(RequestPutUpdateEmployee newEmployee);
        DataResponse DeleteEmployee(int idEmployee);
    }

}
