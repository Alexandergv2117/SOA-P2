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
    public class ActivoService : IActivo
    {
        private readonly ILogger<ActivoService> _logger;
        private readonly ActivoRepository activoRepository;

        public ActivoService(ILogger<ActivoService> logger, ApplicationDbContext context)
        {
            _logger = logger;
            activoRepository = new ActivoRepository(context);
        }

        public DataResponse GetAll()
        {
            List<Activo> activos = new List<Activo>();
            DataResponse res = new DataResponse();

            try
            {
                activos = activoRepository.GetAll();
                res.Code = 200;
                res.Data = activos;
                res.Message = "OK";
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                res.Code = 500;
                res.Data = activos;
                res.Message = e.Message;
            }

            return res;
        }

        public DataResponse AddActivo(RequestPostCreateActivo newActivo)
        {
            DataResponse res = new DataResponse();
            try
            {
                activoRepository.AddActivo(newActivo);
                res.Code = 200;
                res.Data = newActivo;
                res.Message = "Activo creado";
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                res.Code = 500;
                res.Data = newActivo;
                res.Message = "Error al crear el activo";
            }
            return res;
        }

        public DataResponse UpdateStatusActivo(RequestPatchUpdateStatusActivo newStatus)
        {
            DataResponse res = new DataResponse();
            try
            {
                bool status = activoRepository.UpdateStatusActivo(newStatus);
                if (status)
                {
                    res.Code = 200;
                    res.Data = newStatus;
                    res.Message = "Status del activo actualizado";
                } else
                {
                    res.Code = 500;
                    res.Data = newStatus;
                    res.Message = "No se pudo, actualizar el status del activo";
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                res.Code = 500;
                res.Data = newStatus;
                res.Message = "No se pudo, actualizar el status del activo";
            }
            return res;
        }

        public DataResponse DeleteActivo(RequestDeleteActivo requestDeleteActivo)
        {
            DataResponse res = new DataResponse();

            try
            {
                bool isDelete = activoRepository.Delete(requestDeleteActivo);

                if (isDelete)
                {
                    res.Code = 200;
                    res.Data = null;
                    res.Message = "Activo eliminado";
                } else
                {
                    res.Code = 400;
                    res.Data = null;
                    res.Message = "El activo, no se pudo eliminar";
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                res.Code = 500;
                res.Data = null;
                res.Message = "No se pudo, eliminar el activo";
            }

            return res;
        }
    }
}
