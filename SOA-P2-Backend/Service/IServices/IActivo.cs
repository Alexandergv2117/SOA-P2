using Domain.Entities;
using Domain.Request;
using Domain.Response;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IServices
{
    public interface IActivo
    {
        DataResponse GetAll();
        DataResponse AddActivo(RequestPostCreateActivo newActivo);
        DataResponse UpdateStatusActivo(RequestPatchUpdateStatusActivo newStatus);

        DataResponse DeleteActivo(RequestDeleteActivo requestDeleteActivo);
    }
}
