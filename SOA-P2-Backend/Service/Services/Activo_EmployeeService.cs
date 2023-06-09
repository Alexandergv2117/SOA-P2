using Domain.Entities;
using Domain.Model;
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
    public class Activo_EmployeeService : IActivo_Employee
    {
        private readonly ILogger<Activo_EmployeeService> _logger;
        private readonly Activo_EmployeeRepository activo_EmployeeRepository;
        private readonly IEmail _email;

        public Activo_EmployeeService(ILogger<Activo_EmployeeService> logger, ApplicationDbContext context, IEmail email)
        {
            _logger = logger;
            activo_EmployeeRepository = new Activo_EmployeeRepository(context);
            _email = email;
        }

        public DataResponse AssignActivo(RequestPostAssignActivo assignActivo)
        {
            DataResponse res = new DataResponse();
            try
            {
                activo_EmployeeRepository.AssignActivo(assignActivo);
                _email.SendAssignmentActivo(new ParamsSendEmail
                {
                    id_activo = assignActivo.id_activo,
                    id_empleoyee = assignActivo.id_empleoyee,
                    deliveryDate = assignActivo.delivery_date
                });
                res.Code = 200;
                res.Data = assignActivo;
                res.Message = "OK";
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                res.Code = 400;
                res.Data = assignActivo;
                res.Message = "No se pudo, asignar el activo";
            }
            return res;
        }

        public DataResponse DeliveryActivo(RequestPatchDeliveryActivo deliveryActivo)
        {
            DataResponse res = new DataResponse();
            try
            {
                activo_EmployeeRepository.deliveryActivo(deliveryActivo);
                _email.SendDeliveryActivo(new ParamsSendEmail
                {
                    id_activo = deliveryActivo.id_activo,
                    id_empleoyee = deliveryActivo.id_empleoyee,
                    deliveryDate = DateTime.Now.ToString("yyyy-MM-dd")
                });
                res.Code = 200;
                res.Data = deliveryActivo;
                res.Message = "OK";
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                res.Code = 400;
                res.Data = deliveryActivo;
                res.Message = "No se pudo, entregar el activo";
            }
            return res;
        }

        public DataResponse GetAllUndelivered()
        {
            DataResponse res = new DataResponse();
            List<DataActivoEmployeeNotificationEmail> list = new List<DataActivoEmployeeNotificationEmail>();

            try
            {
                list = activo_EmployeeRepository.GetAllUndelivered();
                res.Code = 200;
                res.Data = list;
                res.Message = "OK";
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                res.Code = 200;
                res.Data = list;
                res.Message = "Error, al obtene los datos";
            }
            return res;
        }

        public List<DataActivoEmployeeNotificationEmail> GetAllUndeliveredSendNotification()
        {
            List<DataActivoEmployeeNotificationEmail> list = new List<DataActivoEmployeeNotificationEmail>();

            try
            {
                list = activo_EmployeeRepository.GetAllUndelivered();
                for (int i = 0; i < list.Count; i++)
                {
                    _email.SentNotificationDelivery(list[i]);
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
            return list;
        }
    }
}
