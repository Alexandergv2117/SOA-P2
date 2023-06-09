using Domain.Entities;
using Domain.Model;
using Domain.Request;
using Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IServices
{
    public interface IActivo_Employee
    {
        DataResponse AssignActivo(RequestPostAssignActivo assignActivo);

        DataResponse DeliveryActivo(RequestPatchDeliveryActivo deliveryActivo);
        DataResponse GetAllUndelivered();
        List<DataActivoEmployeeNotificationEmail> GetAllUndeliveredSendNotification();
    }
}
